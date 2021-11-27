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

        public string DefinedStructSystem { get; set; }

        public string Grid { get; set; }

        public double ActXSpac { get; set; }

        public double ActYSpac { get; set; }

        public double EmbodiedCO2 { get; set; }

        public double Costs { get; set; }

        public double SurfaceArea { get; set; }

        public double Weight { get; set; }


        //Constructors
        public BuildingVariant()        //Default constructor
        {

        }

        public BuildingVariant(Brep brep, int index, string material, string definedstructSystem, double embodiedCO2,
                               double actXSpac, double actYSpac, double costs, double surfaceArea, double weight)
        {
            Brep = brep;
            Index = index;
            Material = material;
            DefinedStructSystem = definedstructSystem;
            ActXSpac = actXSpac*100;
            ActYSpac = actYSpac*100;
            Grid = String.Format($"{actXSpac} x {actYSpac}"); 
            EmbodiedCO2 = embodiedCO2;
            Costs = costs;
            SurfaceArea = surfaceArea;
            Weight = weight; 
        }


        //Declaration of some basic variables/stuff
        //----------------------------------------------------------------------------------------------------------




        //Methods
        //----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This method prints the information of the class's object seperated by values to save it in the text file 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format($"{Material},{DefinedStructSystem},{ActXSpac},{ActYSpac},{EmbodiedCO2},{Costs},{SurfaceArea},{Weight}");
        }

        /// <summary>
        /// This method prints the information of the class's object to visualize it in the UI TextBlocks
        /// </summary>
        /// <returns></returns>
        public string ToResult()
        {
            return String.Format($"Material: {Material}, System: {DefinedStructSystem}, Grid: {ActXSpac/100}  m x {ActYSpac/100} m ," + System.Environment.NewLine + 
                                 $"Embodied Carbon: {EmbodiedCO2}" + $" kg CO" + ("\u2082") + $"e" + $", Costs: {Costs} EUR," + System.Environment.NewLine + 
                                 $"Surface Area: {SurfaceArea}" + $" m" + ($"\u00B2") + $", Weight: {Weight} t");
        }
    }
}
