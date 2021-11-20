using Rhino;
using Rhino.Collections;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class BaseGrid
    {
        struct Grid
        {
            RhinoList<Line> xGridLines;
            RhinoList<Line> yGridLines;
        }




        public static void GridLines(BoundingBox bbox, int divNrX, int divNrY, double actXSpac, double actYSpac, RhinoDoc doc)
        {


            RhinoList<Line> xGridLines;
            RhinoList<Line> yGridLines;

            if (actXSpac < actYSpac)    //-> Main girders in y-Direction
            {

            }
            



        }


        public static double GetSecondarySpacing(string material, string system)
        {
            double spacing = 1;

            if (material == "Timber" && system == "Beam")
                spacing = 0.65;
            else if (material == "Timber" && system == "Plate")
                spacing = 0.65;
            else if (material == "Steel" && system == "Beam")
                spacing = 0.65;
            else if (material == "Steel" && system == "Beam")
                spacing = 0.65;
            else if (material == "Steel" && system == "Beam")
                spacing = 0.65;
            else if (material == "Steel" && system == "Beam")
                spacing = 0.65;



            return spacing; 
        }



    }
}
