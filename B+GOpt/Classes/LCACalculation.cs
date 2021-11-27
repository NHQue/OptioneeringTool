using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class LCACalculation
    {
        //CO2 values according to IStructE database
        //
        //CHECK UNITS!!!!!!!!!!!!!!
        //------------------------------------------------------------------------
        //Steel
        private static readonly double reinforcBars = 1.99;             //kgC02e per kg
        private static readonly double hotRolledSect = 1.55;
        private static readonly double platedSect = 2.46;
        private static readonly double galvProfiledSheet = 2.76;

        //Concrete
        private static readonly double C30_37_CEMI = 342;               //kgCO2e per m3
        private static readonly double C30_37_CEMII_A_V = 318;
        private static readonly double C30_37_CEMII_B_V = 285.6;
        private static readonly double C30_37_CEMIV_B_V = 249.6;
        private static readonly double C30_37_CEMII_B_S = 272.4;
        private static readonly double C30_37_CEMIII_A = 200.4;
        private static readonly double C30_37_CEMIII_B = 145.2;

        //Timber 
        //Excluding Carbon Storage
        private static readonly double softwoodExclCS = 110.46;           //kgCO2e per m3
        private static readonly double cltExclCS = 206.96;
        private static readonly double glulamExclCS = 225.28;
        private static readonly double plywoodExclCS = 367.74;
        //Including Carbon Storage
        private static readonly double softwoodInclCS = -510.80;           //kgCO2e per m3
        private static readonly double cltInclCS = -568.32;
        private static readonly double glulamInclCS = -396.00;
        private static readonly double plywoodInclCS = -502.20;




        //Methods
        //-------------------------------------------------------------------------------------------------

        /// <summary>
        /// This methods calculates the carbon values of the different materials 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public static double CalculateLCA(double value, string material)
        {
            if (material == "Concrete")
            {
                double embodiedCO2 = value * C30_37_CEMI;
                return embodiedCO2;
            }
            else
                return 0; 
        }



        /// <summary>
        /// This methods calculates the carbon values of the reinforcement 
        /// </summary>
        /// <param name="reinfMass"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public static double[] CalculateReinforcementLCA(double[] reinfMass, string material)
        {
            //Create array to return reinforcement carbon values
            //Index 0: Slab
            //Index 1: Column
            //Index 2: Beam
            //Index 3: Core
            //Index 4: Foundation

            double[] reinfLCAValues = new double[] { 0, 0, 0, 0, 0 };

            if (material == "Concrete")
            {
                reinfLCAValues[0] = reinfMass[0] * reinforcBars;
                reinfLCAValues[1] = reinfMass[1] * reinforcBars;
                reinfLCAValues[2] = reinfMass[2] * reinforcBars;
            }

            reinfLCAValues[3] = reinfMass[3] * reinforcBars;
            reinfLCAValues[4] = reinfMass[4] * reinforcBars;

            return reinfLCAValues;
        }
    }
}
