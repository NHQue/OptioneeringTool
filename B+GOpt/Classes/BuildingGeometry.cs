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
    public class BuildingGeometry : Brep
    {

        
        //Properties with getter and setter
        public Brep Brep { get; set; }

        //Constructor
        public BuildingGeometry(Brep brep)
        {
            Brep = brep;
        }

        //Declaration of some basic variables/stuff
        Vector3d dirX = new Vector3d(1, 0, 0);
        Vector3d dirY = new Vector3d(0, 1, 0);
        Vector3d dirZ = new Vector3d(0, 0, 1);




        //Methods
        //----------------------------------------------------------------------------------------------------------


        /// <summary>
        /// This calculates the Building's Height
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public double BuildingHeight(Brep brep)
        {
            List<double> zVals = new List<double> { };

            BrepVertexList brepVerts = brep.Vertices;

            foreach (var brepVert in brepVerts)
            {
                double zVal = brepVert.Location.Z;
                zVals.Add(zVal);
            }

            double buildingHeight = Math.Round(zVals.Max() - zVals.Min(), 2);

            return buildingHeight;
        }


        /// <summary>
        /// This calculates the Building's Length
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public double BuildingLength(Brep brep)
        {
            List<double> xVals = new List<double> { };

            BrepVertexList brepVerts = brep.Vertices;

            foreach (var brepVert in brepVerts)
            {
                double xVal = brepVert.Location.X;
                xVals.Add(xVal);
            }

            double buildingLength = Math.Round(xVals.Max() - xVals.Min(), 2);

            return buildingLength;
        }


        /// <summary>
        /// This calculates the Building's Width
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public double BuildingWidth(Brep brep)
        {
            List<double> yVals = new List<double> { };

            BrepVertexList brepVerts = brep.Vertices;

            foreach (var brepVert in brepVerts)
            {
                double yVal = brepVert.Location.Y;
                yVals.Add(yVal);
            }

            double buildingWidth = Math.Round(yVals.Max() - yVals.Min(), 2);

            return buildingWidth;
        }


        public Brep GetBaseSurface(Brep brep, RhinoDoc doc)
        {
            BrepFaceList faces = brep.Faces;
            Brep baseSrf = new Brep();

            for (int i = 0; i < faces.Count; i++)
            {
                Vector3d neg_z = new Vector3d(0, 0, -1);

                if (faces[i].NormalAt(1, 1) == neg_z)
                {
                    BrepFace baseFace = faces[i];
                    baseSrf = baseFace.ToBrep();
                }
                else
                    continue;
            }

            //doc.Objects.AddBrep(baseSrf);
            doc.Views.Redraw();

            return baseSrf;
        }


        /// <summary>
        /// This method calculates the actual floor height for the selected building geometry and the desired values
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="floorHeight"></param>
        /// <returns></returns>
        public double FloorHeight(Brep brep, double floorHeight)
        {
            double buildingHeight = BuildingHeight(brep);
            int nStorey = Convert.ToInt32(Math.Floor(buildingHeight / floorHeight));
            double actFloorHeight = Math.Round(buildingHeight / nStorey, 2);

            return actFloorHeight;
        }

        /// <summary>
        /// This method gets the starting point for the creation of the structural grid
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public Point3d StartingPoint(Brep brep)
        {
            Point3d tempRefPt = new Point3d(-10000, -10000, 0);     //Constructs a helping Point to find the start for the structural grid

            BrepVertexList brepVerts = brep.Vertices;
            //Converts the brepVerts from Point[] to Point3dList
            Point3dList brepPts3d = new Point3dList();
            for (int i = 0; i < brepVerts.Count; i++)
            {
                Point3d pt = new Point3d();

                if (brepVerts[i] is Rhino.Geometry.Point ptObj)
                {
                    pt = ptObj.Location;
                    brepPts3d.Add(pt);
                }
            }

            int closestInd = brepPts3d.ClosestIndex(tempRefPt);     //Gets the index of the brep's closest VertexPt to start the structural grid

            Point3d startPt = brepPts3d[closestInd];

            return startPt;
        }



        /// <summary>
        /// This method calculates the actual spacing in x-direction for the selected building geometry and the desired values
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="spacX"></param>
        /// <returns></returns>
        public double ActualXSpacing(Brep brep, double spacX)
        {
            double buildingLength = BuildingLength(brep);
            int nspacX = Convert.ToInt32(Math.Floor(buildingLength / spacX));
            double actXSpac = Math.Round(buildingLength / nspacX, 2);

            return actXSpac;
        }

        /// <summary>
        /// This method calculates the actual spacing in y-direction for the selected building geometry and the desired values
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="spacY"></param>
        /// <returns></returns>
        public double ActualYSpacing(Brep brep, double spacY)
        {
            double buildingWidth = BuildingLength(brep);
            int nspacY = Convert.ToInt32(Math.Floor(buildingWidth / spacY));
            double actYSpac = Math.Round(buildingWidth / nspacY, 2);

            return actYSpac;
        }

        /// <summary>
        /// This method calculates the actual amount of stories for the selected building geometry and the desired values
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="floorHeight"></param>
        /// <returns></returns>
        public int StoreyCount(Brep brep, double floorHeight)
        {
            double buildingHeight = BuildingHeight(brep);
            int nStorey = Convert.ToInt32(Math.Floor(buildingHeight / floorHeight));

            return nStorey;
        }


        /// <summary>
        /// This method constructs the building's floor slabs
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="floorHeight"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public RhinoList<Brep> ConstructSlabs(Brep brep, double floorHeight, RhinoDoc doc)
        {
            double tolerance = doc.ModelAbsoluteTolerance;

            RhinoList<Plane> planes = new RhinoList<Plane>();                //Constructs a new empty List of planes
            RhinoList<Brep> floorSlabs = new RhinoList<Brep>();              //Constructs a new empty List of breps
            RhinoList<Curve> outerEdgeCurves = new RhinoList<Curve>();       //Constructs a new empty List of curves 
            RhinoList<Curve> innerEdgeCurves = new RhinoList<Curve>();       //Constructs a new empty List of curves 

            for (double d = FloorHeight(brep, floorHeight); d < BuildingHeight(brep); d = d + FloorHeight(brep, floorHeight))
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

            //Creates the floor slabs
            for (int i = 0; i < planes.Count; i++)
            {
                RhinoList<Curve> crvs = new RhinoList<Curve>();

                crvs.Add(outerEdgeCurves[i]);
                //crvs.Add(innerEdgeCurves[i]);

                Brep[] floorSlab = Brep.CreatePlanarBreps(crvs, tolerance);

                for (int j = 0; j < floorSlab.Length; j++)
                {
                    floorSlabs.Add(floorSlab[j]);
                    //doc.Objects.AddBrep(floorSlabCore[j]);
                }
                crvs.Clear();
            }

            //Adds the slabs do the Rhino Document
            for (int i = 0; i < floorSlabs.Count; i++)
            {
                doc.Objects.AddBrep(floorSlabs[i]);
            }

            doc.Views.Redraw();

            return floorSlabs;
        }


        /// <summary>
        /// This method constructs the building's columns
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="spacX"></param>
        /// <param name="spacY"></param>
        /// <param name="floorHeight"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public RhinoList<Rhino.Geometry.Line> ConstructColumns(Brep brep, double spacX, double spacY, double floorHeight, RhinoDoc doc)
        {
            Point3d startPt = StartingPoint(brep);

            RhinoList<Rhino.Geometry.Line> columns = new RhinoList<Rhino.Geometry.Line>();

            double actXspac = ActualXSpacing(brep, spacX);
            double actYspac = ActualYSpacing(brep, spacY);
            double actFloorHeight = FloorHeight(brep, floorHeight);


            //Creating the columns
            for (int z = 0; z < StoreyCount(brep, floorHeight); z++)
            {
                for (int x = 0; x < spacX; x++)
                {
                    for (int y = 0; y < spacY; y++)
                    {
                        Point3d pt = new Point3d(startPt.X + x * actXspac, startPt.Y + y * actYspac, z * actFloorHeight);
                        Rhino.Geometry.Line column = new Rhino.Geometry.Line(pt, dirZ, actFloorHeight);
                        columns.Add(column);
                    }
                }
            }

            //Adds the columns to the Rhino Document
            for (int i = 0; i < columns.Count; i++)
            {
                doc.Objects.AddLine(columns[i]);
            }
            doc.Views.Redraw();

            return columns;
        }



        /// <summary>
        /// This method construct the building's beams
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="spacX"></param>
        /// <param name="spacY"></param>
        /// <param name="floorHeight"></param>
        /// <param name="doc"></param>
        public void ConstructBeams(Brep brep, double spacX, double spacY, double floorHeight, RhinoDoc doc)
        {
            Point3d startPt = StartingPoint(brep);

            RhinoList<Rhino.Geometry.LineCurve> beamsX = new RhinoList<Rhino.Geometry.LineCurve>();
            RhinoList<Rhino.Geometry.LineCurve> beamsY = new RhinoList<Rhino.Geometry.LineCurve>();

            double actXspac = ActualXSpacing(brep, spacX);
            double actYspac = ActualYSpacing(brep, spacY);
            double actFloorHeight = FloorHeight(brep, floorHeight);

            for (int z = 1; z <= StoreyCount(brep, floorHeight); z++)
            {
                //Beams in x-Direction
                for (int x = 0; x < spacX - 1; x++)
                {
                    for (int y = 0; y < spacY; y++)
                    {
                        Point3d pt = new Point3d(startPt.X + x * actXspac, startPt.Y + y * actYspac, z * actFloorHeight);
                        Rhino.Geometry.LineCurve beamX = new Rhino.Geometry.LineCurve(new Rhino.Geometry.Line(pt, dirX, actXspac));
                        beamsX.Add(beamX);
                    }
                }

                //Beams in y-Direction
                for (int y = 0; y < spacY-1; y++)
                {
                    for (int x = 0; x < spacX; x++)
                    {
                        Point3d pt = new Point3d(startPt.X + x * actXspac, startPt.Y + y * actYspac, z * actFloorHeight);
                        Rhino.Geometry.LineCurve beamY = new Rhino.Geometry.LineCurve(new Rhino.Geometry.Line(pt, dirY, actYspac));
                        beamsY.Add(beamY);
                    }
                }
            }

            //Adds the beams to the Rhino Document
            for (int i = 0; i < beamsX.Count; i++)
            {
                doc.Objects.AddCurve(beamsX[i]);
            }
            for (int i = 0; i < beamsY.Count; i++)
            {
                doc.Objects.AddCurve(beamsY[i]);
            }

            doc.Views.Redraw();
        }


        /// <summary>
        /// This methods calculates the total surface area of the selected building
        /// </summary>
        /// <param name="slabs"></param>
        /// <returns></returns>
        public double SurfaceArea(RhinoList<Brep> slabs)
        {
            double totalArea = 0;

            for (int i = 0; i < slabs.Count; i++)
            {
                double area = slabs[i].GetArea();

                totalArea = totalArea + area;
            }
            return totalArea;
        }




    }
}
