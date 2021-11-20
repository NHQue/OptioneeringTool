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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using B_GOpt.Classes;
using Microsoft.Win32;

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
