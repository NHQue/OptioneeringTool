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
using Rhino.Geometry.Intersect;
using B_GOpt.Classes;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace B_GOpt
{
    class MyFunctions
    {


        /// <summary>
        /// This method selects the Building Geometry
        /// </summary>
        /// <param name="brep"></param>
        /// <returns></returns>
        public static ObjRef SelectBuildingGeometry(Brep brep)
        {

            GetObject gb = new GetObject();
            gb.SetCommandPrompt("Select a building geometry");
            gb.GeometryFilter = ObjectType.Brep;
            gb.DisablePreSelect();
            gb.SubObjectSelect = false;
            gb.Get();
            brep = gb.Object(0).Brep();
            ObjRef objRef = gb.Object(0);
            if (gb.CommandResult() != Result.Success)
                return null;

            if (brep != null)
            {
                RhinoApp.WriteLine("Building geometry successfully selected");
                //RhinoApp.WriteLine($"ObjRef Id of Building geometry: {objRef.ObjectId}");
                return objRef;
                //return null;
            }

            return null;
        }

        /// <summary>
        /// This method selects the Building Cores
        /// </summary>
        /// <returns></returns>
        public static List<ObjRef> SelectCores()
        {
            List<ObjRef> objRefs = new List<ObjRef>(); 

            GetObject gb = new GetObject();
            gb.SetCommandPrompt("Select the building's cores");
            gb.EnablePreSelect(false, true);
            gb.GeometryFilter = ObjectType.Brep;
            gb.GetMultiple(1, 0);

            //if (gb.CommandResult() != Result.Success)
            //    return gb.CommandResult();

            RhinoList<Brep> cores = new RhinoList<Brep>();

            for (int i = 0; i < gb.ObjectCount; i++)
            {
                Brep core = gb.Object(i).Brep();                    //Checks if the selected object can be converted to a brep that means it is a brep
                ObjRef objRef = gb.Object(i);
                if (null != core)
                {
                    cores.Add(core);
                    objRefs.Add(objRef);
                }
            }

            if (cores != null)
            {
                if (cores.Count == 1)
                    RhinoApp.WriteLine( "One core successfully selected");
                else if (cores.Count == 2)
                    RhinoApp.WriteLine("Two cores successfully selected");
                else if (cores.Count == 3)
                    RhinoApp.WriteLine("Three cores successfully selected");
                else if (cores.Count == 3)
                    RhinoApp.WriteLine("Four cores successfully selected");
                else
                    RhinoApp.WriteLine("Multiple cores successfully selected");

                return objRefs;
            }

            return null;
        }

        public static Beam SelectMember(Beam lineCurve)
        {
            GetObject gb = new GetObject();
            gb.SetCommandPrompt("Select a building geometry");
            gb.GeometryFilter = ObjectType.Curve;
            gb.DisablePreSelect();
            gb.SubObjectSelect = false;
            gb.Get();
            Curve crv = gb.Object(0).Curve();

            lineCurve = crv as Beam;

            if (gb.CommandResult() != Result.Success)
                return null;

            if (lineCurve != null)
            {
                RhinoApp.WriteLine("LineCurve successfully selected");
                return lineCurve;
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


        /// <summary>
        /// This method constructs slabs
        /// </summary>
        /// <param name="brep"></param>
        /// <param name="actFloorHeight"></param>
        /// <param name="buildingHeight"></param>
        /// <returns></returns>
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



        /// <summary>
        /// This method splits multiple lines with a curve and returns the line segments
        /// </summary>
        /// <param name="linesToSplit"></param>
        /// <param name="splitCurve"></param>
        /// <returns></returns>
        public static RhinoList<Line> SplitLinesByCurve(RhinoList<Line> linesToSplit, Curve splitCurve)
        {
            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            RhinoList<Line> intLines = new RhinoList<Line>();
            //RhinoList<Line> intLinesY = new RhinoList<Line>();

            for (int i = 0; i < linesToSplit.Count; i++)
            {
                NurbsCurve lineToCrv = linesToSplit[i].ToNurbsCurve();
                CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(lineToCrv, splitCurve, intersection_tolerance, overlap_tolerance);

                if (intEvents != null)
                {
                    for (int j = 0; j < intEvents.Count - 1; j++)
                    {
                        IntersectionEvent ccx_event = intEvents[j];
                        IntersectionEvent ccy_event = intEvents[j + 1];

                        Line line = new Line(ccx_event.PointA, ccy_event.PointA);
                        intLines.Add(line);

                        //doc.Objects.AddLine(line);
                        //doc.Objects.AddPoint(ccx_event.PointA);
                    }
                }
            }

            return intLines;
        }



        /// <summary>
        /// This method splits multiple lines with multiple lines and returns the first LineList as segments
        /// </summary>
        /// <param name="linesToSplit"></param>
        /// <param name="linesSplit"></param>
        /// <returns></returns>
        public static List<Line> SplitLinesByLines(RhinoList<Line> linesToSplit, RhinoList<Line> linesSplit)
        {
            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            List<Line> lineSegments = new List<Line>();

            for (int i = 0; i < linesToSplit.Count; i++)
            {
                NurbsCurve lineToSplitToCrv = linesToSplit[i].ToNurbsCurve();
                lineToSplitToCrv.Domain = new Interval(0, 1);
                List<double> intParams = new List<double>();

                for (int j = 0; j < linesSplit.Count; j++)
                {
                    NurbsCurve lineSplitToCrv = linesSplit[j].ToNurbsCurve();
                    CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(lineToSplitToCrv, lineSplitToCrv, intersection_tolerance, overlap_tolerance);

                    if (intEvents.Count >= 1)
                    {
                        intParams.Add(intEvents[0].ParameterA);
                    }
                }

                Curve[] curveSeg = lineToSplitToCrv.Split(intParams);

                for (int j = 0; j < curveSeg.Length; j++)
                {
                    Line line = new Line(curveSeg[j].PointAtStart, curveSeg[j].PointAtEnd);
                    lineSegments.Add(line);
                    //doc.Objects.AddCurve(curveSeg[j]);
                }
            }

            return lineSegments;
        }


        /// <summary>
        /// This method splits a single line with multiple lines and returns the resulting segments of the line
        /// </summary>
        /// <param name="lineToSplit"></param>
        /// <param name="linesSplit"></param>
        /// <returns></returns>
        public static List<Line> SplitLineByLines(Line lineToSplit, RhinoList<Line> linesSplit)
        {
            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            List<Line> lineSegments = new List<Line>();

                NurbsCurve lineToSplitToCrv = lineToSplit.ToNurbsCurve();
                lineToSplitToCrv.Domain = new Interval(0, 1);
                List<double> intParams = new List<double>();

                for (int j = 0; j < linesSplit.Count; j++)
                {
                    NurbsCurve lineSplitToCrv = linesSplit[j].ToNurbsCurve();
                    CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(lineToSplitToCrv, lineSplitToCrv, intersection_tolerance, overlap_tolerance);

                    if (intEvents.Count >= 1)
                    {
                        intParams.Add(intEvents[0].ParameterA);
                    }
                }

                Curve[] curveSeg = lineToSplitToCrv.Split(intParams);

                for (int j = 0; j < curveSeg.Length; j++)
                {
                    Line line = new Line(curveSeg[j].PointAtStart, curveSeg[j].PointAtEnd);
                    lineSegments.Add(line);
                    //doc.Objects.AddCurve(curveSeg[j]);
                }
            

            return lineSegments;
        }








        /// <summary>
        /// This method splits a single line with multiple breps and returns the resulting segments of the line
        /// </summary>
        /// <param name="breps"></param>
        /// <param name="line"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static RhinoList<Line> SplitLineWithBreps(RhinoList<Brep> breps, Line line, RhinoDoc doc)
        {
            //Basic intersection parameters
            double tolerance = doc.ModelAbsoluteTolerance;

            RhinoList<Line> lineSegments = new RhinoList<Line>();
            NurbsCurve lineSplitToCrv = line.ToNurbsCurve();
            lineSplitToCrv.Domain = new Interval(0, 1);
            List<double> intParams = new List<double>();

            for (int i = 0; i < breps.Count; i++)
            {
                bool intersection = Rhino.Geometry.Intersect.Intersection.CurveBrep(lineSplitToCrv, breps[i], tolerance, tolerance, out double[] t);

                for (int j = 0; j < t.Length; j++)
                {
                    intParams.Add(t[j]);
                }
            }

            if (intParams.Count == 0)
            {
                lineSegments.Add(line);
            }
            else 
            {
                Curve[] curveSeg = lineSplitToCrv.Split(intParams);

                for (int i = 0; i < curveSeg.Length; i++)
                {
                    Line tempLine = new Line(curveSeg[i].PointAtStart, curveSeg[i].PointAtEnd);

                    lineSegments.Add(tempLine);
                    //doc.Objects.AddCurve(curveSeg[j]);
                }
            }

            return lineSegments;
        }





        public static bool IsLineInsideBuilding(Brep brep, Line line, RhinoDoc doc)
        {
            double tolerance = doc.ModelAbsoluteTolerance;
            bool strictlyIn = false;

            line.ToNurbsCurve().Domain = new Interval(0, 1);
            Point3d midPt = new Point3d(line.PointAt(0.5));

            if (brep.IsPointInside(midPt, tolerance, strictlyIn))
                return true;
            else
                return false;
        }




        /// <summary>
        /// This method checks whether a line is inside a brep
        /// </summary>
        /// <param name="breps"></param>
        /// <param name="line"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static bool IsLineInsideCores(RhinoList<Brep> breps, Line line, RhinoDoc doc)
        {
            double tolerance = doc.ModelAbsoluteTolerance;
            bool strictlyIn = false;

            line.ToNurbsCurve().Domain = new Interval(0, 1);
            Point3d midPt = new Point3d(line.PointAt(0.5));

            List<bool> boolValues = new List<bool>();

            for (int i = 0; i < breps.Count; i++)
            {
                if (breps[i].IsPointInside(midPt, tolerance, strictlyIn))
                    boolValues.Add(true);
                else
                    boolValues.Add(false);
            }

            if (boolValues.Contains(true))
                return true;
            else
                return false;
        }



        /// <summary>
        /// /// This function sets or creates a new layer 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="layerName"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// Returns a layer
        public static Rhino.DocObjects.Layer SetLayer(RhinoDoc doc, string layerName, System.Drawing.Color color)
        {
            if (string.IsNullOrEmpty(layerName) || !Rhino.DocObjects.Layer.IsValidName(layerName))
                return null;

            //Checking if the layer already exists
            Rhino.DocObjects.Layer layer = doc.Layers.FindName(layerName);

            if (layer != null)
            {
                //The layer already exists -> one accesses its index and sets it to current
                if (layer.Index >= 0)
                    doc.Layers.SetCurrentLayerIndex(layer.Index, false);
            }
            else
            {
                layer = new Rhino.DocObjects.Layer();

                layer.Name = layerName;
                layer.Color = color;

                //Creating a new layer
                int layerIndex = doc.Layers.Add(layerName, color);
                if (layerIndex >= 0)
                    doc.Layers.SetCurrentLayerIndex(layerIndex, false);

                doc.Layers.Add(layerName, color);
            }
            return doc.Layers[layer.Index]; ;
        }








        /// <summary>
        /// This method creates a 2D Colum Grid for an "arbitrary" closed curve
        /// </summary>
        /// <param name="selCrv"></param>
        /// <param name="doc"></param>
        public static void CreateGrid2D(Curve selCrv, double xSpac, double ySpac, double floorHeight, RhinoDoc doc)
        {
            //Creates the Bounding Box

            BoundingBox bbox = selCrv.GetBoundingBox(true);
            //if (!boundingBox.IsValid)
            //    return Rhino.Commands.Result.Failure;

            Point3d minBBox = bbox.Min;
            Point3d maxBBox = bbox.Max;

            double xDim = maxBBox.X - minBBox.X;
            double yDim = maxBBox.Y - minBBox.Y;

            Rhino.RhinoApp.WriteLine("X-Dimension: {0}", xDim);
            Rhino.RhinoApp.WriteLine("Y-Dimension: {0}", yDim);

            //Gets the edges of the Bounding Box

            Line[] edges = bbox.GetEdges();
            int numEdges = edges.Count();

            for (int i = 0; i <= 3; i++)
            {
                //doc.Objects.AddLine(edges[i]);
            }


            //Creates a grid for the Bounding Rectangle 

            Point3d[] divPtsX0;
            Point3d[] divPtsX2;
            Point3d[] divPtsY1;
            Point3d[] divPtsY3;

            int divNrX = 5;
            int divNrY = 8;

            edges[2].Flip();
            edges[3].Flip();

            double[] parX0 = edges[0].ToNurbsCurve().DivideByCount(divNrX, false, out divPtsX0);
            double[] ptsX2 = edges[2].ToNurbsCurve().DivideByCount(divNrX, false, out divPtsX2);

            double[] parY1 = edges[1].ToNurbsCurve().DivideByCount(divNrY, false, out divPtsY1);
            double[] ptsY3 = edges[3].ToNurbsCurve().DivideByCount(divNrY, false, out divPtsY3);

            RhinoList<Line> gridLinesX = new RhinoList<Line>();
            RhinoList<Line> gridLinesY = new RhinoList<Line>();

            for (int i = 0; i < divPtsX0.Length; i++)
            {
                Line line = new Line(divPtsX0[i], divPtsX2[i]);
                gridLinesX.Add(line);
                //doc.Objects.AddLine(line);
            }

            for (int i = 0; i < divPtsY1.Length; i++)
            {
                Line line = new Line(divPtsY1[i], divPtsY3[i]);
                gridLinesY.Add(line);
                //doc.Objects.AddLine(line);
            }




            //Creates the self intersection of the gridlines -> girder grid

            //Basic intersection parameters
            const double intersection_tolerance = 0.001;
            const double overlap_tolerance = 0.0;

            RhinoList<Line> intLinesX = new RhinoList<Line>();
            RhinoList<Line> intLinesY = new RhinoList<Line>();

            for (int i = 0; i < gridLinesX.Count; i++)
            {
                NurbsCurve gridCurve = gridLinesX[i].ToNurbsCurve();
                CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(gridCurve, selCrv, intersection_tolerance, overlap_tolerance);

                if (intEvents != null)
                {
                    for (int j = 0; j < intEvents.Count - 1; j++)
                    {
                        IntersectionEvent ccx_event = intEvents[j];
                        IntersectionEvent ccy_event = intEvents[j + 1];

                        Line line = new Line(ccx_event.PointA, ccy_event.PointA);
                        intLinesX.Add(line);

                        doc.Objects.AddLine(line);
                        //doc.Objects.AddPoint(ccx_event.PointA);
                    }
                }
            }


            for (int i = 0; i < gridLinesY.Count; i++)
            {
                NurbsCurve gridCurve = gridLinesY[i].ToNurbsCurve();
                CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(gridCurve, selCrv, intersection_tolerance, overlap_tolerance);

                if (intEvents != null)
                {
                    for (int j = 0; j < intEvents.Count - 1; j++)
                    {
                        IntersectionEvent ccx_event = intEvents[j];
                        IntersectionEvent ccy_event = intEvents[j + 1];

                        Line line = new Line(ccx_event.PointA, ccy_event.PointA);
                        intLinesY.Add(line);

                        doc.Objects.AddLine(line);
                        //doc.Objects.AddPoint(ccx_event.PointA);
                    }
                }
            }


            //Creates the outer columns
            List<Point3d> posOuterColumns = new List<Point3d>();

            List<Line> outerColumns = new List<Line>();

            for (int i = 0; i < intLinesX.Count; i++)
            {
                posOuterColumns.Add(intLinesX[i].From);
                posOuterColumns.Add(intLinesX[i].To);
            }

            for (int i = 0; i < intLinesY.Count; i++)
            {
                posOuterColumns.Add(intLinesY[i].From);
                posOuterColumns.Add(intLinesY[i].To);
            }

            for (int i = 0; i < posOuterColumns.Count; i++)
            {
                Point3d pt1 = posOuterColumns[i];
                Vector3d vec = new Vector3d(0, 0, -floorHeight);
                Point3d pt2 = pt1 + vec;
                Line column = new Line(pt1, pt2);
                doc.Objects.AddLine(column);
                outerColumns.Add(column);
            }

            //List<Point3d> posInnerColumns = new List<Point3d>();
            List<Line> innerColumns = new List<Line>();
            List<Curve> beamsX = new List<Curve>();
            List<Curve> beamsY = new List<Curve>();


            //Creates the beams in x-Direction and inner columns

            if (xSpac < ySpac)
            {
                for (int i = 0; i < intLinesX.Count; i++)
                {
                    NurbsCurve gridCurveX = intLinesX[i].ToNurbsCurve();
                    gridCurveX.Domain = new Interval(0, 1);
                    var intParams = new List<double>();

                    for (int j = 0; j < intLinesY.Count; j++)
                    {
                        NurbsCurve gridCurveY = intLinesY[j].ToNurbsCurve();
                        CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(gridCurveX, gridCurveY, intersection_tolerance, overlap_tolerance);

                        if (intEvents.Count >= 1)
                        {
                            intParams.Add(intEvents[0].ParameterA);
                            Point3d pt1 = new Point3d(intEvents[0].PointA);
                            Vector3d vec = new Vector3d(0, 0, -floorHeight);
                            Point3d pt2 = pt1 + vec;
                            Line column = new Line(pt1, pt2);
                            doc.Objects.AddLine(column);
                            //posInnerColumns.Add(intEvents[0].PointA);
                            innerColumns.Add(column);
                            //doc.Objects.AddPoint(intEvents[0].PointA);
                        }
                    }

                    Curve[] curveSeg = gridCurveX.Split(intParams);

                    for (int j = 0; j < curveSeg.Length; j++)
                    {
                        beamsX.Add(curveSeg[j]);
                        doc.Objects.AddCurve(curveSeg[j]);
                    }
                }
            }



            //Creates the beams in y-Direction
            else
            {
                for (int i = 0; i < intLinesY.Count; i++)
                {
                    NurbsCurve gridCurveY = intLinesY[i].ToNurbsCurve();
                    gridCurveY.Domain = new Interval(0, 1);
                    var intParams = new List<double>();

                    for (int j = 0; j < intLinesX.Count; j++)
                    {
                        NurbsCurve gridCurveX = intLinesX[j].ToNurbsCurve();
                        CurveIntersections intEvents = Rhino.Geometry.Intersect.Intersection.CurveCurve(gridCurveY, gridCurveX, intersection_tolerance, overlap_tolerance);

                        if (intEvents.Count >= 1)
                        {
                            intParams.Add(intEvents[0].ParameterA);
                            Point3d pt1 = new Point3d(intEvents[0].PointA);
                            Vector3d vec = new Vector3d(0, 0, -floorHeight);
                            Point3d pt2 = pt1 + vec;
                            Line column = new Line(pt1, pt2);
                            doc.Objects.AddLine(column);
                            innerColumns.Add(column);
                            //doc.Objects.AddPoint(intEvents[0].PointA);
                        }
                    }

                    Curve[] curveSeg = gridCurveY.Split(intParams);

                    for (int j = 0; j < curveSeg.Length; j++)
                    {
                        beamsY.Add(curveSeg[j]);
                        doc.Objects.AddCurve(curveSeg[j]);
                    }
                }
            }

        }


        public static void DrawBuildingInWPF(Brep brep, Point3D EndPoint, string name)
        {
            GeometryModel3D myGeometryModel = new GeometryModel3D();

            // The geometry specifes the shape of the 3D plane. In this sample, a flat sheet is created.
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            MeshingParameters meshParams = new MeshingParameters();          //Creates a new MeshingParmter object "meshParam"
            meshParams.MinimumEdgeLength = 0.1;                              //Declares values of the MeshingParmter object "meshParam"
            meshParams.MaximumEdgeLength = 50;

            Mesh[] brepMeshes = Mesh.CreateFromBrep(brep, meshParams);

            Mesh weldedMesh = new Mesh();                                   //Creates a new mesh object "weldedMesh"

            foreach (var mesh in brepMeshes)
            {
                weldedMesh.Append(mesh);                                    //Appends the single mesh to the mesh "weldedMesh"
            }

            //Get the mesh components
            MeshVertexList vertices = weldedMesh.Vertices;
            MeshVertexNormalList normals = weldedMesh.Normals;
            Vector3DCollection myNormalCollection = new Vector3DCollection();

            for (int i = 0; i < normals.Count; i++)
            {
                myNormalCollection.Add(new Vector3D(normals[i].X, normals[i].Y, normals[i].Z));
            }


            //Convert Rhino Mesh to MeshGeometry3D
            myMeshGeometry3D.Normals = myNormalCollection;

            Point3DCollection myPositionCollection = new Point3DCollection();

            for (int i = 0; i < vertices.Count; i++)
            {
                myPositionCollection.Add(new Point3D(vertices[i].X, vertices[i].Y, vertices[i].Z));
            }

            myMeshGeometry3D.Positions = myPositionCollection;


            Int32Collection myTriangleIndicesCollection = new Int32Collection();

            MeshFaceList faces = weldedMesh.Faces;

            for (int i = 0; i < faces.Count; i++)
            {
                int indA = faces[i].A;
                int indB = faces[i].B;
                int indC = faces[i].C;

                myTriangleIndicesCollection.Add(indA);
                myTriangleIndicesCollection.Add(indB);
                myTriangleIndicesCollection.Add(indC);
            }

            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;


            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;


            //Set the properties of the Model3D
            //buildingMeshWPF.TriangleIndices = myTriangleIndicesCollection;
            //buildingMeshWPF.Positions = myPositionCollection;
            //buildingMeshWPF.Normals = myNormalCollection;
        }

        public static string EvaluateSystem(string material, string structSystem)
        {
            string definedStructSystem = "Not defined";

            if (material == "Concrete")
            {
                if (structSystem == "Beam")
                    definedStructSystem = "Precast T-Beams";
                else
                    definedStructSystem = "Flat Slab";
            }
            else if (material == "Steel")
            {
                if (structSystem == "Beam")
                    definedStructSystem = "Composite Beams";
                else
                    definedStructSystem = "Slim Floor";
            }
            else if (material == "Timber")
            {
                if (structSystem == "Beam")
                    definedStructSystem = "Timber Joists";
                else
                    definedStructSystem = "CLT Slab";
            }
            else if (material == "Composite")
            {
                if (structSystem == "Beam")
                    definedStructSystem = "CLT on Steelframe";
                else
                    definedStructSystem = "HBV Slab";
            }

            return definedStructSystem;
        }
    }
}
