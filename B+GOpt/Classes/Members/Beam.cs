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

        public double Length { get; set; }              

        public double Height { get; set; }

        public double Width { get; set; }

        public int Storey { get; set; }

        public double Load { get; set; }

        public string CrossSection { get; set; }

        public double Area { get; set; }


        //Constructors

        public Beam()
        {

        }

        public Beam(LineCurve lineCurve, string type, int storey, double load, double loadedLength, double area)
        {
            LineCurve = lineCurve;
            Length = lineCurve.GetLength();
            Type = type;
            Storey = storey;
            Load = load * loadedLength;     // kN/m
            Area = area; 
        }


        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format($"Beam; Length: {Length} [m]; Storey: {Storey} [m]; Load: {Load} [kN/m]; CrossSection: {CrossSection}");
        }

        //public Line ToLine(Beam beam)
        //{
        //    Line beamLine = new Line(beam.PointAtStart, beam.PointAtEnd);
        //    return beamLine; 
        //}

    }
}
