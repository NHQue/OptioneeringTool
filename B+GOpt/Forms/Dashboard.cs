using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Rhino;
using Rhino.Geometry;
using B_GOpt.Classes;
using Rhino.Collections;

namespace B_GOpt.Forms
{
    public partial class Form2 : KryptonForm
    {

        private RhinoDoc docform;

        private Rhino.Geometry.Brep brep = null;

        private double surfaceArea;

        //public string documentName = RhinoDoc.ActiveDoc.Name;

        

        public Form2(RhinoDoc doc)
        {
            InitializeComponent();

            docform = doc;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void tbarSpacX_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarSpacX.Value / 100f;
            lblSpacXValue.Text = value.ToString();
        }

        private void tbarSpacY_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarSpacY.Value / 100f;
            lblSpacYValue.Text = value.ToString();
        }

        private void tbarFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarFloorHeight.Value / 100f;
            lblFloorHeightValue.Text = value.ToString();
        }


        private void btnSelectBuilding_Click_1(object sender, EventArgs e)
        {
            
            brep = MyFunctions.SelectBuildingGeometry(brep);


        }

        private void btnCalculate_Click(object sender, EventArgs e) 
        {
            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueSpacX =  tbarSpacX.Value / 100f;
                double valueSpacY = tbarSpacY.Value / 100f;

                RhinoList<Brep> slabs = buildingGeom.ConstructSlabs(brep, valueFloorHeight, docform);

                surfaceArea = Math.Round(buildingGeom.SurfaceArea(slabs), 2);

                lblSurfaceAreaValue.Text = surfaceArea.ToString();

                RhinoApp.WriteLine(surfaceArea.ToString());

                RhinoList<Rhino.Geometry.Line> columns = buildingGeom.ConstructColumns(brep, valueSpacX, valueSpacY, valueFloorHeight, docform);

                buildingGeom.ConstructBeams(brep, valueSpacX, valueSpacY, valueFloorHeight, docform);
            }
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {

        }

        private void rbtnSteelMat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblSurfaceAreaValue_Click(object sender, EventArgs e)
        {
            
        }


    }
}
