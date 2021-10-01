﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Collections;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.DocObjects;
using System.Runtime.InteropServices;
using Rhino.Geometry.Collections;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace B_GOpt
{
    class MyFunctions
    {

        /// <summary>
        /// This funuction Selects the Building Geometry
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public static Brep SelectBuildingGeometry(Brep brep)
        {
            GetObject gb = new GetObject();
            gb.SetCommandPrompt("Select a building geometry");
            gb.GeometryFilter = ObjectType.Brep;
            gb.DisablePreSelect();
            gb.SubObjectSelect = false;
            gb.Get();
            brep = gb.Object(0).Brep();
            if (gb.CommandResult() != Result.Success)
                return null;

            if (brep != null)
            {
                RhinoApp.WriteLine("Building geometry successfully selected");
                return  brep;
            }
              
            return null;

        }


        /// <summary>
        /// This funuction Selects the Building Core
        /// </summary>
        /// <param name="core"></param>
        /// <returns></returns>
        public static Brep SelectCoreGeometry(Brep core)
        {
            GetObject gc = new GetObject();
            gc.SetCommandPrompt("Select a core geometry");
            gc.GeometryFilter = ObjectType.Brep;
            gc.DisablePreSelect();
            gc.SubObjectSelect = false;
            gc.Get();
            core = gc.Object(0).Brep();
            if (gc.CommandResult() != Result.Success)
                return null;

            if (core == null)
                return null;

            if (core != null)
            {
                RhinoApp.WriteLine("Core successfully selected");
                return core;
            }

            return null;

        }


        
        /// <summary>
        /// This function Evaluate the Selected Building Geometry ()
        /// </summary>
        /// <param name="brep"></param>
        public static void EvaluateGeometry(Brep brep)
        {
            //Gets the base surface
            BrepFaceList faces = brep.Faces;
            Brep baseSrf = new Brep();

            for (int i = 0; i < faces.Count; i++)
            {
                Vector3d neg_z = new Vector3d(0, 0, -1);
                if (faces[i].NormalAt(1, 1) == neg_z)
                {
                    BrepFace baseFace = faces[i];

                    if (baseFace is Rhino.Geometry.BrepFace ptObj)
                    {
                        baseSrf = ptObj.Brep;
                    }
                }
                else
                    continue;
            }


            BrepVertexList brepVerts = brep.Vertices;

            BrepVertexList baseVertices = baseSrf.Vertices;
            Point3dList basePts3d = new Point3dList();


            //Converts the baseVertices from Point[] to Point3dList
            for (int i = 0; i < baseVertices.Count; i++)
            {
                Point3d pt = new Point3d();

                if (baseVertices[i] is Rhino.Geometry.Point ptObj)
                {
                    pt = ptObj.Location;
                    basePts3d.Add(pt);
                }
            }



            //Calculating the building's geometry
            //----------------------------------------------------------------------------------------------
            List<double> xVals = new List<double> { };
            List<double> yVals = new List<double> { };
            List<double> zVals = new List<double> { };

            //List<List<double>> cols = new List<List<double>> { };

            foreach (var brepVert in brepVerts)
            {
                double zVal = brepVert.Location.Z;
                zVals.Add(zVal);
            }

            double buildingHeight = Math.Round(zVals.Max() - zVals.Min(), 2);


            foreach (var basePt in basePts3d)
            {
                double xVal = basePt.X;
                xVals.Add(xVal);

                double yVal = basePt.Y;
                yVals.Add(yVal);
            }

            double buildingXDir = Math.Round(xVals.Max() - xVals.Min(), 2);
            double buildingYDir = Math.Round(yVals.Max() - yVals.Min(), 2);


            RhinoApp.WriteLine("The building's height is {0}", buildingHeight);                         //Prompt the building's geometry
            RhinoApp.WriteLine("The building's width (x-Dir) is {0} m", buildingXDir.ToString());
            RhinoApp.WriteLine("The building's length (y-Dir) is {0} m", buildingYDir.ToString());


            //Calculate possible building dimensions
            //----------------------------------------------------------------------------------------------
            

        }


        public static bool ConstructSlabs(Brep brep, double actFloorHeight, double buildingHeight)
        {

            RhinoList<Plane> planes = new RhinoList<Plane>();                //Constructs a new empty List of planes
            RhinoList<Brep> floorSlabs = new RhinoList<Brep>();              //Constructs a new empty List of breps
            RhinoList<Curve> outerEdgeCurves = new RhinoList<Curve>();       //Constructs a new empty List of curves 
            RhinoList<Curve> innerEdgeCurves = new RhinoList<Curve>();       //Constructs a new empty List of curves 

            for (double d = actFloorHeight; d < buildingHeight; d = d + actFloorHeight)
            {
                Point3d origin = new Point3d(0, 0, d);
                Vector3d planeNorm = new Vector3d(0, 0, 1);
                Plane plane = new Plane(origin, planeNorm);
                planes.Add(plane);
            }

            //Calculate the intersections from building geometry and planes
            for (int i = 0; i < planes.Count; i++)
            {
                bool res = Rhino.Geometry.Intersect.Intersection.BrepPlane(brep, planes[i], 0.01, out Curve[] intCurves, out Point3d[] intPoints);

                for (int j = 0; j < intCurves.Length; j++)
                {
                    outerEdgeCurves.Add(intCurves[j]);
                    //doc.Objects.AddCurve(intCurves[j]);

                }
            }

            return false;
        }





    }
}
