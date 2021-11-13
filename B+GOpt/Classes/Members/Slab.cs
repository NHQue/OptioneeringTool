using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    public class Slab : Brep
    {
        //Properties with getter and setter
        public Brep Brep { get; set; }

        public double XSpan { get; set; }

        public double YSpan { get; set; }

        public int Storey { get; set; }

        public double Load { get; set; }

        public double Height { get; set; }

        //Constructor
        public Slab(Brep brep)
        {
            Brep = brep;
        }

        public Slab(Brep brep, double xSpan, double ySpan, int storey, double load, double height)
        {
            Brep = brep;
            XSpan = xSpan;
            YSpan = ySpan;
            Storey = storey;
            Load = load;
            Height = height; 
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format($"Slab; Storey: {Storey} [m]; Load: {Load} [kN/m]; Height: {Height}");
        }


    }
}
