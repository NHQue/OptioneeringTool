using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    public class Beam : LineCurve
    {

        //Properties with getter and setter

        public LineCurve LineCurve { get; set; }
        public string Type { get; set; }

        //public double Length { get; set; }              //Already exist as a LineCurve methods

        public double Height { get; set; }

        public double Width { get; set; }

        public int Storey { get; set; }

        private double Load { get; set; }

        private string CrossSection { get; set; }


        //Constructors
        public Beam(LineCurve lineCurve)
        {
            LineCurve = lineCurve;
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------

    }
}
