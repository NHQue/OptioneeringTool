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

        private double Load { get; set; }

        private double Height { get; set; }

        //Constructor
        public Slab(Brep brep)
        {
            Brep = brep;
        }

        public Slab(Brep brep, int storey, double load, double xSpan, double ySpan)
        {
            Brep = brep;
            Storey = storey;
            Load = load;
            XSpan = xSpan;
            YSpan = xSpan;
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format($"Slab; Storey: {Storey} [m]; Load: {Load} [kN/m]; Height: {Height}");
        }


    }
}
