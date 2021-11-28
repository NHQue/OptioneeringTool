using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using B_GOpt.Classes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using Rhino;

namespace B_GOpt.Views
{
    /// <summary>
    /// Interaction logic for CompareVariantsView.xaml
    /// </summary>
    public partial class CompareVariantsView : Window, INotifyPropertyChanged
    {

        //HeatMap
        public ChartValues<HeatPoint> HeatValues { get; set; }
        public string[] performanceIndicators { get; set; }
        public string[] variants { get; set; }




        //Score ranking
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }


        readonly string fileName = "BuildingVariants.txt";


        private void HeatMapRanking_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("Current value: " + chartPoint.Weight +  "(" + (chartPoint.SeriesView).ToString() );
        }



        public CompareVariantsView()
        {
            InitializeComponent();

            //var ModelsGroup = new Model3DGroup();
            //ModelsGroup.Children.Add(this.AddLine(new Point3D(0, 0, 100), new Point3D(0, 100, 100), "line 1)"));
            //ModelsGroup.Children.Add(new AmbientLight(Colors.White));
            //Model.Content = ModelsGroup;


            //Writing in Textfile
            //-----------------------------------------------------------------------------------------------------------------------------------------

            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            List<BuildingVariant> buildingVariants = new List<BuildingVariant>();

            foreach (string line in lines)
            {
                BuildingVariant buildingVariant = new BuildingVariant();
                string[] splittedResults = line.Split(',');

                buildingVariant.Material = splittedResults[0];
                buildingVariant.DefinedStructSystem = splittedResults[1];
                buildingVariant.ActXSpac = Convert.ToDouble(splittedResults[2]);
                buildingVariant.ActYSpac = Convert.ToDouble(splittedResults[3]);
                buildingVariant.EmbodiedCO2= Convert.ToDouble(splittedResults[4]);
                buildingVariant.Costs = Convert.ToDouble(splittedResults[5]);
                buildingVariant.SurfaceArea = Convert.ToDouble(splittedResults[6]);
                buildingVariant.Weight = Convert.ToDouble(splittedResults[7]);

                buildingVariants.Add(buildingVariant);
            }


            //Set the eight textblocks for the building variants
            #region Variant Textblock region
            if (buildingVariants.Count > 0)
            {
                TextBlockVariant1.Text = "Variant 1";
                TextBlockResultsVariant1.Text = buildingVariants[0].ToResult();
            }
            if (buildingVariants.Count > 1)
            {
                TextBlockVariant2.Text = "Variant 2";
                TextBlockResultsVariant2.Text = buildingVariants[1].ToResult();
            }
            if (buildingVariants.Count > 2)
            {
                TextBlockVariant3.Text = "Variant 3";
                TextBlockResultsVariant3.Text = buildingVariants[2].ToResult();
            }
            if (buildingVariants.Count > 3)
            {
                TextBlockVariant4.Text = "Variant 4";
                TextBlockResultsVariant4.Text = buildingVariants[3].ToResult();
            }
            if (buildingVariants.Count > 4)
            {
                TextBlockVariant5.Text = "Variant 5";
                TextBlockResultsVariant5.Text = buildingVariants[4].ToResult();
            }
            if (buildingVariants.Count > 5)
            {
                TextBlockVariant6.Text = "Variant 6";
                TextBlockResultsVariant6.Text = buildingVariants[5].ToResult();
            }
            if (buildingVariants.Count > 6)
            {
                TextBlockVariant7.Text = "Variant 7";
                TextBlockResultsVariant7.Text = buildingVariants[6].ToResult();
            }
            if (buildingVariants.Count > 7)
            {
                TextBlockVariant8.Text = "Variant 8";
                TextBlockResultsVariant8.Text = buildingVariants[7].ToResult();
            }
            #endregion



            //Creating the Heat Map
            //-----------------------------------------------------------------------------------------------------------------

            Random r = new Random();

            HeatValues = new ChartValues<HeatPoint>
            {
                //X means building variant
                //Y is the performance
 
                //"Variant 1"
                new HeatPoint(0, 0, r.Next(1, 9)),
                new HeatPoint(0, 1, r.Next(1, 9)),
                new HeatPoint(0, 2, r.Next(1, 9)),
                new HeatPoint(0, 3, r.Next(1, 9)),
 
                //"Variant 2"
                new HeatPoint(1, 0, r.Next(1, 9)),
                new HeatPoint(1, 1, r.Next(1, 9)),
                new HeatPoint(1, 2, r.Next(1, 9)),
                new HeatPoint(1, 3, r.Next(1, 9)),
 
                //"Variant 3"
                new HeatPoint(2, 0, r.Next(1, 9)),
                new HeatPoint(2, 1, r.Next(1, 9)),
                new HeatPoint(2, 2, r.Next(1, 9)),
                new HeatPoint(2, 3, r.Next(1, 9)),
 
                //"Variant 4"
                new HeatPoint(3, 0, r.Next(1, 9)),
                new HeatPoint(3, 1, r.Next(1, 9)),
                new HeatPoint(3, 2, r.Next(1, 9)),
                new HeatPoint(3, 3, r.Next(1, 9)),
 
                //"Variant 5"
                new HeatPoint(4, 0, r.Next(1, 9)),
                new HeatPoint(4, 1, r.Next(1, 9)),
                new HeatPoint(4, 2, r.Next(1, 9)),
                new HeatPoint(4, 3, r.Next(1, 9)),

                //"Variant 6"
                new HeatPoint(5, 0, r.Next(1, 9)),
                new HeatPoint(5, 1, r.Next(1, 9)),
                new HeatPoint(5, 2, r.Next(1, 9)),
                new HeatPoint(5, 3, r.Next(1, 9)),

                //"Variant 7"
                new HeatPoint(6, 0, r.Next(1, 9)),
                new HeatPoint(6, 1, r.Next(1, 9)),
                new HeatPoint(6, 2, r.Next(1, 9)),
                new HeatPoint(6, 3, r.Next(1, 9)),

                //"Variant 8"
                new HeatPoint(7, 0, r.Next(1, 9)),
                new HeatPoint(7, 1, r.Next(1, 9)),
                new HeatPoint(7, 2, r.Next(1, 9)),
                new HeatPoint(7, 3, r.Next(1, 9)),
            };

            performanceIndicators = new[]
            {
                "Area",
                "Dis. Opt.",
                "Costs",
                "Emb. CO" + ("\u2082")
            };

            variants = new[]
            {
                "Var 1",
                "Var 2",
                "Var 3",
                "Var 4",
                "Var 5",
                "Var 6",
                "Var 7",
                "Var 8"
            };




            //Score diagram

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9)),
                new ObservableValue(r.Next(1, 9))
            };

            LineSeries lineSeries = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 2,
                LineSmoothness = 0,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = false
            };

            SeriesCollection = new SeriesCollection { lineSeries };




            DataContext = this;
        }



        




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Window curWindpw = Window.GetWindow(this);                  //Passing current window context
            curWindpw?.Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //ResultsCase1.Text = variants[1].ToString();  
        }

        private void ButtonExportPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(printView, "B+G_OptioneeringTool_Variants");
                }
            }
            finally
            {
                this.IsEnabled = true;
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

        private void ButtonClearValues_Click(object sender, RoutedEventArgs e)
        {

        }




        private void SliderCosts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderCostsValue != null)
            {
                SliderCostsValue.Text = Math.Round(SliderCosts.Value, 0).ToString() + ",";

                MyValues[0].Value = 10 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[1].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[2].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[3].Value = 6 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[4].Value = 4 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[5].Value = 7 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[6].Value = 1 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[7].Value = 8 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
            }

            
        }

        private void SliderCO2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderCO2Value != null)
            {
                SliderCO2Value.Text = Math.Round(SliderCO2.Value, 0).ToString() + ",";

                MyValues[0].Value = 10 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[1].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[2].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[3].Value = 6 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[4].Value = 4 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[5].Value = 7 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[6].Value = 1 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[7].Value = 8 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
            }
        }

        private void SliderDisopt_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderDisoptValue != null)
            {
                SliderDisoptValue.Text = Math.Round(SliderDisopt.Value, 0).ToString() + ",";

                MyValues[0].Value = 10 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[1].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[2].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[3].Value = 6 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[4].Value = 4 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[5].Value = 7 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[6].Value = 1 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[7].Value = 8 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
            }
        }

        private void SliderArea_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderAreaValue != null)
            {
                SliderAreaValue.Text = Math.Round(SliderArea.Value, 0).ToString();

                MyValues[0].Value = 10 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[1].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[2].Value = 2 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[3].Value = 6 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[4].Value = 4 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[5].Value = 7 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[6].Value = 1 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
                MyValues[7].Value = 8 * SliderCosts.Value * SliderArea.Value * SliderCO2.Value * SliderDisopt.Value;
            }
        }
    }
}
