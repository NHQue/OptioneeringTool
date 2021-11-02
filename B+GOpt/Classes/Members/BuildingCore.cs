using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    public class BuildingCore : Brep
    {
        //Properties with getter and setter
        public Brep Brep { get; set; }

        public double Length { get; set; }

        public double Height { get; set; }

        public double Area { get; set; }

        public double ReinforcementRatio { get; set; }


        //Constructor
        public BuildingCore(Brep brep)
        {
            Brep = brep;
        }

        public BuildingCore(Brep brep, double length, double height, double area)
        {
            Brep = brep;
            Length = length;
            Height = height; 
            Area = area;
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format($"Slab; Storey:  [m]; Load:  [kN/m]; Height: ");
        }

    }
}
