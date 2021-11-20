using Rhino.Collections;
using Rhino.Geometry;
using Rhino.Geometry.Collections;
using Rhino.DocObjects;
using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public class BuildingVariant
    {

        //Properties with getter and setter
        public Brep Brep { get; set; }

        public int Index { get; set; }

        public string Material { get; set; }

        public string StructSystem { get; set; }

        public string Grid { get; set; }

        public double EmbodiedCO2 { get; set; }

        public double Costs { get; set; }

        public double SurfaceArea { get; set; }

        public double Weight { get; set; }


        //Constructor
        public BuildingVariant(Brep brep, int index, string material, string structSystem, 
                                double embodiedCO2, double actXSpax, double actYSpax, 
                                double costs, double surfaceArea, double weight)
        {
            Brep = brep;
            Index = index;
            Material = material;
            StructSystem = structSystem;
            Grid = String.Format($"{actXSpax} x {actYSpax}"); 
            EmbodiedCO2 = embodiedCO2;
            Costs = costs;
            SurfaceArea = surfaceArea;
            Weight = weight; 
        }


        //Declaration of some basic variables/stuff
        //----------------------------------------------------------------------------------------------------------




        //Methods
        //----------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return String.Format(   $"Case: {Index}" + System.Environment.NewLine + 
                                    $"Sytstem : {Material} + {StructSystem}, Grid: {Grid}, EmbodiedCO2: {EmbodiedCO2}," +
                                    $"Costs: {Costs}; Surface Area:  {SurfaceArea}, Weight: {Weight}");
        }
    }
}
