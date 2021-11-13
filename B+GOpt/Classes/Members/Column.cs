using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    public class Column
    {
        //Properties with getter and setter

        public LineCurve LineCurve { get; set; }

        public double Length { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public int Storey { get; set; }

        public double Load { get; set; }

        public string CrossSection { get; set; }

        public double Area { get; set; }


        //Constructors

        public Column()
        {

        }

        public Column(LineCurve lineCurve, int storey, int storeyCount, double load, double xSpac, double ySpac, double area)
        {
            LineCurve = lineCurve;
            Length = lineCurve.GetLength();
            Storey = storey;
            Load = load * xSpac * ySpac * (storeyCount - storey + 1);
            Area = area; 
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format($"Column; Length: {Length} [m]; Storey: {Storey} [m]; Load: {Load} [kN/m]; CrossSection: {CrossSection}");
        }

    }
}
