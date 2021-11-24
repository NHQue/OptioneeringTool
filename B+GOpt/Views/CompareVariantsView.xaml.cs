using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using Rhino;

namespace B_GOpt.Views
{
    /// <summary>
    /// Interaction logic for CompareVariantsView.xaml
    /// </summary>
    public partial class CompareVariantsView : Window
    {
        public CompareVariantsView()
        {
            InitializeComponent();

            //var ModelsGroup = new Model3DGroup();
            //ModelsGroup.Children.Add(this.AddLine(new Point3D(0, 0, 100), new Point3D(0, 100, 100), "line 1)"));
            //ModelsGroup.Children.Add(new AmbientLight(Colors.White));
            //Model.Content = ModelsGroup;


            //Writing in Textfile
            //-----------------------------------------------------------------------------------------------------------------------------------------
            string filePath = @"C:\Users\Niklas\Desktop\Studium\Master\M4\Thesis\Tool\OptioneeringTool\OptioneeringTool\B+GOpt\EmbeddedResources\BuildingVariants.txt";

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

    }
}
