using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rhino;
using System.Drawing;
using Rhino.Commands;
using RhinoWindows;
using System.Windows.Interop;
using Rhino.Collections;
using Rhino.Geometry;
using B_GOpt.Classes;
using Rhino.Geometry.Collections;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Media.Media3D;
using Rhino.DocObjects;
using Rhino.DocObjects.Tables;

namespace B_GOpt.Views 
{
    /// <summary>
    /// Interaction logic for SampleCsWpfDialog.xaml
    /// </summary>
    public partial class MainWindow
    {
        //Declaration of some variables
        //-----------------------------------------------------------------
        private RhinoDoc docform;

        private Rhino.Geometry.Brep brep = null;
        private double surfaceArea;
        double far;
        double liveLoad = 1.5;
        double addDeadLoad = 1.5;
        double deadLoadSlab;
        double totalLoad;
        string material;
        string structSystem;
        string primaryDir;

        public double actXSpac;
        public double actYSpac;

        private ObservableValue valueEmbodiedCO2Slabs;
        private ObservableValue valueEmbodiedCO2Col;
        private ObservableValue valueEmbodiedCO2Beams;
        private ObservableValue valueEmbodiedCO2Foundations;
        private ObservableValue valueEmbodiedCO2Cores;

        double embodiedCO2Total = 0;

        public BuildingVariant buildingVariant = new BuildingVariant();

        readonly string fileName = "BuildingVariants.txt";


        //Declaration of some lists
        //-----------------------------------------------------------------
        List<Guid> ids = new List<Guid>();
        List<Layer> layers = new List<Layer>();
        RhinoList<Brep> cores = new RhinoList<Brep>();
        List<BuildingVariant> buildingVariants = new List<BuildingVariant>();


        public MainWindow(RhinoDoc doc)
        {
            InitializeComponent();

            docform = doc;


            //Prompt project name
            string rhinoDocName = RhinoDoc.ActiveDoc.Name;
            string projectName = System.IO.Path.GetFileNameWithoutExtension(rhinoDocName);

            TextBlockProject.Text = "Project: " + projectName;


            //Clear textfile
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            File.WriteAllText(filePath, String.Empty);


            //Defining the Carbon PieChart
            //--------------------------------------------------------------------------------------
            valueEmbodiedCO2Slabs = new ObservableValue(0);
            valueEmbodiedCO2Col = new ObservableValue(0);
            valueEmbodiedCO2Beams = new ObservableValue(0);
            valueEmbodiedCO2Foundations = new ObservableValue(0);
            valueEmbodiedCO2Cores = new ObservableValue(0);

            SeriesCollection = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Slabs",
                        Values = new ChartValues<ObservableValue> { valueEmbodiedCO2Slabs },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.DarkSeaGreen),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Columns",
                        Values = new ChartValues<ObservableValue> {valueEmbodiedCO2Col},
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.LightSkyBlue),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Beams",
                        Values = new ChartValues<ObservableValue> {valueEmbodiedCO2Beams},
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.Salmon),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Foundations",
                        Values = new ChartValues<ObservableValue> {valueEmbodiedCO2Foundations},
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.Peru),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Core",
                        Values = new ChartValues<ObservableValue> {valueEmbodiedCO2Cores},
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.DarkKhaki),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    }
                };

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("Embodied carbon: " + chartPoint.Y + " kg CO" + ("\u2082") + "e " 
                            + "(" + (Math.Round(chartPoint.Participation, 3) * 100).ToString() + "% of the building's structure)");
        }


        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            //Reset all variables for the next variant
            valueEmbodiedCO2Slabs.Value = 0;
            valueEmbodiedCO2Col.Value = 0;
            valueEmbodiedCO2Beams.Value = 0;
            valueEmbodiedCO2Foundations.Value = 0;
            valueEmbodiedCO2Cores.Value = 0;

            embodiedCO2Total = 0;
            surfaceArea = 0;
            far = 0;



            //Check if a building is selected
            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                string volume = Math.Round(VolumeMassProperties.Compute(brep).Volume, 0).ToString();

                int coreCount = cores.Count;


                //double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueFloorHeight = SliderFloorHeight.Value;
                double valueSpacX = SliderXSpac.Value;
                double valueSpacY = SliderYSpac.Value;
                double beamDistance = SliderDistance.Value;

                double actFloorHeight = buildingGeom.FloorHeight(brep, valueFloorHeight);
                actXSpac = buildingGeom.ActualXSpacing(brep, valueSpacX);
                actYSpac = buildingGeom.ActualXSpacing(brep, valueSpacY);

                int nStorey = Convert.ToInt32(Math.Floor(buildingGeom.BuildingHeight(brep) / valueFloorHeight));
                int nspacX = Convert.ToInt32(Math.Floor(buildingGeom.BuildingLength(brep) / valueSpacX));
                int nspacY = Convert.ToInt32(Math.Floor(buildingGeom.BuildingWidth(brep) / valueSpacY));

                if (actXSpac < actYSpac)
                    primaryDir = "YDir";
                else
                    primaryDir = "XDir";


                string buildingInfo = String.Format($"Building Dimensions: Building Height - {buildingGeom.BuildingHeight(brep)} m; Building Length - {buildingGeom.BuildingLength(brep)} m; Building Width: {buildingGeom.BuildingWidth(brep)} m; " +
                                                    $"Actual FloorHeight - {actFloorHeight} m; Actual x-Spacing - {actXSpac} m; Actual y-Spacing - {actYSpac} m; " +
                                                    $"Storey Count - {nStorey}; Divisions in x-Direction - {nspacX}; Divisions in y-Direction - {nspacY}");

                RhinoApp.WriteLine(buildingInfo);

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

                RhinoList<Rhino.Geometry.Line> xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                RhinoList<Rhino.Geometry.Line> yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

                RhinoList<Rhino.Geometry.Line> secondaryBeamLines = StructGrid.SecondaryBeams(bBox, actXSpac, actYSpac, yGridLines, xGridLines, beamDistance, docform);


                

                RhinoList<Rhino.Geometry.Line> xBeams = new RhinoList<Rhino.Geometry.Line>();
                RhinoList<Rhino.Geometry.Line> yBeams = new RhinoList<Rhino.Geometry.Line>();

                RhinoList<Curve> edgeBeams = new RhinoList<Curve>();

                List<Rhino.Geometry.Line> outerColumns = new List<Rhino.Geometry.Line>();
                List<Rhino.Geometry.Line> innerColumns = new List<Rhino.Geometry.Line>();
                List<Rhino.Geometry.Line> edgeColumns = new List<Rhino.Geometry.Line>();


                //Using custom members 
                List<Beam> beamsInXDir = new List<Beam>();
                List<Beam> beamsInYDir = new List<Beam>();

                List<Column> outerCol = new List<Column>();
                List<Column> innerCol = new List<Column>();
                List<Column> edgeCol = new List<Column>();

                List<Slab> slabsSlabs = new List<Slab>();


                //Intersect slabs with core
                RhinoList<Brep> floorSlabs = StructGrid.SplitSlabsWithCores(cores, slabEdgeCurves, docform);

                floorSlabs.Remove(floorSlabs[floorSlabs.Count - 1]);
                
                floorSlabs.Add(slabs[slabs.Count - 1]);


                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    Slab slab = new Slab(floorSlabs[i], actXSpac, actYSpac, i, liveLoad, 0);
                    slabsSlabs.Add(slab);
                }



                //Predimensioning slabs
                //-------------------------------------------------------------------------------------------

                double crossSectionSlab;
                crossSectionSlab = PreDim.Slab(material, structSystem, actXSpac, actYSpac, totalLoad);

                for (int i = 0; i < floorSlabs.Count; i++)
                    slabsSlabs[i].Height = crossSectionSlab;

                double concretePlateHeight = 0;
                if (material == "Concrete" && structSystem == "Beam")
                    concretePlateHeight = crossSectionSlab;


                //if (material == "Concrete")
                //{
                //    crossSectionSlab = PreDim.ConcreteFlatSlab(actXSpac, actYSpac);

                //    for (int i = 0; i < floorSlabs.Count; i++)
                //        slabsSlabs[i].Height = crossSectionSlab;

                //    double gammaConcrete = 25;               //kN/m3
                //    deadLoadSlab = crossSectionSlab * gammaConcrete;
                //}

                //else if (material == "Timber")
                //{
                //    crossSectionSlab = PreDim.TimberSlab(actXSpac, actYSpac);

                //    for (int i = 0; i < floorSlabs.Count; i++)
                //        slabsSlabs[i].Height = crossSectionSlab;

                //    double gammaCLT = 5;               //kN/m3
                //    deadLoadSlab = crossSectionSlab * gammaCLT;
                //}

                //else
                //    crossSectionSlab = 1;

                //RhinoApp.WriteLine("SlabHeight: " + crossSectionSlab + " [m]");





                //Calculating total load
                deadLoadSlab = BuildingResults.CalculateSlabDeadLoad(material, crossSectionSlab);
                totalLoad = liveLoad + deadLoadSlab + addDeadLoad;

                RhinoApp.WriteLine($"Load: Live Load {liveLoad} kN/m2; Dead Load Slab {deadLoadSlab} kN/m2; Dead Load {addDeadLoad} kN/m2;"); 



                //----------------------------------------------------------------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------------------------------------------------
                //CREATES THE GRID 2D FOR ALL SLABS
                //Iteration variable i corresponds to the storey
                //----------------------------------------------------------------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------------------------------------------------
                

                Rhino.Geometry.Transform xTrans = Rhino.Geometry.Transform.Translation(0, 0, actFloorHeight);

                for (int i = 0; i < slabs.Count; i++)
                {
                    bBox.Transform(xTrans);
                    xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                    yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

                    secondaryBeamLines = StructGrid.SecondaryBeams(bBox, actXSpac, actYSpac, yGridLines, xGridLines, beamDistance, docform);


                    //for (int j = 0; j < secondaryBeamLines.Count; j++)
                    //{
                    //    docform.Objects.AddLine(secondaryBeamLines[j]);
                    //}








                    //These int lines are only for Column creation
                    RhinoList<Rhino.Geometry.Line> xIntLinesOutCol = StructGrid.XIntLines(xGridLines, slabEdgeCurves[i], docform);
                    RhinoList<Rhino.Geometry.Line> yIntLinesOutCol = StructGrid.YIntLines(yGridLines, slabEdgeCurves[i], docform);



                    if (structSystem == "Beam" )
                    {
                        if (primaryDir == "YDir")
                        {
                            xGridLines.AddRange(secondaryBeamLines);
                        }
                        else
                        {
                            yGridLines.AddRange(secondaryBeamLines);
                        }
                    }

                    RhinoList<Rhino.Geometry.Line> xIntLines = StructGrid.XIntLines(xGridLines, slabEdgeCurves[i], docform);

                    RhinoList<Rhino.Geometry.Line> yIntLines = StructGrid.YIntLines(yGridLines, slabEdgeCurves[i], docform);





                    //if (primaryDir == "YDir")
                    //{
                    //    for (int j = 0; j < xIntLines.Count; j++)
                    //    {
                    //        docform.Objects.AddLine(xIntLines[j]);
                    //    }
                    //}
                    //else
                    //{
                    //    for (int j = 0; j < yIntLines.Count; j++)
                    //    {
                    //        docform.Objects.AddLine(yIntLines[j]);
                    //    }
                    //}



                    //Pimary Direction is YDir
                    //xBeams as SingleSpanBeams, yBeams as ContinousBeams
                    if (actXSpac < actYSpac)
                    {
                        List<Rhino.Geometry.Line> xBeamsIt = StructGrid.YBeams(xIntLines, yIntLines, docform);
                        for (int j = 0; j < xBeamsIt.Count; j++)
                        {

                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xBeamsIt[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideCores(cores, intersectedLines[k], docform) && MyFunctions.IsLineInsideBuilding(brep, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(xBeamsIt[j]);
                                    Beam xBeam = new Beam(lineCurve, "Secondary", i, totalLoad, actYSpac, 0);
                                    beamsInXDir.Add(xBeam);

                                    xBeams.Add(intersectedLines[k]);
                                }
                            }
                        }

                        for (int j = 0; j < yIntLines.Count; j++)
                        {
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yIntLines[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideCores(cores, intersectedLines[k], docform) && MyFunctions.IsLineInsideBuilding(brep, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(yIntLines[j]);
                                    Beam yBeam = new Beam(lineCurve, "Primary", i, totalLoad, actXSpac, 0);
                                    beamsInYDir.Add(yBeam);

                                    yBeams.Add(intersectedLines[k]);
                                }
                            }
                        }

                        //InnerColumns
                        List<Rhino.Geometry.Line> innerColumnsIt = StructGrid.InnerColumns(xIntLinesOutCol, yIntLinesOutCol, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            if (!MyFunctions.IsLineInsideCores(cores, innerColumnsIt[j], docform))
                            {
                                LineCurve lineCurve = new LineCurve(innerColumnsIt[j]);
                                Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                                col.Area = PreDim.Column(material, col.Load, col.Length);
                                innerCol.Add(col);

                                innerColumns.Add(innerColumnsIt[j]);
                            }
                        }
                    }

                    //Pimary Direction is XDir
                    //xBeams as ContinousBeams, yBeams as SingleSpanBeams
                    else
                    {
                        for (int j = 0; j < xIntLines.Count; j++)
                        {
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xIntLines[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideCores(cores, intersectedLines[k], docform) && MyFunctions.IsLineInsideBuilding(brep, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(intersectedLines[k]);
                                    Beam xBeam = new Beam(lineCurve, "Primary", i, totalLoad, actXSpac, 0);
                                    beamsInXDir.Add(xBeam);

                                    xBeams.Add(intersectedLines[k]);
                                }
                            }
                        }


                        List<Rhino.Geometry.Line> yBeamsIt = StructGrid.YBeams(yIntLines, xIntLines, docform);
                        for (int j = 0; j < yBeamsIt.Count; j++)
                        {
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yBeamsIt[j], docform);

                            for (int k = 0; k < intersectedLines.Count; k++)
                            {
                                if (!MyFunctions.IsLineInsideCores(cores, intersectedLines[k], docform) && MyFunctions.IsLineInsideBuilding(brep, intersectedLines[k], docform))
                                {
                                    LineCurve lineCurve = new LineCurve(yBeamsIt[j]);
                                    Beam yBeam = new Beam(lineCurve, "Secondary", i, totalLoad, actYSpac, 0);
                                    beamsInYDir.Add(yBeam);

                                    yBeams.Add(intersectedLines[k]);
                                }
                            }
                        }



                        //InnerColumns
                        List<Rhino.Geometry.Line> innerColumnsIt = StructGrid.InnerColumns(yIntLinesOutCol, xIntLinesOutCol, actFloorHeight, docform);
                        for (int j = 0; j < innerColumnsIt.Count; j++)
                        {
                            if (!MyFunctions.IsLineInsideCores(cores, innerColumnsIt[j], docform))
                            {
                                LineCurve lineCurve = new LineCurve(innerColumnsIt[j]);
                                Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                                col.Area = PreDim.Column(material, col.Load, col.Length);

                                innerCol.Add(col);

                                innerColumns.Add(innerColumnsIt[j]);
                            }
                        }
                    }


                    //OuterColumns
                    List<Rhino.Geometry.Line> outerColumnsIt = StructGrid.OuterColumns(xIntLinesOutCol, yIntLinesOutCol, actFloorHeight, docform);
                    for (int j = 0; j < outerColumnsIt.Count; j++)
                    {
                        LineCurve lineCurve = new LineCurve(outerColumnsIt[j]);
                        Column col = new Column(lineCurve, i, nStorey, totalLoad/2, actXSpac, actYSpac, 0);
                        outerCol.Add(col);

                        outerColumns.Add(outerColumnsIt[j]);
                    }

                    //EdgeColumns
                    List<Rhino.Geometry.Line> edgeColumnsIt = StructGrid.EdgeColumns(slabEdgeCurves[i], actFloorHeight, docform);
                    for (int j = 0; j < edgeColumnsIt.Count; j++)
                    {
                        LineCurve lineCurve = new LineCurve(edgeColumnsIt[j]);
                        Column col = new Column(lineCurve, i, nStorey, totalLoad/2, actXSpac, actYSpac, 0);
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



                //Extracting the core walls
                RhinoList<Brep> coreBreps = buildingGeom.GetCoreWalls(cores, slabs, docform);


                #region REGION: Adding to RhinoDoc 

                //Adds the elements to the Rhino Document
                //--------------------------------------------------------------------------------------

                Layer layerPrimaryBeams = MyFunctions.SetLayer(docform, "PrimaryBeams", System.Drawing.Color.Salmon);
                layers.Add(layerPrimaryBeams);

                if (StructGrid.HasPrimBeam(material, structSystem))
                {
                    if (primaryDir == "XDir")
                    {
                        for (int i = 0; i < xBeams.Count; i++)
                        {
                            docform.Objects.AddLine(xBeams[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < yBeams.Count; i++)
                        {
                            docform.Objects.AddLine(yBeams[i]);
                        }
                    }
                }


                Layer layerSecondaryBeams = MyFunctions.SetLayer(docform, "SecondaryBeams", System.Drawing.Color.Salmon);
                layers.Add(layerSecondaryBeams);

                if (StructGrid.HasSecBeam(material, structSystem))
                {
                    if (primaryDir != "XDir")
                    {
                        for (int i = 0; i < xBeams.Count; i++)
                        {
                            docform.Objects.AddLine(xBeams[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < yBeams.Count; i++)
                        {
                            docform.Objects.AddLine(yBeams[i]);
                        }
                    }
                }


                Layer layerEdgeBeams = MyFunctions.SetLayer(docform, "SecondaryBeams", System.Drawing.Color.Tomato);
                layers.Add(layerEdgeBeams);

                if (material != "Concrete" && structSystem != "Plate")
                {
                    for (int i = 0; i < edgeBeams.Count; i++)
                    {
                        docform.Objects.AddCurve(edgeBeams[i]);
                    }
                }


                Layer layerOuterColumn = MyFunctions.SetLayer(docform, "OuterColumn", System.Drawing.Color.Cyan);
                layers.Add(layerOuterColumn);

                for (int i = 0; i < outerColumns.Count; i++)
                {
                    docform.Objects.AddLine(outerColumns[i]);
                }

                for (int i = 0; i < edgeColumns.Count; i++)
                {
                    docform.Objects.AddLine(edgeColumns[i]);
                }

                Layer layerInnerColumns = MyFunctions.SetLayer(docform, "InnerColumns", System.Drawing.Color.LightSkyBlue);
                layers.Add(layerInnerColumns);

                for (int i = 0; i < innerColumns.Count; i++)
                {
                    docform.Objects.AddLine(innerColumns[i]);
                }

                //for (int i = 0; i < slabs.Count; i++)
                //{
                //    docform.Objects.AddBrep(slabs[i]);
                //}

                //for (int i = 0; i < slabEdgeCurves.Count; i++)
                //{
                //    docform.Objects.AddCurve(slabEdgeCurves[i]);
                //}

                Layer layerFloorSlabs = MyFunctions.SetLayer(docform, "FloorSlabs", System.Drawing.Color.DarkSeaGreen);
                layers.Add(layerFloorSlabs);

                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    docform.Objects.AddBrep(floorSlabs[i]);
                }

                Layer layerCoreWalls = MyFunctions.SetLayer(docform, "CoreWalls", System.Drawing.Color.DarkKhaki);
                layers.Add(layerCoreWalls);

                for (int i = 0; i < coreBreps.Count; i++)
                {
                    docform.Objects.AddBrep(coreBreps[i]);
                }

                //for (int i = 0; i < beamsInXDir.Count; i++)
                //{
                //    docform.Objects.AddCurve(beamsInXDir[i].ToNurbsCurve());
                //}

                //for (int i = 0; i < beamsInYDir.Count; i++)
                //{
                //    docform.Objects.AddCurve(beamsInYDir[i].ToNurbsCurve());
                //}

                #endregion



                //Hide selected objects (building geometry and cores) to visualize the structure
                //-----------------------------------------------------------------------------------------------------------------

                for (int i = 0; i < ids.Count; i++)
                {
                    RhinoDoc.ActiveDoc.Objects.Hide(ids[i], true);
                }


                #region Region Text-Dots

                //Creating TextDots with some member data
                //-----------------------------------------------------------------------------------------------------------------

                ////Innercolumn
                //MyFunctions.SetLayer(docform, "InnerColumnLoad", System.Drawing.Color.Beige);

                //for (int i = 0; i < innerCol.Count; i++)
                //{
                //    var textDot = new TextDot(Convert.ToInt32(innerCol[i].Load).ToString(), innerCol[i].LineCurve.PointAt(0.5));
                //    docform.Objects.AddTextDot(textDot);
                //}

                //MyFunctions.SetLayer(docform, "InnerColumnArea", System.Drawing.Color.Beige);

                //for (int i = 0; i < innerCol.Count; i++)
                //{
                //    var textDot = new TextDot(Math.Round(innerCol[i].Area, 2).ToString(), innerCol[i].LineCurve.PointAt(0.5));
                //    docform.Objects.AddTextDot(textDot);
                //}

                ////Slabs
                //MyFunctions.SetLayer(docform, "SlabCrossSection", System.Drawing.Color.Beige);

                //for (int i = 0; i < slabsSlabs.Count; i++)
                //{
                //    var textDot = new TextDot(Math.Round(slabsSlabs[i].Height, 2).ToString(), slabsSlabs[i].GetBoundingBox(true).Center);
                //    docform.Objects.AddTextDot(textDot);
                //}

                #endregion



                //Setting view to rendered
                //------------------------------------------------------------------------------------------

                Rhino.Display.DisplayModeDescription rendered = Rhino.Display.DisplayModeDescription.FindByName("Rendered");
                Rhino.RhinoDoc.ActiveDoc.Views.ActiveView.ActiveViewport.DisplayMode = rendered;



                //Deleting all outer beams

                if (xBeams != null)
                {
                    for (int i = 0; i < xBeams.Count; i++)
                    {
                        if (MyFunctions.IsLineInsideBuilding(brep, xBeams[i], docform))
                        {
                            xBeams.Remove(xBeams[i]);
                            beamsInXDir.Remove(beamsInXDir[i]);
                        }
                    }
                }

                if (yBeams != null)
                {
                    for (int i = 0; i < yBeams.Count; i++)
                    {
                        if (MyFunctions.IsLineInsideBuilding(brep, yBeams[i], docform))
                        {
                            yBeams.Remove(yBeams[i]);
                            beamsInYDir.Remove(beamsInYDir[i]);
                        }
                    }
                }




                #region Region Predimensioning

                //Predimensioning
                //------------------------------------------------------------------------------------------

                //Foundations - ground slab 
                double crossSectionGroundSlab = PreDim.GroundSlab(buildingGeom.BuildingHeight(brep), nStorey);

                //Core walls
                double crossSectionCoreWall = PreDim.CoreWalls();

                //Primary Beams
                if (StructGrid.HasPrimBeam(material, structSystem))     //Checks if the structure has primary beams 
                {
                    if (primaryDir == "XDir")                            //Primary beams are in x-Direction 
                    {
                        for (int i = 0; i < beamsInXDir.Count; i++)
                        {
                            beamsInXDir[i].Area = PreDim.Beam(material, beamsInXDir[i].Load, actXSpac, actYSpac, concretePlateHeight);
                        }
                    }
                    else                                                //Primary beams are in y-Direction 
                        for (int i = 0; i < beamsInYDir.Count; i++)
                        {
                            beamsInYDir[i].Area = PreDim.Beam(material, beamsInYDir[i].Load, actYSpac, actXSpac, concretePlateHeight);
                        }
                }

                //Secondary Beams
                if (StructGrid.HasSecBeam(material, structSystem))
                {
                    if (primaryDir == "XDir")                           //Secondary beams are in y-Direction 
                    {
                        for (int i = 0; i < beamsInYDir.Count; i++)
                        {
                            beamsInYDir[i].Area = PreDim.Beam(material, beamsInYDir[i].Load, actYSpac, beamDistance, concretePlateHeight);
                        }
                    }
                    else                                               //Primary beams are in x-Direction 
                        for (int i = 0; i < beamsInXDir.Count; i++)
                        {
                            beamsInXDir[i].Area = PreDim.Beam(material, beamsInXDir[i].Load, actXSpac, beamDistance, concretePlateHeight);
                        }
                }

                RhinoApp.WriteLine($"Member Dimensions: Slab Dimension - {crossSectionSlab} m; Floor Plate Dimension - {crossSectionGroundSlab} m; " +
                                   $"Inner-Column Dimension (base floor) - {innerCol[1].Area} m2; Outer-Column Dimension (base floor) - { innerCol[1].Area} m2; " +
                                   $"X-Beam Dimension - {beamsInXDir[1].Area} m2; Y-Beam Dimension - { beamsInYDir[1].Area} m2");

                #endregion


                #region Region Massing

                //Massing -> Volume in m3
                //-------------------------------------------------------------------------------------------

                double slabMass = 0;
                double innerColMass = 0;
                double outerColMass = 0;
                double edgeColMass = 0;
                double beamMass = 0;
                double foundationMass = 0;
                double coreMass = 0;

                for (int i = 0; i < floorSlabs.Count; i++)
                {
                    double area = floorSlabs[i].GetArea();
                    surfaceArea = surfaceArea + area;
                }
                surfaceArea = Math.Round(surfaceArea, 0);

                slabMass = surfaceArea * crossSectionSlab;

                for (int i = 0; i < innerCol.Count; i++)
                {
                    innerColMass = innerColMass + (innerCol[i].Area * innerCol[i].Length);
                }

                for (int i = 0; i < outerCol.Count; i++)
                {
                    outerColMass = outerColMass + outerCol[i].Area * outerCol[i].Length;
                }

                for (int i = 0; i < edgeCol.Count; i++)
                {
                    edgeColMass = edgeColMass + edgeCol[i].Area * edgeCol[i].Length;
                }
                double colMass = innerColMass + outerColMass + edgeColMass;

                for (int i = 0; i < beamsInXDir.Count; i++)
                {
                    beamMass = beamMass + beamsInXDir[i].Area * beamsInXDir[i].Length;
                }

                for (int i = 0; i < beamsInYDir.Count; i++)
                {
                    beamMass = beamMass + beamsInYDir[i].Area * beamsInYDir[i].Length;
                }

                double coreArea = 0;
                for (int i = 0; i < coreBreps.Count; i++)
                {
                    double area = coreBreps[i].GetArea();
                    coreArea = coreArea + area;
                }
                coreMass = coreArea * crossSectionCoreWall;

                foundationMass = baseSrf.GetArea() * crossSectionGroundSlab;


                RhinoApp.WriteLine($"Building Massings: CoreArea - {Math.Round(coreArea, 1)} m2; CoreMass - {Math.Round(coreMass, 1)} m3; SlabMass - {Math.Round(slabMass, 1)} m3; " +
                                   $"ColumnsMass - {Math.Round(colMass, 1)} m3; BeamsMass - {Math.Round(beamMass, 1)} m3");

                //Reinforcement calculation
                double[] reinfMass = BuildingResults.CalculateReinforcement(slabMass, colMass, beamMass, coreMass, foundationMass, material);
                double[] reinfCarbon = LCACalculation.CalculateReinforcementLCA(reinfMass, material);

                #endregion



                //Carbon calculation
                //------------------------------------------------------------------------------------------------------------------------------------------------------

                valueEmbodiedCO2Slabs.Value = Math.Round((LCACalculation.CalculateLCA(slabMass, material) + reinfCarbon[0]), 0);
                valueEmbodiedCO2Col.Value = Math.Round((LCACalculation.CalculateLCA(colMass, material) + reinfCarbon[1]), 0);
                valueEmbodiedCO2Beams.Value = Math.Round(LCACalculation.CalculateLCA(beamMass, material), 0);

                valueEmbodiedCO2Cores.Value = Math.Round((LCACalculation.CalculateLCA(coreMass, material) + reinfCarbon[3]), 0);
                valueEmbodiedCO2Foundations.Value = Math.Round((LCACalculation.CalculateLCA(foundationMass, material) + reinfCarbon[4]), 0);

                embodiedCO2Total = valueEmbodiedCO2Slabs.Value + valueEmbodiedCO2Col.Value + valueEmbodiedCO2Beams.Value + 
                                   valueEmbodiedCO2Foundations.Value + valueEmbodiedCO2Cores.Value;

                

                RhinoApp.WriteLine($"Reinforcement Mass: Slabs - {Math.Round(reinfMass[0]), 1} m3; Columns - {Math.Round(reinfMass[1], 1)} m3; Beams - {Math.Round(reinfMass[2], 1)} m3; Cores - {Math.Round(reinfMass[3], 1)} m3; Foundations - {Math.Round(reinfMass[4], 1)} m3");
                RhinoApp.WriteLine($"Reinforcement Carbon: Slabs - {Math.Round(reinfCarbon[0], 0)} kg; Columns - {Math.Round(reinfCarbon[1], 0)} kg; Beams - {Math.Round(reinfCarbon[2], 0)} kg; Cores - {Math.Round(reinfCarbon[3], 0)} kg; Foundations - {Math.Round(reinfCarbon[4], 0)} kg");



                //Weight calculation
                //------------------------------------------------------------------------------------------------------------------------------------------------------

                double totalWeight =   Math.Round((BuildingResults.CalculateWeight(slabMass, material ) + BuildingResults.CalculateWeight(colMass, material) + BuildingResults.CalculateWeight(beamMass, material) +
                                       BuildingResults.CalculateWeight(coreMass, material) + BuildingResults.CalculateWeight(foundationMass, material)), 0);




                //Prompting the results to the dashboard
                //-------------------------------------------------------------------------------------------

                TextBlockBuildingPropsTitle.Text = "Building Dimensions";

                TextBlockBuildingProps.Text = $"Height: {buildingGeom.BuildingHeight(brep)} m" + System.Environment.NewLine +
                                              $"Length: {buildingGeom.BuildingLength(brep)} m" + System.Environment.NewLine +
                                              $"Width: {buildingGeom.BuildingWidth(brep)} m" + System.Environment.NewLine +
                                              $"Volume: {volume} m" + ("\u00B3") + System.Environment.NewLine +
                                              $"Cores: {coreCount}";

                TextBlockLoadPropsTitle.Text = "Load";


                TextBlockLoadProps.Text = $"EG: {deadLoadSlab}  kN/m" + ("\u00B2") + System.Environment.NewLine +
                                          $"g"+ ("\u2096") + $": {addDeadLoad}  kN/m" + ("\u00B2") + System.Environment.NewLine +
                                          $"q" + ("\u2096") + $": {liveLoad}  kN/m" + ("\u00B2");


                TextBlockSurfaceAreaValue.Text = surfaceArea.ToString() + "  m" + ("\u00B2");
                TextBlockFarValue.Text = Math.Round(baseSrf.GetArea() / surfaceArea, 2).ToString();
                TextBlockClearFloorHeightValue.Text = (actFloorHeight - slabsSlabs[1].Height).ToString() + "  m";
                TextBlockWeightValue.Text = totalWeight.ToString() + " t";
                TextBlockEmbodiedCO2Value.Text = embodiedCO2Total.ToString() + "  kg CO" + ("\u2082") + "e";



                //Saving variant
                //------------------------------------------------------------------------------------------------------------------------------------------------------
                buildingVariant = new BuildingVariant(brep, material, MyFunctions.EvaluateSystem(material, structSystem), embodiedCO2Total, actXSpac, actYSpac, 5210198, surfaceArea, totalWeight);

                //RhinoApp.WriteLine(buildingVariant.ToTextFile());
                //RhinoApp.WriteLine(buildingVariant.ToTextFile1());

            }
        }


        private void ButtonSelectBuilding_Click(object sender, RoutedEventArgs e)
        {
            ObjRef objRef = MyFunctions.SelectBuildingGeometry(brep);

            brep = objRef.Brep();
            ids.Add(objRef.ObjectId);
        }


        private void ButtonSelectCores_Click(object sender, RoutedEventArgs e)
        {
            List<ObjRef> objRefs = MyFunctions.SelectCores();

            for (int i = 0; i < objRefs.Count; i++)
            {
                cores.Add(objRefs[i].Brep());
                ids.Add(objRefs[i].ObjectId);
            }
        }



        private void RadioButtonInstructions_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new Views.SampleCsWpfDialog();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            var dialogInstructions = new Views.InstructionsView();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            new System.Windows.Interop.WindowInteropHelper(dialogInstructions).Owner = Rhino.RhinoApp.MainWindowHandle();
            WindowInteropHelper wih = new WindowInteropHelper(dialogInstructions);
            wih.Owner = Rhino.RhinoApp.MainWindowHandle();
            dialogInstructions.Show();
        }



        private void ButtonSaveVariant_Click(object sender, RoutedEventArgs e)
        {
            //BuildingVariant variant = new BuildingVariant(brep, 1, material, "Plate", 1000000, actXSpac, actYSpac, 51000000, surfaceArea, 34000000);
            //buildingVariant.DefinedStructSystem = MyFunctions.EvaluateSystem(material, structSystem);
            buildingVariants.Add(buildingVariant);


            //Writing in Textfile
            //-----------------------------------------------------------------------------------------------------------------------------------------
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            string variantInfo = buildingVariant.ToTextFile();

            lines.Add(variantInfo);
            File.WriteAllLines(filePath, lines);

            RhinoApp.WriteLine(variantInfo);


            ////Reset all variables for the next variant
            //valueEmbodiedCO2Slabs.Value = 0;
            //valueEmbodiedCO2Col.Value = 0;
            //valueEmbodiedCO2Beams.Value = 0;
            //valueEmbodiedCO2Foundations.Value = 0;
            //valueEmbodiedCO2Cores.Value = 0;

            //embodiedCO2Total = 0;
            //surfaceArea = 0;
            //far = 0;
        }


        private void ButtonClearValues_Click(object sender, RoutedEventArgs e)
        {
            //Reset the dashboard
            //-----------------------------------------------------------------------------------------------------------------
            TextBlockBuildingPropsTitle.Text = "";
            TextBlockBuildingProps.Text = "";

            TextBlockLoadPropsTitle.Text = "";
            TextBlockLoadProps.Text = "";

            TextBlockClearFloorHeightValue.Text = "-";
            TextBlockCostsValue.Text = "-";
            TextBlockEmbodiedCO2Value.Text = "-";
            TextBlockFarValue.Text = "-";
            TextBlockSurfaceAreaValue.Text = "-";
            TextBlockWeightValue.Text = "-";


            valueEmbodiedCO2Slabs.Value = 0;
            valueEmbodiedCO2Col.Value = 0;
            valueEmbodiedCO2Beams.Value = 0;
            valueEmbodiedCO2Foundations.Value = 0;
            valueEmbodiedCO2Cores.Value = 0;

            embodiedCO2Total = 0;
            surfaceArea = 0;
            far = 0;


            //Clear all layers and lists
            //-----------------------------------------------------------------------------------------------------------------

            Layer layerDefault = MyFunctions.SetLayer(docform, "DefaultLayer", System.Drawing.Color.Black);

            for (int i = 0; i < layers.Count; i++)
            {
                RhinoDoc.ActiveDoc.Layers.Purge(layers[i].Id, true);
            }


            //Show selected objects (building geometry and cores) back to normal
            //-----------------------------------------------------------------------------------------------------------------

            for (int i = 0; i < ids.Count; i++)
            {
                RhinoDoc.ActiveDoc.Objects.Show(ids[i], true);
            }


            //Show selected objects (building geometry and cores) back to normal
            //-----------------------------------------------------------------------------------------------------------------

            Rhino.Display.DisplayModeDescription wireframe = Rhino.Display.DisplayModeDescription.FindByName("Wireframe");
            Rhino.RhinoDoc.ActiveDoc.Views.ActiveView.ActiveViewport.DisplayMode = wireframe;
        }

        private void ButtonCompareVariants_Click(object sender, RoutedEventArgs e)
        {
            //Open window
            //-------------------------------------------------------------------------------------------------------------

            //var dialog = new Views.SampleCsWpfDialog();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            var dialogCompare = new Views.CompareVariantsView();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            new System.Windows.Interop.WindowInteropHelper(dialogCompare).Owner = Rhino.RhinoApp.MainWindowHandle();
            WindowInteropHelper wih = new WindowInteropHelper(dialogCompare);
            wih.Owner = Rhino.RhinoApp.MainWindowHandle();
            dialogCompare.Show();
        }




        #region REGION: Checked status of different Material Buttons
        private void RadioButtonSteelMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Steel";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);

            SliderXSpac.Maximum = 8.1;
            SliderYSpac.Maximum = 8.1;

            RadioButtonPlateSystem.Content = "Slim Floor";
            RadioButtonBeamSystem.Content = "Composite Beams";
        }

        private void RadioButtonConcreteMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Concrete";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);

            SliderXSpac.Maximum = 8.1;
            SliderYSpac.Maximum = 8.1;

            RadioButtonPlateSystem.Content = "Flat Slab";
            RadioButtonBeamSystem.Content = "Precast T-Beams";
        }

        private void RadioButtonTimberMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Timber";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);

            SliderXSpac.Maximum = 6.9;
            SliderYSpac.Maximum = 6.9;

            RadioButtonPlateSystem.Content = "CLT Slab";
            RadioButtonBeamSystem.Content = "Timber Joists";
        }

        private void RadioButtonCompositeMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Composite";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);

            SliderXSpac.Maximum = 8.1;
            SliderYSpac.Maximum = 8.1;

            RadioButtonPlateSystem.Content = "HBV Slab";
            RadioButtonBeamSystem.Content = "CLT on Steelframe";
        }
        #endregion




        private void RadioButtonBeamSystem_Checked(object sender, RoutedEventArgs e)
        {
            structSystem = "Beam";
            string infoStructSyst = String.Format($"Selected {structSystem} Sytem as structural system");
            RhinoApp.WriteLine(infoStructSyst);
        }


        private void RadioButtonPlateSystem_Checked(object sender, RoutedEventArgs e)
        {
            structSystem = "Plate";
            string infoStructSyst = String.Format($"Selected {structSystem} Sytem as structural system");
            RhinoApp.WriteLine(infoStructSyst);
        }


        private void ButtonRFEM_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "BuildingVariants.txt";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);

            RhinoApp.WriteLine(path);
        }


        #region REGION: Update sliders
        private void SliderLoad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderLoadValue != null)
            {
                SliderLoadValue.Text = Math.Round(SliderLoad.Value, 1).ToString() + " kN/m²";
            }
        }

        private void SliderFloorHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderFloorHeightValue != null)
            {
                SliderFloorHeightValue.Text = Math.Round(SliderFloorHeight.Value, 2).ToString() + " m";
            }
        }

        private void SliderXSpac_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderXSpacValue != null)
            {
                SliderXSpacValue.Text = Math.Round(SliderXSpac.Value, 2).ToString() + " m";
            }
        }

        private void SliderYSpac_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderYSpacValue != null)
            {
                SliderYSpacValue.Text = Math.Round(SliderYSpac.Value, 2).ToString() + " m";
            }
        }

        private void SliderDistance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderDistanceValue != null)
            {
                SliderDistanceValue.Text = Math.Round(SliderDistance.Value, 2).ToString() + " m";
            }
        }
        #endregion




        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
