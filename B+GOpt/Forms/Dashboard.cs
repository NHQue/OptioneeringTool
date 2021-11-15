using System;
using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;
using Rhino;
using Rhino.Geometry;
using B_GOpt.Classes;
using Rhino.Collections;
using Rhino.Geometry.Collections;
using Rhino.Input.Custom;
using Rhino.Commands;
using Rhino.DocObjects;

namespace B_GOpt.Forms
{
    public partial class Form2 : KryptonForm
    {

        private RhinoDoc docform;

        private Rhino.Geometry.Brep brep = null;
        RhinoList<Brep> cores = new RhinoList<Brep>();
        private double surfaceArea;
        double far;
        double liveLoad = 1.5;
        double addDeadLoad = 1.5;
        double deadLoadSlab;
        double totalLoad;
        string material;

        //public string documentName = RhinoDoc.ActiveDoc.Name;


        public Form2(RhinoDoc doc)
        {
            InitializeComponent();

            docform = doc;



            //Displays the chart
            //chartCO2.Titles.Add("Pie Chart");
            chartCO2.Series["CO2"].IsValueShownAsLabel = false;
            chartCO2.Series["CO2"].Points.AddXY("Slabs", "50");
            chartCO2.Series["CO2"].Points.AddXY("Columns", "25");
            chartCO2.Series["CO2"].Points.AddXY("Beams", "35");
            chartCO2.Series["CO2"].Points.AddXY("Steel Rebar", "10");

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void tbarSpacX_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarSpacX.Value / 100f;
            lblSpacXValue.Text = value.ToString() + "  m";
        }

        private void tbarSpacY_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarSpacY.Value / 100f;
            lblSpacYValue.Text = value.ToString() + "  m";
        }

        private void tbarLiveLoad_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarLiveLoad.Value / 10f;
            lblLiveLoadValue.Text = value.ToString() + "  kN/m" + ("\u00B2");

            liveLoad = value; 
        }

        private void tbarFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarFloorHeight.Value / 100f;
            lblFloorHeightValue.Text = value.ToString() + "  m";
        }


        private void btnSelectBuilding_Click_1(object sender, EventArgs e)
        {
            brep = MyFunctions.SelectBuildingGeometry(brep);
        }

        private void btnSelectCore_Click(object sender, EventArgs e)
        {
            cores = MyFunctions.SelectCores();
        }


        private void btnStructGrid3D_Click(object sender, EventArgs e)
        {
            //Reseting the results for the next validation
            surfaceArea = 0;
            far = 0;

            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueSpacX = tbarSpacX.Value / 100f;
                double valueSpacY = tbarSpacY.Value / 100f;

                double actFloorHeight = buildingGeom.FloorHeight(brep, valueFloorHeight);
                double actXSpac = buildingGeom.ActualXSpacing(brep, valueSpacX);
                double actYSpac = buildingGeom.ActualXSpacing(brep, valueSpacY);

                int nStorey = Convert.ToInt32(Math.Floor(buildingGeom.BuildingHeight(brep) / valueFloorHeight));
                int nspacX = Convert.ToInt32(Math.Floor(buildingGeom.BuildingLength(brep) / valueSpacX));
                int nspacY = Convert.ToInt32(Math.Floor(buildingGeom.BuildingWidth(brep) / valueSpacY));

                Brep baseSrf = buildingGeom.GetBaseSurface(brep, docform);
                BrepEdgeList baseSrfEdges = baseSrf.Edges;
                CurveList baseSrfEdgeCurves = new CurveList();

                for (int i = 0; i < baseSrfEdges.Count; i++)
                {
                    baseSrfEdgeCurves.Add(baseSrfEdges[i]);
                    //docform.Objects.AddCurve(baseSrfEdges[i].ToNurbsCurve()); 
                }

                Curve[] baseSrfJoinedEdgeCurves = Curve.JoinCurves(baseSrfEdgeCurves);


                //Creates the slabs edge curves to use them for their own Grid 2D creation
                RhinoList<Brep> slabs = buildingGeom.ConstructSlabs(brep, actFloorHeight, nStorey, docform);
                CurveList slabOuterCurves = new CurveList();

                for (int i = 0; i < slabs.Count; i++)
                {
                    BrepEdgeList slabEdges = slabs[i].Edges;
                    CurveList crvs = new CurveList();

                    for (int j = 0; j < slabEdges.Count; j++)
                    {
                        crvs.Add(slabEdges[j]);
                    }

                    Curve[] joinedEdgeCurves = Curve.JoinCurves(crvs);

                    slabOuterCurves.Add(joinedEdgeCurves[0]);
                }

                //for (int i = 0; i < slabOuterCurves.Count; i++)
                //{
                //    docform.Objects.AddCurve(slabOuterCurves[i]);
                //}


                //Creates the grid at base floor
                //-------------------------------------------------------------------------------------------
                BoundingBox bBox = StructGrid.CreateBoundingBox(baseSrfJoinedEdgeCurves[0]);

                RhinoList<Line> xGridLines = StructGrid.XGridLines(bBox, nspacX, docform);
                RhinoList<Line> yGridLines = StructGrid.YGridLines(bBox, nspacY, docform);

                RhinoList<Line> xBeams = new RhinoList<Line>();
                RhinoList<Line> yBeams = new RhinoList<Line>();
                RhinoList<Curve> edgeBeams = new RhinoList<Curve>();

                List<Line> outerColumns = new List<Line>();
                List<Line> innerColumns = new List<Line>();
                List<Line> edgeColumns = new List<Line>();


                //Creates the Grid 2D for all slabs
                //Iteration variable i corresponds to the storey
                //-------------------------------------------------------------------------------------------
                Transform xTrans = Transform.Translation(0, 0, actFloorHeight);

                for (int i = 0; i < slabs.Count; i++)
                {
                    bBox.Transform(xTrans);
                    xGridLines = StructGrid.XGridLines(bBox, nspacX, docform);
                    yGridLines = StructGrid.YGridLines(bBox, nspacY, docform);

                    RhinoList<Line> xIntLines = StructGrid.XIntLines(xGridLines, slabOuterCurves[i], docform);
                    RhinoList<Line> yIntLines = StructGrid.YIntLines(yGridLines, slabOuterCurves[i], docform);

                    //xBeams as SingleSpanBeams, yBeams as ContinousBeams
                    if (actXSpac < actYSpac)
                    {
                        List<Line> xBeamsIt = StructGrid.YBeams(xIntLines, yIntLines, docform);
                        for (int j = 0; j < xBeamsIt.Count; j++)
                        {
                            xBeams.Add(xBeamsIt[j]);
                        }

                        for (int j = 0; j < yIntLines.Count; j++)
                        {
                            yBeams.Add(yIntLines[j]);
                        }

                        //InnerColumns
                        List<Line> innerColumnsIt = StructGrid.InnerColumns(xIntLines, yIntLines, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            innerColumns.Add(innerColumnsIt[j]);
                        }
                    }

                    //xBeams as ContinousBeams, yBeams as SingleSpanBeams
                    else
                    {
                        for (int j = 0; j < xIntLines.Count; j++)
                        {
                            xBeams.Add(xIntLines[j]);
                        }

                        List<Line> yBeamsIt = StructGrid.YBeams(yIntLines, xIntLines, docform);
                        for (int j = 0; j < yBeamsIt.Count; j++)
                        {
                            yBeams.Add(yBeamsIt[j]);
                        }

                        //InnerColumns
                        List<Line> innerColumnsIt = StructGrid.InnerColumns(yIntLines, xIntLines, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            innerColumns.Add(innerColumnsIt[j]);
                        }
                    }

                    //OuterColumns
                    List<Line> outerColumnsIt = StructGrid.OuterColumns(xIntLines, yIntLines, actFloorHeight, docform);
                    for (int j = 0; j < outerColumnsIt.Count; j++)
                    {
                        outerColumns.Add(outerColumnsIt[j]);
                    }

                    //EdgeColumns
                    List<Line> edgeColumnsIt = StructGrid.EdgeColumns(slabOuterCurves[i], actFloorHeight, docform);
                    for (int j = 0; j < edgeColumnsIt.Count; j++)
                    {
                        edgeColumns.Add(edgeColumnsIt[j]);
                    }

                    //EdgeBeams
                    List<Curve> edgeBeamsIt = StructGrid.EdgeBeams(xIntLines, yIntLines, slabOuterCurves[i], docform);
                    for (int j = 0; j < edgeBeamsIt.Count; j++)
                    {
                        edgeBeams.Add(edgeBeamsIt[j]);
                    }
                }



                //Adds the elements to the Rhino Document
                for (int i = 0; i < xBeams.Count; i++)
                {
                    docform.Objects.AddLine(xBeams[i]);
                }

                for (int i = 0; i < yBeams.Count; i++)
                {
                    docform.Objects.AddLine(yBeams[i]);
                }

                for (int i = 0; i < edgeBeams.Count; i++)
                {
                    docform.Objects.AddCurve(edgeBeams[i]);
                }

                for (int i = 0; i < outerColumns.Count; i++)
                {
                    docform.Objects.AddLine(outerColumns[i]);
                }

                for (int i = 0; i < innerColumns.Count; i++)
                {
                    docform.Objects.AddLine(innerColumns[i]);
                }

                for (int i = 0; i < edgeColumns.Count; i++)
                {
                    docform.Objects.AddLine(edgeColumns[i]);
                }

                //for (int i = 0; i < slabs.Count; i++)
                //{
                //    docform.Objects.AddBrep(slabs[i]);
                //}

                docform.Views.Redraw();




                //Prompting the results to the dashboard
                //-------------------------------------------------------------------------------------------
                for (int i = 0; i < slabs.Count; i++)
                {
                    double area = slabs[i].GetArea();
                    surfaceArea = surfaceArea + area;
                }

                lblSurfaceValue.Text = Math.Round(surfaceArea, 0).ToString() + "  m" + ("\u00B2");
                lblFarValue.Text = Math.Round(baseSrf.GetArea() / surfaceArea, 2).ToString();
            }
        }




        private void btnTestGrid_Click(object sender, EventArgs e)
        {
            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueSpacX = tbarSpacX.Value / 100f;
                double valueSpacY = tbarSpacY.Value / 100f;

                double actFloorHeight = buildingGeom.FloorHeight(brep, valueFloorHeight);
                double actXSpac = buildingGeom.ActualXSpacing(brep, valueSpacX);
                double actYSpac = buildingGeom.ActualXSpacing(brep, valueSpacY);

                int nStorey = Convert.ToInt32(Math.Floor(buildingGeom.BuildingHeight(brep) / valueFloorHeight));
                int nspacX = Convert.ToInt32(Math.Floor(buildingGeom.BuildingLength(brep) / valueSpacX));
                int nspacY = Convert.ToInt32(Math.Floor(buildingGeom.BuildingWidth(brep) / valueSpacY));

                string buildingInfo = String.Format($"Building Height: {buildingGeom.BuildingHeight(brep)} m; Building Length: {buildingGeom.BuildingLength(brep)} m; Building Width: {buildingGeom.BuildingWidth(brep)} m;" +
                                                    $" Actual FloorHeight: {actFloorHeight} m; Actual x-Spacing: {actXSpac} m; Actual y-Spacing: {actYSpac} m;" +
                                                    $" Storey Count: {nStorey}; Divisions in x-Direction: {nspacX}; Divisions in y-Direction: {nspacY}");
                                            
                RhinoApp.WriteLine(buildingInfo);

                Brep baseSrf = buildingGeom.GetBaseSurface(brep, docform);
                BrepEdgeList baseSrfEdges = baseSrf.Edges;
                CurveList baseSrfEdgeCurves = new CurveList();

                for (int i = 0; i < baseSrfEdges.Count; i++)
                {
                    baseSrfEdgeCurves.Add(baseSrfEdges[i]);
                    docform.Objects.AddCurve(baseSrfEdges[i].ToNurbsCurve()); 
                }

                Curve[] baseSrfJoinedEdgeCurves = Curve.JoinCurves(baseSrfEdgeCurves);


                //Creates the slabs edge curves to use them for their own Grid 2D creation
                RhinoList<Brep> slabs = buildingGeom.ConstructSlabs(brep, actFloorHeight, nStorey, docform);
                CurveList slabEdgeCurves = new CurveList();

                for (int i = 0; i < slabs.Count; i++)
                {
                    BrepEdgeList slabEdges = slabs[i].Edges;
                    CurveList crvs = new CurveList();

                    for (int j = 0; j < slabEdges.Count; j++)
                    {
                        crvs.Add(slabEdges[j]);
                    }

                    Curve[] joinedEdgeCurves = Curve.JoinCurves(crvs);

                    slabEdgeCurves.Add(joinedEdgeCurves[0]);
                }

                //Creates the grid at base floor
                //-------------------------------------------------------------------------------------------
                BoundingBox bBox = StructGrid.CreateBoundingBox(baseSrfJoinedEdgeCurves[0]);

                RhinoList<Line> xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                RhinoList<Line> yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

                RhinoList<Line> xBeams = new RhinoList<Line>();
                RhinoList<Line> yBeams = new RhinoList<Line>();
                RhinoList<Curve> edgeBeams = new RhinoList<Curve>();

                List<Line> outerColumns = new List<Line>();
                List<Line> innerColumns = new List<Line>();
                List<Line> edgeColumns = new List<Line>();


                //Using custom members 
                List<Beam> beamsInXDir = new List<Beam>();
                List<Beam> beamsInYDir = new List<Beam>();

                List<Column> outerCol = new List<Column>();
                List<Column> innerCol = new List<Column>();
                List<Column> edgeCol = new List<Column>();

                List<Slab> slabs1 = new List<Slab>();




                //Intersect slabs with core
                RhinoList<Brep> floorSlabs = StructGrid.SplitSlabsWithCores(cores, slabEdgeCurves, docform);

                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    Slab slab = new Slab(floorSlabs[i], actXSpac, actYSpac, i, liveLoad, 0);
                    slabs1.Add(slab);
                }





                //Predimensioning slabs
                double cs;
                if (material == "Concrete")
                {
                    cs = PreDim.ConcreteSlab(actXSpac, actYSpac);

                    for (int i = 0; i < floorSlabs.Count; i++)
                    {
                        slabs1[i].Height = cs;
                    }

                    deadLoadSlab = cs * 25;
                }
                else
                {
                    cs = 1;
                }

                RhinoApp.WriteLine("SlabHeight: " + cs);



                //Calculating total load
                totalLoad = liveLoad + deadLoadSlab + addDeadLoad; 






                //Creates the Grid 2D for all slabs
                //Iteration variable i corresponds to the storey
                //-------------------------------------------------------------------------------------------
                Transform xTrans = Transform.Translation(0, 0, actFloorHeight);

                for (int i = 0; i < slabs.Count; i++)
                {
                    bBox.Transform(xTrans);
                    xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                    yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

                    RhinoList<Line> xIntLines = StructGrid.XIntLines(xGridLines, slabEdgeCurves[i], docform);
                    RhinoList<Line> yIntLines = StructGrid.YIntLines(yGridLines, slabEdgeCurves[i], docform);

                    //xBeams as SingleSpanBeams, yBeams as ContinousBeams
                    if (actXSpac < actYSpac)
                    {
                        List<Line> xBeamsIt = StructGrid.YBeams(xIntLines, yIntLines, docform);
                        for (int j = 0; j < xBeamsIt.Count; j++)
                        {

                            RhinoList<Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xBeamsIt[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideBreps(cores, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(xBeamsIt[j]);
                                    Beam xBeam = new Beam(lineCurve, "Secondary", i, totalLoad, actYSpac);
                                    beamsInXDir.Add(xBeam);

                                    xBeams.Add(intersectedLines[k]);
                                }
                            }
                        }

                        for (int j = 0; j < yIntLines.Count; j++)
                        {
                            RhinoList<Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yIntLines[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideBreps(cores, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(yIntLines[j]);
                                    Beam yBeam = new Beam(lineCurve, "Primary", i, totalLoad, actXSpac);
                                    beamsInYDir.Add(yBeam);

                                    yBeams.Add(intersectedLines[k]);
                                }
                            }
                        }

                        //InnerColumns
                        List<Line> innerColumnsIt = StructGrid.InnerColumns(xIntLines, yIntLines, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            if (!MyFunctions.IsLineInsideBreps(cores, innerColumnsIt[j], docform))
                            {
                                LineCurve lineCurve = new LineCurve(innerColumnsIt[j]);
                                Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                                col.Area = PreDim.ConcreteColumn(col.Load);
                                innerCol.Add(col);

                                innerColumns.Add(innerColumnsIt[j]);
                            }
                        }
                    }


                    //xBeams as ContinousBeams, yBeams as SingleSpanBeams
                    else
                    {
                        for (int j = 0; j < xIntLines.Count; j++)
                        {
                            RhinoList<Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xIntLines[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideBreps(cores, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(intersectedLines[k]);
                                    Beam xBeam = new Beam(lineCurve, "Primary", i, totalLoad, actXSpac);
                                    beamsInXDir.Add(xBeam);

                                    xBeams.Add(intersectedLines[k]);
                                }
                            }
                        }


                        List<Line> yBeamsIt = StructGrid.YBeams(yIntLines, xIntLines, docform);
                        for (int j = 0; j < yBeamsIt.Count; j++)
                        {
                            RhinoList<Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yBeamsIt[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideBreps(cores, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(yBeamsIt[j]);
                                    Beam yBeam = new Beam(lineCurve, "Secondary", i, totalLoad, actYSpac);
                                    beamsInYDir.Add(yBeam);

                                    yBeams.Add(intersectedLines[k]);
                                }
                            }
                        }
                        

                        //InnerColumns
                        List<Line> innerColumnsIt = StructGrid.InnerColumns(yIntLines, xIntLines, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            if (!MyFunctions.IsLineInsideBreps(cores, innerColumnsIt[j], docform))
                            {
                                LineCurve lineCurve = new LineCurve(innerColumnsIt[j]);
                                Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                                col.Area = PreDim.ConcreteColumn(col.Load); 

                                innerCol.Add(col);

                                innerColumns.Add(innerColumnsIt[j]);
                            }
                        }
                    }


                    //OuterColumns
                    List<Line> outerColumnsIt = StructGrid.OuterColumns(xIntLines, yIntLines, actFloorHeight, docform);
                    for (int j = 0; j < outerColumnsIt.Count; j++)
                    {
                        LineCurve lineCurve = new LineCurve(outerColumnsIt[j]);
                        Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                        outerCol.Add(col);

                        outerColumns.Add(outerColumnsIt[j]);
                    }

                    //EdgeColumns
                    List<Line> edgeColumnsIt = StructGrid.EdgeColumns(slabEdgeCurves[i], actFloorHeight, docform);
                    for (int j = 0; j < edgeColumnsIt.Count; j++)
                    {
                        LineCurve lineCurve = new LineCurve(edgeColumnsIt[j]);
                        Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                        edgeCol.Add(col);

                        edgeColumns.Add(edgeColumnsIt[j]);
                    }

                    //EdgeBeams
                    List<Curve> edgeBeamsIt = StructGrid.EdgeBeams(xIntLines, yIntLines, slabEdgeCurves[i], docform);
                    for (int j = 0; j < edgeBeamsIt.Count; j++)
                    {
                        edgeBeams.Add(edgeBeamsIt[j]);
                    }
                }





                //Adds the elements to the Rhino Document

                //for (int i = 0; i < xBeams.Count; i++)
                //{
                //    docform.Objects.AddLine(xBeams[i]);
                //}

                //for (int i = 0; i < yBeams.Count; i++)
                //{
                //    docform.Objects.AddLine(yBeams[i]);
                //}

                //for (int i = 0; i < edgeBeams.Count; i++)
                //{
                //    docform.Objects.AddCurve(edgeBeams[i]);
                //}

                //for (int i = 0; i < outerColumns.Count; i++)
                //{
                //    docform.Objects.AddLine(outerColumns[i]);
                //}

                for (int i = 0; i < innerColumns.Count; i++)
                {
                    docform.Objects.AddLine(innerColumns[i]);
                }

                //for (int i = 0; i < edgeColumns.Count; i++)
                //{
                //    docform.Objects.AddLine(edgeColumns[i]);
                //}

                //for (int i = 0; i < slabs.Count; i++)
                //{
                //    docform.Objects.AddBrep(slabs[i]);
                //}

                for (int i = 0; i < slabEdgeCurves.Count; i++)
                {
                    docform.Objects.AddCurve(slabEdgeCurves[i]);
                }

                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    docform.Objects.AddBrep(floorSlabs[i]);
                }


                //for (int i = 0; i < beamsInXDir.Count; i++)
                //{
                //    docform.Objects.AddCurve(beamsInXDir[i].ToNurbsCurve());
                //}

                //for (int i = 0; i < beamsInYDir.Count; i++)
                //{
                //    docform.Objects.AddCurve(beamsInYDir[i].ToNurbsCurve());
                //}








                //Creating TextDots with some member data
                //Innercolumn
                MyFunctions.SetLayer(docform, "InnerColumnLoad", System.Drawing.Color.Beige);

                for (int i = 0; i < innerCol.Count; i++)
                {
                    var textDot = new TextDot(Convert.ToInt32(innerCol[i].Load).ToString(), innerCol[i].LineCurve.PointAt(0.5));
                    docform.Objects.AddTextDot(textDot);
                }

                MyFunctions.SetLayer(docform, "InnerColumnArea", System.Drawing.Color.Beige);

                for (int i = 0; i < innerCol.Count; i++)
                {
                    var textDot = new TextDot(Math.Round(innerCol[i].Area, 2).ToString(), innerCol[i].LineCurve.PointAt(0.5));
                    docform.Objects.AddTextDot(textDot);
                }




                //Slabs
                MyFunctions.SetLayer(docform, "SlabCrossSection", System.Drawing.Color.Beige);

                for (int i = 0; i < slabs1.Count; i++)
                {
                    var textDot = new TextDot(Math.Round(slabs1[i].Height, 2).ToString(), slabs1[i].GetBoundingBox(true).Center);
                    docform.Objects.AddTextDot(textDot);
                }










                //Deleting all outer members














                //Prompting the results to the dashboard
                //-------------------------------------------------------------------------------------------
                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    double area = floorSlabs[i].GetArea();
                    surfaceArea = surfaceArea + area;
                }

                lblSurfaceValue.Text = Math.Round(surfaceArea, 0).ToString() + "  m" + ("\u00B2");
                lblFarValue.Text = Math.Round(baseSrf.GetArea() / surfaceArea, 2).ToString();
            }
        }

        private void btnEvaluateObj_Click(object sender, EventArgs e)
        {
            GetObject gc = new GetObject();
            gc.SetCommandPrompt("Select some curves");
            gc.GeometryFilter = ObjectType.Curve;
            gc.GetMultiple(1, 0);

            if (gc.CommandResult() != Result.Success)
                RhinoApp.WriteLine("Result success");


            int lineCount = 0;
            int arcCount = 0;
            int cirvleCount = 0;
            int polylineCount = 0;

            //Create a collection of curves
            //List<Curve> curves = new List<Curve>(gc.ObjectCount);
            CurveList curves = new CurveList();                         //Does the same as the line above


            for (int i = 0; i < gc.ObjectCount; i++)
            {
                Curve curve = gc.Object(i).Curve();                       //extract a curve from object
                if (null != curve)
                    curves.Add(curve);

                Beam lineCurve = curve as Beam;                             //as keyword -> as is casting: Converts datatype into another datatype  //Here: Conversion from Curve datatype into LineCurve datatype 

                if (lineCurve != null)
                    lineCount++;

                PolylineCurve polylineCurve = curve as PolylineCurve;
                if (polylineCurve != null)
                    polylineCount++;

                ArcCurve arcCurve = curve as ArcCurve;
                if (arcCurve != null)
                {
                    if (arcCurve.IsCircle())                            //Checks if the arcCurve is closed (that means it is a circle)
                        cirvleCount++;
                    else
                        arcCount++;
                }

                //curve.Domain = new Interval(0, 1);
                //docform.Objects.AddPoint(curve.PointAtStart);
                //docform.Objects.AddPoint(curve.PointAtEnd);
                //docform.Objects.AddPoint(curve.PointAt(0.75));


                //string format = string.Format("F{0}", docform.DistanceDisplayPrecision); //Creates a format so that the the following string/length is not printed with 10 or so decimals 


                string s = string.Format("The user selected {0} beams, {1} polylines, {2} circles, {3} arcs and {4} in total", lineCount.ToString(), polylineCount.ToString(), cirvleCount.ToString(), arcCount.ToString(), curves.Count.ToString());
                //string info = string.Format("The curve {0} has the length of {1} and domain: {2} to {3}", i.ToString(), curve.GetLength().ToString(format),
                                                    //curve.Domain.T0.ToString(format), curve.Domain.T1.ToString(format));

            RhinoApp.WriteLine(s);
            //RhinoApp.WriteLine(info);

            }

            docform.Views.Redraw();


        }

        private void rbtnSteelMat_CheckedChanged(object sender, EventArgs e)
        {
            material = "Steel";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }

        private void rbtnConcreteMat_CheckedChanged(object sender, EventArgs e)
        {
            material = "Concrete";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }

        private void rbtnTimberMat_CheckedChanged(object sender, EventArgs e)
        {
            material = "Timber";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }


    }
}
