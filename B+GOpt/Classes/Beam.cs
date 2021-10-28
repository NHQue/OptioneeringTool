﻿using System;
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

        private double Load { get; set; }

        private string CrossSection { get; set; }


        //Constructors

        public Beam()
        {

        }

        public Beam(LineCurve lineCurve, string type, int storey, double load, double xSpac, double ySpac)
        {
            LineCurve = lineCurve;
            Length = lineCurve.GetLength();
            Type = type;
            Storey = storey;
            Load = load * xSpac;
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
