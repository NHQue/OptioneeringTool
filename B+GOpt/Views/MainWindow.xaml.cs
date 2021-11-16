using System;
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

namespace B_GOpt.Views 
{
    /// <summary>
    /// Interaction logic for SampleCsWpfDialog.xaml
    /// </summary>
    public partial class MainWindow
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

        public double actXSpac;
        public double actYSpac; 


        List<BuildingVariant> variants = new List<BuildingVariant>();



        public MainWindow(RhinoDoc doc)
        {
            InitializeComponent();

            docform = doc;

            string projecName = RhinoDoc.ActiveDoc.Name;

            TextBlockProject.Text = "Project: " + projecName.Substring(projecName.Length - 3); 



            //SeriesCollection = new SeriesCollection
            //{
            //    new PieSeries
            //    {
            //        Title = "Concrete",
            //        Values = new ChartValues<ObservableValue> {new ObservableValue(10)},
            //        DataLabels = true,
            //        Fill = new SolidColorBrush(Colors.DarkSeaGreen)
            //    },
            //    new PieSeries
            //    {
            //        Title = "Steel",
            //        Values = new ChartValues<ObservableValue> {new ObservableValue(20)},
            //        DataLabels = true,
            //        Fill = new SolidColorBrush(Colors.LightSkyBlue)
            //    },
            //    new PieSeries
            //    {
            //        Title = "Reinforcement",
            //        Values = new ChartValues<ObservableValue> {new ObservableValue(30)},
            //        DataLabels = true,
            //        Fill = new SolidColorBrush(Colors.Lavender)
            //    },
            //    new PieSeries
            //    {
            //        Title = "Timber",
            //        Values = new ChartValues<ObservableValue> {new ObservableValue(18)},
            //        DataLabels = true,
            //        Fill = new SolidColorBrush(Colors.Peru)
            //    },
            //};


            //DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("Current value: " + chartPoint.Y + "(" + (chartPoint.Participation * 100).ToString() + "%)");
        }






        private void sliderLoad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderLoadValue != null)
            {
                sliderLoadValue.Text = Math.Round(sliderLoad.Value, 2).ToString() + " kN/m²";
            }
        }

        private void sliderFloorHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderFloorHeightValue != null)
            {
                sliderFloorHeightValue.Text = Math.Round(sliderFloorHeight.Value, 2).ToString() + " m";
            }
        }

        private void sliderXSpac_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderXSpacValue != null)
            {
                sliderXSpacValue.Text = Math.Round(sliderXSpac.Value, 2).ToString() + " m";
            }
        }

        private void sliderYSpac_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderYSpacValue != null)
            {
                sliderYSpacValue.Text = Math.Round(sliderYSpac.Value, 2).ToString() + " m";
            }
        }

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



            //Prompt results
            //-------------------------------------------------------------------------------------------------------------

             







        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {

            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                string volume = Math.Round(VolumeMassProperties.Compute(brep).Volume, 0).ToString();

                int coreCount = cores.Count;

                TextBlockBuildingPropsTitle.Text = "Building Dimensions";

                TextBlockBuildingProps.Text =   $"Height: {buildingGeom.BuildingHeight(brep)} m" + System.Environment.NewLine +
                                                $"Length: {buildingGeom.BuildingLength(brep)} m" + System.Environment.NewLine +
                                                $"Width: {buildingGeom.BuildingWidth(brep)} m" + System.Environment.NewLine +
                                                $"Volume: {volume} m" + ("\u00B3") + System.Environment.NewLine +
                                                $"Cores: {coreCount}";


                //double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueFloorHeight = sliderFloorHeight.Value;
                double valueSpacX = sliderXSpac.Value;
                double valueSpacY = sliderYSpac.Value;

                double actFloorHeight = buildingGeom.FloorHeight(brep, valueFloorHeight);
                actXSpac = buildingGeom.ActualXSpacing(brep, valueSpacX);
                actYSpac = buildingGeom.ActualXSpacing(brep, valueSpacY);

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

                RhinoList<Rhino.Geometry.Line> xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                RhinoList<Rhino.Geometry.Line> yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

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
                Rhino.Geometry.Transform xTrans = Rhino.Geometry.Transform.Translation(0, 0, actFloorHeight);

                for (int i = 0; i < slabs.Count; i++)
                {
                    bBox.Transform(xTrans);
                    xGridLines = StructGrid.XGridLines(bBox, nspacY, docform);
                    yGridLines = StructGrid.YGridLines(bBox, nspacX, docform);

                    RhinoList<Rhino.Geometry.Line> xIntLines = StructGrid.XIntLines(xGridLines, slabEdgeCurves[i], docform);
                    RhinoList<Rhino.Geometry.Line> yIntLines = StructGrid.YIntLines(yGridLines, slabEdgeCurves[i], docform);

                    //xBeams as SingleSpanBeams, yBeams as ContinousBeams
                    if (actXSpac < actYSpac)
                    {
                        List<Rhino.Geometry.Line> xBeamsIt = StructGrid.YBeams(xIntLines, yIntLines, docform);
                        for (int j = 0; j < xBeamsIt.Count; j++)
                        {

                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xBeamsIt[j], docform);

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
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yIntLines[j], docform);

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
                        List<Rhino.Geometry.Line> innerColumnsIt = StructGrid.InnerColumns(xIntLines, yIntLines, actFloorHeight, docform);
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
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, xIntLines[j], docform);

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


                        List<Rhino.Geometry.Line> yBeamsIt = StructGrid.YBeams(yIntLines, xIntLines, docform);
                        for (int j = 0; j < yBeamsIt.Count; j++)
                        {
                            RhinoList<Rhino.Geometry.Line> intersectedLines = MyFunctions.SplitLineWithBreps(cores, yBeamsIt[j], docform);

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
                        List<Rhino.Geometry.Line> innerColumnsIt = StructGrid.InnerColumns(yIntLines, xIntLines, actFloorHeight, docform);
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
                    List<Rhino.Geometry.Line> outerColumnsIt = StructGrid.OuterColumns(xIntLines, yIntLines, actFloorHeight, docform);
                    for (int j = 0; j < outerColumnsIt.Count; j++)
                    {
                        LineCurve lineCurve = new LineCurve(outerColumnsIt[j]);
                        Column col = new Column(lineCurve, i, nStorey, totalLoad, actXSpac, actYSpac, 0);
                        outerCol.Add(col);

                        outerColumns.Add(outerColumnsIt[j]);
                    }

                    //EdgeColumns
                    List<Rhino.Geometry.Line> edgeColumnsIt = StructGrid.EdgeColumns(slabEdgeCurves[i], actFloorHeight, docform);
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
                //-----------------------------------------------------------------------------------------------------------------
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

                TextBlockSurfaceAreaValue.Text = Math.Round(surfaceArea, 0).ToString() + "  m" + ("\u00B2");
                TextBlockFarValue.Text = Math.Round(baseSrf.GetArea() / surfaceArea, 2).ToString();

                TextBlockClearFloorHeightValue.Text = (actFloorHeight - slabs1[1].Height).ToString() + "  m";

                


                //Massing
                //-------------------------------------------------------------------------------------------
                double innerColMass = 0;
                double outerColMass = 0;
                double slabsMass = 0;

                for (int i = 0; i < innerCol.Count; i++)
                {
                    innerColMass =+ innerCol[i].Area * innerCol[i].Length; 
                }

                for (int i = 0; i < outerCol.Count; i++)
                {
                    outerColMass =+ outerCol[i].Area * outerCol[i].Length;
                }

                for (int i = 0; i < slabs.Count; i++)
                {
                    slabsMass =+ slabs1[i].Height * slabs[i].GetArea();
                }

                double embodiedCO2Col = Math.Round(LCACalculation.CalculateLCA(innerColMass, material) + LCACalculation.CalculateLCA(outerColMass, material), 0); 
                double embodiedCO2Slabs = Math.Round(LCACalculation.CalculateLCA(slabsMass, material), 0);
                double embodiedCO2Beams = 0;
                double embodiedCO2Foundations = 0;
                double embodiedCO2Core = 0; 


                double embodiedCO2Total = embodiedCO2Col + embodiedCO2Slabs + embodiedCO2Beams + embodiedCO2Foundations + embodiedCO2Core;

                TextBlockEmbodiedCO2Value.Text = embodiedCO2Total.ToString() + "  kg CO" + ("\u2082") + "e";



                double totalWeight =    (BuildingResults.CalculateWeight(innerColMass, material) + BuildingResults.CalculateWeight(outerColMass, material) +
                                        BuildingResults.CalculateWeight(slabsMass, material))/10;

                TextBlockWeightValue.Text = Math.Round(totalWeight, 0).ToString() + " t";



                //Defining the Pie Chart
                //-------------------------------------------------------------------------------------------------------------------------------------------------
                SeriesCollection = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Slabs",
                        Values = new ChartValues<ObservableValue> {new ObservableValue(embodiedCO2Slabs) },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.DarkSeaGreen)
                    },
                    new PieSeries
                    {
                        Title = "Columns",
                        Values = new ChartValues<ObservableValue> {new ObservableValue(embodiedCO2Col) },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.LightSkyBlue),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Beams",
                        Values = new ChartValues<ObservableValue> {new ObservableValue(embodiedCO2Beams) },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.Lavender),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Foundations",
                        Values = new ChartValues<ObservableValue> {new ObservableValue(embodiedCO2Foundations) },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.Peru),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    },
                    new PieSeries
                    {
                        Title = "Core",
                        Values = new ChartValues<ObservableValue> {new ObservableValue(embodiedCO2Core) },
                        DataLabels = true,
                        Fill = new SolidColorBrush(Colors.DarkKhaki),
                        Foreground = new SolidColorBrush(Colors.Transparent)
                    }
                };

                DataContext = this;

            }










            



















        }

        private void ButtonSelectBuilding_Click(object sender, RoutedEventArgs e)
        {
            brep = MyFunctions.SelectBuildingGeometry(brep);
        }

        private void ButtonSelectCores_Click(object sender, RoutedEventArgs e)
        {
            cores = MyFunctions.SelectCores();
        }



        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
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
            BuildingVariant variant = new BuildingVariant(brep, 1, material, "Plate", 1000000, actXSpac, actYSpac, 51000000, surfaceArea, 34000000);
            variants.Add(variant);

        }



        private void RadioButtonSteelMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Steel";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }

        private void RadioButtonConcreteMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Concrete";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }

        private void RadioButtonTimberMat_Checked(object sender, RoutedEventArgs e)
        {
            material = "Timber";
            string infoMat = String.Format($"Selected {material} as structural material");
            RhinoApp.WriteLine(infoMat);
        }

        private void RadioButtonCompositeMat_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRFEM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClearValues_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
