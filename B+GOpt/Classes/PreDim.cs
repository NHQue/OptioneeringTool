using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class PreDim
    {

        //Some dictionaries for assigning profiles, areas, ...
        //------------------------------------------------------------------------------------------

        //IPE
        private static readonly Dictionary<int, string> IPEProfil = new Dictionary<int, string>
        {
             { 16, "IPE 160" },
             { 18, "IPE 180" },
             { 20, "IPE 200" },
             { 22, "IPE 220" },
             { 24, "IPE 240" },
             { 27, "IPE 270" },
             { 30, "IPE 300" },
             { 33, "IPE 330" },
             { 36, "IPE 360" },
             { 40, "IPE 400" },
             { 45, "IPE 450" },
             { 50, "IPE 500" },
             { 55, "IPE 550" },
             { 60, "IPE 600" }
        };

        private static readonly Dictionary<string, double> IPEArea = new Dictionary<string, double>
        {
             { "IPE 160", 20.1 },
             { "IPE 180", 23.9 },
             { "IPE 200", 28.5 },
             { "IPE 220", 33.4 },
             { "IPE 240", 39.1 },
             { "IPE 270", 45.9 },
             { "IPE 300", 53.8 },
             { "IPE 330", 62.6 },
             { "IPE 360", 72.7 },
             { "IPE 400", 84.5 },
             { "IPE 450", 98.8 },
             { "IPE 500", 116  },
             { "IPE 550", 134  },
             { "IPE 600", 156  }
        };


        //HEB
        private static readonly Dictionary<int, string> HEBProfil = new Dictionary<int, string>
        {
             { 16, "HEB 160" },
             { 18, "HEB 180" },
             { 20, "HEB 200" },
             { 22, "HEB 220" },
             { 24, "HEB 240" },
             { 26, "HEB 260" },
             { 28, "HEB 280" },
             { 30, "HEB 300" },
             { 32, "HEB 320" },
             { 34, "HEB 340" },
             { 36, "HEB 360" },
             { 40, "HEB 400" },
             { 45, "HEB 450" },
             { 50, "HEB 500" },
             { 55, "HEB 550" },
             { 60, "HEB 600" },
             { 65, "HEB 650" },
             { 70, "HEB 700" },
             { 80, "HEB 800" },
             { 90, "HEB 900" },
             { 100,"HEB 1000"}
        };

        private static readonly Dictionary<string, double> HEBArea = new Dictionary<string, double>
        {
             { "HEB 160" , 54.3 },
             { "HEB 180" , 65.3 },
             { "HEB 200" , 78.1 },
             { "HEB 220" , 91.0 },
             { "HEB 240" , 106  },
             { "HEB 260" , 118  },
             { "HEB 280" , 131  },
             { "HEB 300" , 149  },
             { "HEB 320" , 161  },
             { "HEB 340" , 171  },
             { "HEB 360" , 181  },
             { "HEB 400" , 198  },
             { "HEB 450" , 218  },
             { "HEB 500" , 239  },
             { "HEB 550" , 254  },
             { "HEB 600" , 270  },
             { "HEB 650" , 286  },
             { "HEB 700" , 306  },
             { "HEB 800" , 334  },
             { "HEB 900" , 371  },
             { "HEB 1000", 400  }
        };


        //Static Methods
        //---------------------------------------------------------------------------------------------------
        public static double ConcreteSlab(double spanX, double spanY)
        {
            double height; //m
            double spanLi = 0.8*Math.Max(spanX, spanY);

            RhinoApp.WriteLine("spanli: " + spanLi);  

            if (spanLi < 4.29)
            {
                height = spanLi / 35 + 0.03;
                if (height > 0.2)
                    return height;
                else
                {
                    height = 0.2;
                    return height;
                }
            }
            else if (spanLi > 4.29)
            {
                height = (Math.Pow(spanLi, 2))/ 150 + 0.03;
                if (height > 0.2)
                    return height;
                else
                {
                    height = 0.2;
                    return height;
                }
            }
            else
                return 0; 
        }

        public static void TimberSlab(double spanX, double spanY, double load)
        {
            double span = 0.8 * Math.Min(spanX, spanY);

            double height = 3.33 * span + 2;                                     //cm
        }


        public static void CompositeSlab(double spanX, double spanY, double load)
        {
            double heightConcrete;
            double heightTimber;


        }


        public static double SteelBeam(double load, double length)              //IPE
        {
            double height;                                                      //cm
            height = Math.Pow(50 * load * Math.Pow(length, 2), (1 / 3)) - 2;

            return height; 
        }


        public static double ConcreteColumn(double load)                        //Load in kN
        {
            double area;                                                        //cm2
            area = 0.59 * load;

            return area; 
        }

        public static double SteelColumn(double load, double length)            //HEB   //load in kN    //length in m
        {
            double height;                                                      //mm
            height = Math.Pow(16*load* length, (1/2));

            return height; 
        }

        public static double TimberColumn(double load, double length)           //load in kN    //length in m
        {
            double sideLength;                                                  //cm
            sideLength = Math.Pow(load * length, (1/2));

            return sideLength;
        }
    }
}
