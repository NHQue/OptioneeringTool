using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class BuildingResults
    {

        //Densitis in kN/m3
        private static readonly double gammaConcrete = 25;
        private static readonly double gammaSteel = 78.1;
        private static readonly double gammaClt = 3.8;



        //Methods
        //-----------------------------------------------------------------
        public static double CalculateWeight(double volume, string material)
        {
            if (material == "Concrete")
            {
                double weight = volume * gammaConcrete;
                return weight;
            }
            else
                return 0;
        }






    }
}
