using Rhino;
using Rhino.Collections;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry.Intersect;

namespace B_GOpt.Classes
{
    public static class StructGrid
    {
        //Methods
        //----------------------------------------------------------------------------------------------------------


        public static BoundingBox CreateBoundingBox(Curve selCrv)
        {
            //Creates the Bounding Box

            BoundingBox bbox = selCrv.GetBoundingBox(true);

            return bbox;
        }


        public static RhinoList<Line> XGridLines(BoundingBox bbox, int divNrX, RhinoDoc doc)
        {
            Line[] edges = bbox.GetEdges();
            int numEdges = edges.Count();

            //edges[2].Flip();
            edges[3].Flip();

            Point3d[] divPtsX1;
            Point3d[] divPtsX3;

            double[] parX1 = edges[1].ToNurbsCurve().DivideByCount(divNrX, false, out divPtsX1);
            double[] parX3 = edges[3].ToNurbsCurve().DivideByCount(divNrX, false, out divPtsX3);

            RhinoList<Line> gridLinesX = new RhinoList<Line>();

            for (int i = 0; i < divPtsX1.Length; i++)
            {
                Line line = new Line(divPtsX1[i], divPtsX3[i]);
                gridLinesX.Add(line);
                //doc.Objects.AddLine(line);
            }

            return gridLinesX;
        }


        public static RhinoList<Line> YGridLines(BoundingBox bbox, int divNrY, RhinoDoc doc)
        {
            Line[] edges = bbox.GetEdges();
            int numEdges = edges.Count();

            edges[2].Flip();
            //edges[3].Flip();

            Point3d[] divPtsY0;
            Point3d[] divPtsY2;

            double[] parY0 = edges[0].ToNurbsCurve().DivideByCount(divNrY, false, out divPtsY0);
            double[] parY2 = edges[2].ToNurbsCurve().DivideByCount(divNrY, false, out divPtsY2);

            RhinoList<Line> gridLinesY = new RhinoList<Line>();

            for (int i = 0; i < divPtsY0.Length; i++)
            {
                Line line = new Line(divPtsY0[i], divPtsY2[i]);
                gridLinesY.Add(line);
                //doc.Objects.AddLine(line);
            }

            return gridLinesY;
        }


        public static RhinoList<Line> SecondaryBeams(BoundingBox bbox, double actXSpac, double actYSpac, 
                                            RhinoList<Line> gridLinesY, RhinoList<Line> gridLinesX, double distance, RhinoDoc doc)
        {
            RhinoList<Line> secondaryBeams = new RhinoList<Line>();

            int countNumber = 1;

            //This works
            if (actXSpac > actYSpac)
            {
                Line[] edges = bbox.GetEdges();
                int numEdges = edges.Count();

                edges[2].Flip();
                //edges[3].Flip();

                Point3d[] divPtsY0;
                Point3d[] divPtsY2;


                List<Line> linesA = MyFunctions.SplitLineByLines(edges[0], gridLinesY);
                List<Line> linesB = MyFunctions.SplitLineByLines(edges[2], gridLinesY);

                countNumber = Convert.ToInt32(Math.Floor(actXSpac / distance));
                double actDist = Math.Round(actXSpac / countNumber, 2);

                //RhinoApp.WriteLine($"Secondary Beams: Count {countNumber}, Distance {actDist} ");

                for (int i = 0; i < linesA.Count; i++)
                {
                    linesA[i].ToNurbsCurve().DivideByCount(countNumber, false, out divPtsY0);
                    linesB[i].ToNurbsCurve().DivideByCount(countNumber, false, out divPtsY2);

                    for (int j = 0; j < divPtsY0.Length; j++)
                    {
                        Line line = new Line(divPtsY0[j], divPtsY2[j]);
                        secondaryBeams.Add(line);
                        //doc.Objects.AddLine(line);
                    }
                }
            }

            //This works NOT
            else
            {
                Line[] edges = bbox.GetEdges();
                int numEdges = edges.Count();

                edges[3].Flip();
                //edges[3].Flip();

                Point3d[] divPtsX1;
                Point3d[] divPtsX3;


                List<Line> linesA = MyFunctions.SplitLineByLines(edges[1], gridLinesX);
                List<Line> linesB = MyFunctions.SplitLineByLines(edges[3], gridLinesX);

                countNumber = Convert.ToInt32(Math.Floor(actYSpac / distance));
                double actDist = Math.Round(actXSpac / countNumber, 2);

                for (int i = 0; i < linesA.Count; i++)
                {
                    linesA[i].ToNurbsCurve().DivideByCount(countNumber, false, out divPtsX1);
                    linesB[i].ToNurbsCurve().DivideByCount(countNumber, false, out divPtsX3);

                    for (int j = 0; j < divPtsX1.Length; j++)
                    {
                        Line line = new Line(divPtsX1[j], divPtsX3[j]);
                        secondaryBeams.Add(line);
                        //doc.Objects.AddLine(line);
                    }
                }
            }

            return secondaryBeams;
        }




        public static RhinoList<Line> XIntLines(RhinoList<Line> gridLinesX, Curve selCrv, RhinoDoc doc)
        {
            RhinoList<Line> xIntLines = MyFunctions.SplitLinesByCurve(gridLinesX, selCrv);

            //for (int i = 0; i < xIntLines.Count; i++)
            //{
            //    doc.Objects.AddLine(xIntLines[i]);
            //}

            return xIntLines;
        }


        public static RhinoList<Line> YIntLines(RhinoList<Line> gridLinesY, Curve selCrv, RhinoDoc doc)
        {
            RhinoList<Line> yIntLines = MyFunctions.SplitLinesByCurve(gridLinesY, selCrv);

            //for (int i = 0; i < yIntLines.Count; i++)
            //{
            //    doc.Objects.AddLine(yIntLines[i]);
            //}

            return yIntLines;
        }


        public static List<Line> XBeams(RhinoList<Line> xIntLines, RhinoList<Line> yIntLines, RhinoDoc doc)
        {
            List<Line> xBeams = MyFunctions.SplitLinesByLines(xIntLines, yIntLines);

            return xBeams;
        }

        public static List<Line> YBeams(RhinoList<Line> yIntLines, RhinoList<Line> xIntLines, RhinoDoc doc)
        {
            List<Line> yBeams = MyFunctions.SplitLinesByLines(yIntLines, xIntLines);

            return yBeams;
        }

        public static List<Curve> EdgeBeams(RhinoList<Line> xIntLines, RhinoList<Line> yIntLines, Curve selCrv, RhinoDoc doc)
        {
            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            List<Curve> edgeBeams = new List<Curve>();

            //If selCrv is PolylineCurve
            if (selCrv.IsPolyline())
            {
                PolylineCurve selPolyCrv = selCrv as PolylineCurve;
                Line[] segPoly = selPolyCrv.ToPolyline().GetSegments();

                for (int i = 0; i < segPoly.Length; i++)
                {
                    NurbsCurve segNurbsCrv = segPoly[i].ToNurbsCurve();
                    segNurbsCrv.Domain = new Interval(0, 1);

                    List<double> intParams = new List<double>();

                    for (int j = 0; j < yIntLines.Count; j++)
                    {
                        NurbsCurve gridCurveY = yIntLines[j].ToNurbsCurve();
                        CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(segNurbsCrv, gridCurveY, intersection_tolerance, overlap_tolerance);

                        if (intEvents.Count >= 1)
                        {
                            intParams.Add(intEvents[0].ParameterA);
                        }
                    }

                    for (int j = 0; j < xIntLines.Count; j++)
                    {
                        NurbsCurve gridCurveX = xIntLines[j].ToNurbsCurve();
                        CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(segNurbsCrv, gridCurveX, intersection_tolerance, overlap_tolerance);

                        if (intEvents.Count >= 1)
                        {
                            intParams.Add(intEvents[0].ParameterA);
                        }
                    }

                    Curve[] curveSeg = segNurbsCrv.Split(intParams);

                    for (int j = 0; j < curveSeg.Length; j++)
                    {
                        edgeBeams.Add(curveSeg[j]);
                        //doc.Objects.AddCurve(curveSeg[j]);
                    }
                }
            }

            //If selCrv is NOT PolylineCurve
            else
            {
                selCrv.Domain = new Interval(0, 1);
                var intParams = new List<double>();

                for (int j = 0; j < yIntLines.Count; j++)
                {
                    NurbsCurve gridCurveY = yIntLines[j].ToNurbsCurve();
                    CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(selCrv, gridCurveY, intersection_tolerance, overlap_tolerance);

                    if (intEvents.Count >= 1)
                    {
                        intParams.Add(intEvents[0].ParameterA);
                    }
                }

                for (int j = 0; j < xIntLines.Count; j++)
                {
                    NurbsCurve gridCurveX = xIntLines[j].ToNurbsCurve();
                    CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(selCrv, gridCurveX, intersection_tolerance, overlap_tolerance);

                    if (intEvents.Count >= 1)
                    {
                        intParams.Add(intEvents[0].ParameterA);
                    }
                }

                Curve[] curveSeg = selCrv.Split(intParams);

                for (int j = 0; j < curveSeg.Length; j++)
                {
                    edgeBeams.Add(curveSeg[j]);
                    //doc.Objects.AddCurve(curveSeg[j]);
                }
            }

            return edgeBeams;
        }


        public static List<Line> InnerColumns(RhinoList<Line> linesA, RhinoList<Line> linesB, double floorHeight, RhinoDoc doc)
        {
            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            List<Point3d> posInnerColumns = new List<Point3d>();
            List<Line> innerColumns = new List<Line>();


            for (int i = 0; i < linesA.Count; i++)
            {
                NurbsCurve gridCurveX = linesA[i].ToNurbsCurve();
                gridCurveX.Domain = new Interval(0, 1);
                var intParams = new List<double>();

                for (int j = 0; j < linesB.Count; j++)
                {
                    NurbsCurve gridCurveY = linesB[j].ToNurbsCurve();
                    CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(gridCurveX, gridCurveY, intersection_tolerance, overlap_tolerance);

                    if (intEvents.Count >= 1)
                    {
                        intParams.Add(intEvents[0].ParameterA);
                        posInnerColumns.Add(intEvents[0].PointA);

                        Point3d pt1 = intEvents[0].PointA;
                        Vector3d vec = new Vector3d(0, 0, -floorHeight);
                        Point3d pt2 = pt1 + vec;
                        Line column = new Line(pt1, pt2);
                        innerColumns.Add(column);
                    }
                }
            }

            return innerColumns;
        }


        public static List<Line> OuterColumns(RhinoList<Line> xIntLines, RhinoList<Line> yIntLines, double floorHeight, RhinoDoc doc)
        {
            List<Point3d> posOuterColumns = new List<Point3d>();
            List<Line> outerColumns = new List<Line>();

            for (int i = 0; i < xIntLines.Count; i++)
            {
                posOuterColumns.Add(xIntLines[i].From);
                posOuterColumns.Add(xIntLines[i].To);
            }

            for (int i = 0; i < yIntLines.Count; i++)
            {
                posOuterColumns.Add(yIntLines[i].From);
                posOuterColumns.Add(yIntLines[i].To);
            }

            for (int i = 0; i < posOuterColumns.Count; i++)
            {
                Point3d pt1 = posOuterColumns[i];
                Vector3d vec = new Vector3d(0, 0, -floorHeight);
                Point3d pt2 = pt1 + vec;
                Line column = new Line(pt1, pt2);
                outerColumns.Add(column);
                //doc.Objects.AddLine(column);
            }

            return outerColumns;
        }

        public static List<Line> EdgeColumns(Curve selCrv, double floorHeight, RhinoDoc doc)
        {
            List<Line> edgeColumns = new List<Line>();

            if (selCrv.IsPolyline())
            {
                PolylineCurve selPolyCrv = selCrv as PolylineCurve;
                Line[] segPoly = selPolyCrv.ToPolyline().GetSegments();

                for (int i = 0; i < segPoly.Length; i++)
                {
                    Point3d pt1 = segPoly[i].From;
                    Vector3d vec = new Vector3d(0, 0, -floorHeight);
                    Point3d pt2 = pt1 + vec;
                    Line column = new Line(pt1, pt2);
                    edgeColumns.Add(column);
                    //doc.Objects.AddLine(column);
                }
            }

            return edgeColumns;
        }

        public static void DeleteOuterMembers(List<Line> members, Brep brep, RhinoDoc doc)
        {
            //Basic variables for IsPointInside operation
            double tolerance = doc.ModelAbsoluteTolerance;
            bool strictlyIn = false;

            for (int i = 0; i < members.Count; i++)
            {
                bool inside = brep.IsPointInside(members[i].PointAt(0.5), tolerance, strictlyIn);

                if (inside != true)
                {
                    members.Remove(members[i]);
                }
            }
        }


        public static void CoreBeamInt(Brep core, List<Curve> beamsX, List<Curve>  beamsY, RhinoDoc doc)
        {
            double tolerance = doc.ModelAbsoluteTolerance;

            //Intersection beams in x-direction with core geometry
            RhinoList<Rhino.Geometry.Curve> beamsXint = new RhinoList<Rhino.Geometry.Curve>();
            for (int i = 0; i < beamsX.Count; i++)   //Gets all the beams in x-direction that interesect with the core
            {
                beamsX[i].Domain = new Interval(0, 1);

                if (core.IsPointInside(beamsX[i].PointAt(0), tolerance, false)
                    || core.IsPointInside(beamsX[i].PointAt(0.25), tolerance, false)
                    || core.IsPointInside(beamsX[i].PointAt(0.5), tolerance, false)
                    || core.IsPointInside(beamsX[i].PointAt(0.75), tolerance, false)
                    || core.IsPointInside(beamsX[i].PointAt(1), tolerance, false))
                {
                    beamsXint.Add(beamsX[i]);
                    beamsX.Remove(beamsX[i]);
                }
            }

            RhinoList<Rhino.Geometry.Curve> beamsXintSegments = new RhinoList<Rhino.Geometry.Curve>();
            for (int i = 0; i < beamsXint.Count; i++)
            {
                Curve[] crvs = beamsXint[i].Split(core, tolerance, tolerance);
                for (int j = 0; j < crvs.Length; j++)
                {
                    crvs[j].Domain = new Interval(0, 1);
                    Point3d midPt = crvs[j].PointAt(0.5);
                    //doc.Objects.AddPoint(midPt);

                    if (!core.IsPointInside(midPt, tolerance, false))
                    {
                        beamsXintSegments.Add(crvs[j]);
                        //doc.Objects.AddCurve(crvs[j]);
                    }
                }
            }


            //Intersection beams in y-direction with core geometry
            RhinoList<Rhino.Geometry.Curve> beamsYint = new RhinoList<Rhino.Geometry.Curve>();
            for (int i = 0; i < beamsY.Count; i++)   //Gets all the beams in y-direction that interesect with the core
            {
                beamsY[i].Domain = new Interval(0, 1);

                if (core.IsPointInside(beamsY[i].PointAt(0), tolerance, false)
                    || core.IsPointInside(beamsY[i].PointAt(0.25), tolerance, false)
                    || core.IsPointInside(beamsY[i].PointAt(0.5), tolerance, false)
                    || core.IsPointInside(beamsY[i].PointAt(0.75), tolerance, false)
                    || core.IsPointInside(beamsY[i].PointAt(1), tolerance, false))
                {
                    beamsYint.Add(beamsY[i]);
                    beamsY.Remove(beamsY[i]);
                }
            }

            RhinoList<Rhino.Geometry.Curve> beamsYintSegments = new RhinoList<Rhino.Geometry.Curve>();
            for (int i = 0; i < beamsYint.Count; i++)
            {
                Curve[] crvs = beamsYint[i].Split(core, tolerance, tolerance);
                for (int j = 0; j < crvs.Length; j++)
                {
                    crvs[j].Domain = new Interval(0, 1);
                    Point3d midPt = crvs[j].PointAt(0.5);
                    //doc.Objects.AddPoint(midPt);

                    if (!core.IsPointInside(midPt, tolerance, false))
                    {
                        beamsYintSegments.Add(crvs[j]);
                        //doc.Objects.AddCurve(crvs[j]);
                    }
                }
            }
        }




        public static RhinoList<Brep> SplitSlabsWithCores(RhinoList<Brep> cores, CurveList outerEdgeCurves, RhinoDoc doc)
        {
            //Basic intersection parameters
            double tolerance = doc.ModelAbsoluteTolerance;
            RhinoList<Brep> floorSlabs = new RhinoList<Brep>();

            //Calculate the intersections from core and planes
            for (int i = 0; i < outerEdgeCurves.Count; i++)
            {
                RhinoList<Curve> planarCurves = new RhinoList<Curve>();
                planarCurves.Add(outerEdgeCurves[i]);
                List<Curve> innerEdgeCurves = new List<Curve>();
                Plane cuttingPlane = new Plane(outerEdgeCurves[i].PointAtStart, new Vector3d(0, 0, 1));

                for (int j = 0; j < cores.Count; j++)
                {
                    bool res = Rhino.Geometry.Intersect.Intersection.BrepPlane(cores[j], cuttingPlane, tolerance, out Curve[] intCurves, out Point3d[] intPoints);

                    for (int k = 0; k < intCurves.Length; k++)
                    {
                        innerEdgeCurves.Add(intCurves[k]);
                        //doc.Objects.AddCurve(intCurves[k]);
                    }
                }

                for (int j = 0; j < innerEdgeCurves.Count; j++)
                {
                    planarCurves.Add(innerEdgeCurves[j]);
                }

                Brep[] floorSlab = Brep.CreatePlanarBreps(planarCurves, tolerance);

                for (int j = 0; j < floorSlab.Length; j++)
                {
                    floorSlabs.Add(floorSlab[j]);
                    //doc.Objects.AddBrep(floorSlabCore[j]);
                }
                planarCurves.Clear();
            }

            return floorSlabs; 
        }



        public static RhinoList<Brep> SplitSlabsWithCore(RhinoList<Brep> cores, CurveList outerEdgeCurves, RhinoDoc doc)
        {
            //Basic intersection parameters
            double tolerance = doc.ModelAbsoluteTolerance;

            List<Curve> innerEdgeCurves = new List<Curve>();
            Brep core = cores[0];
            RhinoList<Brep> floorSlabs = new RhinoList<Brep>();

            //Calculate the intersections from core and planes
            for (int i = 0; i < outerEdgeCurves.Count; i++)
            {
                Plane cuttingPlane = new Plane(outerEdgeCurves[i].PointAtStart, new Vector3d(0, 0, 1));

                bool res = Rhino.Geometry.Intersect.Intersection.BrepPlane(core, cuttingPlane, tolerance, out Curve[] intCurves, out Point3d[] intPoints);

                for (int j = 0; j < intCurves.Length; j++)
                {
                    innerEdgeCurves.Add(intCurves[j]);
                    //doc.Objects.AddCurve(intCurves[j]);
                }
            }

            //Creates the floor slabs
            for (int i = 0; i < outerEdgeCurves.Count; i++)
            {
                RhinoList<Curve> crvs = new RhinoList<Curve>();

                crvs.Add(outerEdgeCurves[i]);
                crvs.Add(innerEdgeCurves[i]);

                Brep[] floorSlab = Brep.CreatePlanarBreps(crvs, tolerance);

                for (int j = 0; j < floorSlab.Length; j++)
                {
                    floorSlabs.Add(floorSlab[j]);
                    //doc.Objects.AddBrep(floorSlabCore[j]);
                }
                crvs.Clear();
            }

            return floorSlabs;
        }



        /// <summary>
        /// This method checks if a structure has primary beams
        /// </summary>
        /// <param name="material"></param>
        /// <param name="structSystem"></param>
        /// <returns></returns>
        public static bool HasPrimBeam(string material, string structSystem)
        {
            if (material == "Concrete" && structSystem == "Plate")
                return false;
            else
                return true;
        }


        /// <summary>
        /// This method checks if a structure has secondary beams
        /// </summary>
        /// <param name="material"></param>
        /// <param name="structSystem"></param>
        /// <returns></returns>
        public static bool HasSecBeam(string material, string structSystem)
        {
            if (material == "Concrete")
            {
                return false;
            }
            else if (material == "Steel")
            {
                return true;
            }
            else if (material == "Timber")
            {
                if (structSystem == "Plate")
                {
                    return false;
                }
                else
                    return true;
            }
            else if (material == "Hybrid")
            {
                if (structSystem == "Plate")
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
    }
}
