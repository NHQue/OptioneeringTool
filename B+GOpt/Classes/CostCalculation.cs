using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    class CostCalculation
    {
        //Cost values
        //
        //CHECK UNITS!!!!!!!!!!!!!!
        //------------------------------------------------------------------------
        //Steel
        private static readonly double costReinforcBars = 1.55;             //EUR per kg
        private static readonly double costSteel_S355 = 2.8;                //EUR per kg
        private static readonly double costPlatedSect;
        private static readonly double costGalvProfiledSheet;

        //Concrete
        private static readonly double costC30_37 = 170;                      //EUR per m3
        private static readonly double costFormwork = 42;                     //EUR per m2
        //double C30_37_CEMI;
        //double C30_37_CEMII_A_V;
        //double C30_37_CEMII_B_V;
        //double C30_37_CEMIV_B_V;
        //double C30_37_CEMII_B_S;
        //double C30_37_CEMIII_A;
        //double C30_37_CEMIII_B;

        //Timber 
        private static readonly double costSoftwood;                            //EUR per m3
        private static readonly double costClt = 600;                           //EUR per m3
        private static readonly double costGlulam = 800;                        //EUR per m3
        private static readonly double costPlywood;



        //Methods
        //------------------------------------------------------------------------


        public static double CalculateCost(double mass, string material)
        {
            double costs = 0;

            if (material == "Concrete")
            {
                costs = mass * costC30_37;
            }
            else if (material == "Timber")
            {
                costs = mass * costClt;
            }
            else if (material == "Steel")
            {
                costs = mass * costSteel_S355;
            }
            else if (material == "Reinforcement")
            {
                costs = mass * costReinforcBars;
            }
            else
                RhinoApp.WriteLine("Error: No material selected!");

            return costs;
        }
    }
}
