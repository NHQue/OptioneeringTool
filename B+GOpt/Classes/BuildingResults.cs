using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class BuildingResults
    {
        //CHECK UNITS!!!!!!!!!!!!!!



        //Densities in kN/m3
        //-----------------------------------------------------------------------------------
        private static readonly double gammaConcrete = 25;
        private static readonly double gammaSteel = 78.1;
        private static readonly double gammaClt = 3.8;


        //B+G Reinforcement ratio kg/m3
        //-----------------------------------------------------------------------------------
        private static readonly double slabReinfRatio = 140;
        private static readonly double colReinfRatio = 300;
        private static readonly double beamReinfRatio = 180;
        private static readonly double coreWallReinfRatio = 180;
        private static readonly double wallReinfRatio = 140;
        private static readonly double foundReinfRatio = 175;



        //Cost values
        //-----------------------------------------------------------------------------------

        //Steel
        private static readonly double reinforcBarsCost = 1.55;             //EUR per kg
        private static readonly double steel_S355Cost = 2.8;                //EUR per kg
        private static readonly double platedSectCost;
        private static readonly double galvProfiledSheetCost;

        //Concrete
        private static readonly double C30_37Cost = 170;                      //EUR per m3
        private static readonly double formworkCost = 42;                     //EUR per m2
        //double C30_37_CEMI;
        //double C30_37_CEMII_A_V;
        //double C30_37_CEMII_B_V;
        //double C30_37_CEMIV_B_V;
        //double C30_37_CEMII_B_S;
        //double C30_37_CEMIII_A;
        //double C30_37_CEMIII_B;

        //Timber 
        private static readonly double softwoodCost;                            //EUR per m3
        private static readonly double cltCost = 600;                           //EUR per m3
        private static readonly double glulamCost = 800;
        private static readonly double plywoodCost;



        //Methods
        //-----------------------------------------------------------------------------------

        /// <summary>
        /// This method calculates the weight of the mass of the particular building parts 
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public static double CalculateWeight(double volume, string material)
        {
            if (material == "Concrete")
            {
                double weight = volume * gammaConcrete;
                return weight / 10;                                  //return weight in t
            }
            if (material == "Steel")
            {
                double weight = volume * gammaSteel;
                return weight / 10;                                  //return weight in t
            }
            if (material == "Timber")
            {
                double weight = volume * gammaClt;
                return weight / 10;                                  //return weight in t
            }
            else
                RhinoApp.WriteLine("Error: No material selected for weight calculation!");
            return 0;
        }

        /// <summary>
        /// This method calculates the reinforcemnt of the different building parts 
        /// </summary>
        /// <param name="slabMass"></param>
        /// <param name="colbMass"></param>
        /// <param name="beamMass"></param>
        /// <param name="coreMass"></param>
        /// <param name="foundMass"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public static double[] CalculateReinforcement(double slabMass, double colbMass, double beamMass, double coreMass, double foundMass, string material)
        {
            //Create array to return reinforcement values
            //Index 0: Slab
            //Index 1: Column
            //Index 2: Beam
            //Index 3: Core
            //Index 4: Foundation

            double[] reinfValues = new double[] {0,0,0,0,0};

            if (material == "Concrete")
            {
                reinfValues[0] = slabMass * slabReinfRatio;
                reinfValues[1] = colbMass * colReinfRatio;
                reinfValues[2] = beamMass * beamReinfRatio;
            }

            reinfValues[3] = coreMass * coreWallReinfRatio;
            reinfValues[4] = foundMass * foundReinfRatio;

            return reinfValues;
        }


        public static double CalculateSlabDeadLoad(string material, double height)
        {
            double deadLoadSlab = 0; ;                                    //kN/m2

            if (material == "Concrete")
                deadLoadSlab = gammaConcrete * height; 
            else if (material == "Timber")
                deadLoadSlab = gammaClt * height;
            else if (material == "Concrete")
                deadLoadSlab = gammaConcrete * height;
            else
                RhinoApp.WriteLine("Error: No material selected!");

            return deadLoadSlab; 
        }


        public static double CalculateCost(double mass, string material)
        {
            double costs = 0;

            if (material == "Concrete")
            {
                costs = mass * C30_37Cost;
            }
            else if (material == "Timber")
            {
                costs = mass * cltCost;
            }
            else if (material == "Steel")
            {
                costs = mass * steel_S355Cost;
            }
            else if (material == "Reinforcement")
            {
                costs = mass * reinforcBarsCost;
            }
            else
                RhinoApp.WriteLine("Error: No material selected!");

            return costs;
        }

    }
}
