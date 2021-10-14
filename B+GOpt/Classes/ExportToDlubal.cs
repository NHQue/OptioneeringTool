using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Dlubal.RFEM5;
using Rhino.Collections;

namespace B_GOpt.Classes
{
    public static class ExportToDlubal
    {
        

        //Methods
        //------------------------------------------------------------------------------------------------------

        public static void ExportColumns(RhinoList<Rhino.Geometry.Line>  columns)
        {
            for (int i = 0; i < columns.Count; i++)
            {

            }







            //Anlegen von Dlubal Knoten
            Dlubal.RFEM5.Node node1 = new Dlubal.RFEM5.Node();
            Dlubal.RFEM5.Node node2 = new Dlubal.RFEM5.Node();

            node1.X = 0;
            node1.Y = 0;
            node1.Z = 0;
            node1.No = 1;

            node2.X = 2;
            node2.Y = 0;
            node2.Z = 0;
            node2.No = 2;


            //Anlegen einer Dlubal Linie
            Dlubal.RFEM5.Line line1 = new Dlubal.RFEM5.Line();

            line1.NodeList = "1,2";
            line1.No = 2;


            //Anlegen einer Dlubal Materials
            Dlubal.RFEM5.Material mat1 = new Dlubal.RFEM5.Material();
            mat1.TextID = "NameID|Beton C30/37@TypeID|CONCRETE@NormID|DIN 1045-1 - 08";
            mat1.No = 1;


            //Anlegen einer Dlubal Querschnitts
            Dlubal.RFEM5.CrossSection cross1 = new Dlubal.RFEM5.CrossSection();
            cross1.TextID = "IPE 500";
            cross1.No = 1;
            cross1.MaterialNo = 1;


            //Anlegen eines Dlubal Stabs
            Dlubal.RFEM5.Member memb1 = new Dlubal.RFEM5.Member();
            memb1.LineNo = 2;
            memb1.StartCrossSectionNo = 1;
            memb1.No = 1;
        }


        public static void ExportBeams(RhinoList<Rhino.Geometry.LineCurve> beams)
        {

        }



        public static void ExportSupportPts(RhinoList<Rhino.Geometry.Point3d> supports)
        {

        }

    }
}
