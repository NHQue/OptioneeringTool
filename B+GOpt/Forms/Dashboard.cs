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
using Rhino.Geometry.Collections;

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

        private void tbarFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            float value = tbarFloorHeight.Value / 100f;
            lblFloorHeightValue.Text = value.ToString() + "  m";
        }


        private void btnSelectBuilding_Click_1(object sender, EventArgs e)
        {
            brep = MyFunctions.SelectBuildingGeometry(brep);
        }




        private void btnStructGrid3D_Click(object sender, EventArgs e)
        {
            if (brep != null)
            {
                BuildingGeometry buildingGeom = new BuildingGeometry(brep);

                double valueFloorHeight = tbarFloorHeight.Value / 100f;
                double valueSpacX = tbarSpacX.Value / 100f;
                double valueSpacY = tbarSpacY.Value / 100f;

                Brep baseSrf = buildingGeom.GetBaseSurface(brep, docform);

                BrepEdgeList baseSrfEdges = baseSrf.Edges;

                CurveList baseSrfEdgeCurves = new CurveList();

                for (int i = 0; i < baseSrfEdges.Count; i++)
                {
                    baseSrfEdgeCurves.Add(baseSrfEdges[i]);
                    //docform.Objects.AddCurve(baseSrfEdges[i].ToNurbsCurve()); 
                }

                Curve[] baseSrfJoinedEdgeCurves = Curve.JoinCurves(baseSrfEdgeCurves);


                //Creates the grid at baseFloor
                //MyFunctions.CreateGrid2D(baseSrfJoinedEdgeCurves[0], actXSpac, actYSpac, docform);


                double actFloorHeight = buildingGeom.FloorHeight(brep, valueFloorHeight);
                double actXSpac = buildingGeom.ActualXSpacing(brep, valueSpacX);
                double actYSpac = buildingGeom.ActualXSpacing(brep, valueSpacY);




                //Creates the slabs edge curves to use them for their own Grid 2D creation

                RhinoList<Brep> slabs = buildingGeom.ConstructSlabs(brep, actFloorHeight, docform);

                CurveList slabOuterCurves = new CurveList();

                for (int i = 0; i < slabs.Count; i++)
                {
                    BrepEdgeList slabEdges = slabs[i].Edges;
                    CurveList crvs = new CurveList();

                    for (int j= 0; j < slabEdges.Count; j++)
                    {
                        crvs.Add(slabEdges[j]);
                    }

                    Curve[] joinedEdgeCurves = Curve.JoinCurves(crvs);

                    slabOuterCurves.Add(joinedEdgeCurves[0]);
                }




                //Creates the Grid 2D for all slabs

                for (int i = 0; i < slabOuterCurves.Count; i++)
                {
                    MyFunctions.CreateGrid2D(slabOuterCurves[i], actXSpac, actYSpac, actFloorHeight, docform);
                }


                for (int i = 0; i < slabOuterCurves.Count; i++)
                {
                    docform.Objects.AddCurve(slabOuterCurves[i]);
                }



                docform.Views.Redraw();




            }



        }
    }
}
