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
    public static class _2DGrid
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
                        doc.Objects.AddCurve(curveSeg[j]);
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
                    doc.Objects.AddCurve(curveSeg[j]);
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

    }
}
