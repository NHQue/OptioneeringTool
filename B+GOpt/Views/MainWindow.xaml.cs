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

namespace B_GOpt.Views 
{
    /// <summary>
    /// Interaction logic for SampleCsWpfDialog.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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


    }
}
