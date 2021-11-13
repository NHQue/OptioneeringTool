using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class PreDimTest
    {
        //Some lists for assigning profiles, areas, ...
        //------------------------------------------------------------------------------------------

        //IPE
        struct IPE
        {
            public string Id;
            public double Height;
            public double Area;
        }

        private static readonly List<IPE> IPEProfiles = new List<IPE>()
        {
             new IPE { Id = "IPE 160", Height = 16, Area = 20.1 },
             new IPE { Id = "IPE 180", Height = 18, Area = 23.9 },
             new IPE { Id = "IPE 200", Height = 20, Area = 28.5 },
             new IPE { Id = "IPE 220", Height = 22, Area = 33.4 },
             new IPE { Id = "IPE 240", Height = 24, Area = 39.1 },
             new IPE { Id = "IPE 270", Height = 27, Area = 45.9 },
             new IPE { Id = "IPE 300", Height = 30, Area = 53.8 },
             new IPE { Id = "IPE 330", Height = 33, Area = 62.6 },
             new IPE { Id = "IPE 360", Height = 36, Area = 72.7 },
             new IPE { Id = "IPE 400", Height = 40, Area = 84.5 },
             new IPE { Id = "IPE 450", Height = 45, Area = 98.8 },
             new IPE { Id = "IPE 500", Height = 50, Area = 116  },
             new IPE { Id = "IPE 550", Height = 55, Area = 134  },
             new IPE { Id = "IPE 600", Height = 60, Area = 156  }
        };


        //HEB
        struct HEB
        {
            public string Id;
            public double Height;
            public double Area;
        }

        private static readonly List<HEB> HEBProfiles = new List<HEB>()
        {
             new HEB { Id = "HEB 160",  Height = 16,  Area = 54.3 },
             new HEB { Id = "HEB 180",  Height = 18,  Area = 65.3 },
             new HEB { Id = "HEB 200",  Height = 20,  Area = 78.1 },
             new HEB { Id = "HEB 220",  Height = 22,  Area = 91.0 },
             new HEB { Id = "HEB 240",  Height = 24,  Area = 106  },
             new HEB { Id = "HEB 260",  Height = 26,  Area = 118  },
             new HEB { Id = "HEB 280",  Height = 28,  Area = 131  },
             new HEB { Id = "HEB 300",  Height = 30,  Area = 149  },
             new HEB { Id = "HEB 320",  Height = 32,  Area = 161  },
             new HEB { Id = "HEB 340",  Height = 32,  Area = 171  },
             new HEB { Id = "HEB 360",  Height = 36,  Area = 181  },
             new HEB { Id = "HEB 400",  Height = 40,  Area = 198  },
             new HEB { Id = "HEB 450",  Height = 45,  Area = 218  },
             new HEB { Id = "HEB 500",  Height = 50,  Area = 239  },
             new HEB { Id = "HEB 550",  Height = 55,  Area = 254  },
             new HEB { Id = "HEB 600",  Height = 60,  Area = 270  },
             new HEB { Id = "HEB 650",  Height = 65,  Area = 286  },
             new HEB { Id = "HEB 700",  Height = 70,  Area = 306  },
             new HEB { Id = "HEB 800",  Height = 80,  Area = 334  },
             new HEB { Id = "HEB 900",  Height = 90,  Area = 371  },
             new HEB { Id = "HEB 1000", Height = 100, Area = 400  }
        };


        //Static Methods
        //--------------------------------------------------------------------------------------------------------------
        //Slabs
        //---------------------------------------------------------------------------------------------------------------
        public static void ConcreteSlab(double spanX, double spanY)
        {
            double height = 0;                                              //m
            double spanLi = 0.8 * Math.Max(spanX, spanY);

            if (spanLi < 4.29)
            {
                height = (spanLi / 35 + 0.03) * 100;
                if (height < 20)
                    height = 20;
            }
            else if (spanLi > 4.29)
            {
                height = ((Math.Pow(spanLi, 2)) / 150 + 0.03) * 100;
                if (height < 20)
                    height = 20;
            }

            double roundedHeight = Math.Ceiling(height);
            if (roundedHeight % 2 != 0)
                roundedHeight = roundedHeight + 1;

            Console.WriteLine("Concrete slab with height: {0} cm, rounded height {1} cm", height, roundedHeight);
        }

        public static void TimberSlab(double spanX, double spanY)
        {
            double span = Math.Min(spanX, spanY);
            double height = 4 * span - 2;                                     //cm
            double roundedHeight = Math.Round(height);

            if (roundedHeight < 12)
                roundedHeight = 12;

            Console.WriteLine("Timber slab with height {0} cm, rounded height {1} cm", height, roundedHeight);
        }



        public static void CompositeSlab(double spanX, double spanY, double load)
        {
            double span = Math.Min(spanX, spanY);       //m
            double heightPlate = 2.6 * span + load;     //cm
            double totalHeight = heightPlate + 5;       //5 cm Aufbeton

            double totalRoundedHeight = Math.Ceiling(totalHeight);

            if (totalRoundedHeight % 2 != 0)
            {
                totalRoundedHeight = totalRoundedHeight + 1;
            }

            Console.WriteLine("Composite slab with height {0} cm, rounded height {1} cm", totalHeight, totalRoundedHeight);
        }

        //Beams
        //---------------------------------------------------------------------------------------------------------------
        public static void SteelBeam(double load, double length)              //IPE
        {
            double height;                                                      //cm
            height = Math.Round(Math.Pow((50 * load * Math.Pow(length, 2)), (double) 1/3));     //Check again if right!!

            string name = "";
            double area = 0;
            double profHeight = 0;

            if (height <= IPEProfiles[0].Height)
            {
                name = IPEProfiles[0].Id;
                area = IPEProfiles[0].Area;
                profHeight = IPEProfiles[0].Height;
            }
            else if (height >= IPEProfiles[IPEProfiles.Count - 2].Height)
            {
                name = IPEProfiles[IPEProfiles.Count - 1].Id;
                area = IPEProfiles[IPEProfiles.Count - 1].Area;
                profHeight = IPEProfiles[IPEProfiles.Count - 1].Height;
            }
            else
            {
                for (int i = 0; i < IPEProfiles.Count - 1; i++)
                {
                    if (IPEProfiles[i].Height <= height && height <= IPEProfiles[i + 1].Height)
                    {
                        name = IPEProfiles[i + 1].Id;
                        area = IPEProfiles[i + 1].Area;
                        profHeight = IPEProfiles[i + 1].Height;
                    }
                }
            }

            Console.WriteLine("Steel beam: Selected Profil for height {0} cm: {1} with height {2} cm and area {3} cm2", height, name, profHeight, area);
        }


        public static void TimberBeam(double load, double length)
        {
            double momSS = (load * Math.Pow(length, 2)) / 8;               //Single Span
            double momCB = (load * Math.Pow(length, 2)) / 10;            //Continous Beam 

            double height = Math.Round(5 * Math.Sqrt(momSS), 2);
            double roundedHeight = Math.Ceiling(height);
            if (roundedHeight % 2 != 0)
            {
                roundedHeight = roundedHeight + 1;
            }

            double width = Math.Round(0.5 * height, 2);
            double roundedWidth = Math.Ceiling(width);
            if (roundedWidth % 2 != 0)
            {
                roundedWidth = roundedWidth + 1;
            }

            double area = roundedHeight * roundedWidth;

            Console.WriteLine("Timber beam with height: {0} cm, rounded height: {1} cm," +
             " width: {2} cm, rounded width: {3} cm, area: {4} cm2", height, roundedHeight, width, roundedWidth, area);
        }


        public static void ConcreteBeam(double load, double length)
        {
            double momSS = (load * Math.Pow(length, 2)) / 8;                      //Single Span
            double momCB = (load * Math.Pow(length, 2)) / 10;                   //Continous Beam 

            double height;                                                      //cm
            height = Math.Round(1.6 * Math.Sqrt(momSS) + 5, 2);

            double roundedHeight = Math.Ceiling(height);
            if (roundedHeight % 2 != 0)
            {
                roundedHeight = roundedHeight + 1;
                if (roundedHeight < 20)
                    roundedHeight = 20;
            }

            double width = height / 2;                                                      //cm
            double roundedWidth = Math.Ceiling(width);
            if (roundedWidth % 2 != 0)
            {
                roundedWidth = roundedWidth + 1;
            }

            double area = roundedHeight * roundedWidth;

            Console.WriteLine("Concrete beam with height: {0} cm, rounded height: {1} cm," +
                " width: {2} cm, rounded width: {3} cm, area: {4} cm2", height, roundedHeight, width, roundedWidth, area);
        }





        //Columns
        //---------------------------------------------------------------------------------------------------------------

        public static void ConcreteColumn(double load)                        //Load in kN
        {
            double sideLength = Math.Round(Math.Sqrt(0.59 * load), 2);                         //cm

            double roundedSideLength = Math.Ceiling(sideLength);
            if (roundedSideLength % 2 != 0)
            {
                roundedSideLength = roundedSideLength + 1;
                if (roundedSideLength < 20)
                {
                    roundedSideLength = 20;
                }
            }
            double area = roundedSideLength * roundedSideLength;                //cm2

            Console.WriteLine("Concrete column with side length: {0} cm, rounded side length: {1} cm, area: {2} cm2 ", sideLength, roundedSideLength, area);

        }


        public static void SteelColumn(double load, double length)               //HEB   //load in kN    //length in m
        {
            double height;                                                      //cm
            height = Math.Round(Math.Sqrt(16 * load * length) / 10, 2);

            string name = "";
            double area = 0;
            double profHeight = 0;

            if (height <= HEBProfiles[0].Height)
            {
                name = HEBProfiles[0].Id;
                area = HEBProfiles[0].Area;
                profHeight = HEBProfiles[0].Height;
            }
            else if (height >= HEBProfiles[HEBProfiles.Count - 2].Height)
            {
                name = HEBProfiles[HEBProfiles.Count - 1].Id;
                area = HEBProfiles[HEBProfiles.Count - 1].Area;
                profHeight = HEBProfiles[HEBProfiles.Count - 1].Height;
            }
            else
            {
                for (int i = 0; i < HEBProfiles.Count - 1; i++)
                {
                    if (HEBProfiles[i].Height <= height && height <= HEBProfiles[i + 1].Height)
                    {
                        name = HEBProfiles[i + 1].Id;
                        area = HEBProfiles[i + 1].Area;
                        profHeight = HEBProfiles[i + 1].Height;
                    }
                }
            }

            Console.WriteLine("Steel column: Selected Profil for height {0} cm: {1} with height {2} cm and area {3} cm2", height, name, profHeight, area);
        }



        public static void TimberColumn(double load, double length)           //load in kN    //length in m
        {
            double sideLength;                                                //cm
            //sideLength = Math.Sqrt(load * length);                            //aus Prietz
            sideLength = Math.Round(2.3 * Math.Sqrt(load), 2);                                //aus Schneider BT

            double roundedSideLength = Math.Ceiling(sideLength);
            if (roundedSideLength % 2 != 0)
            {
                roundedSideLength = roundedSideLength + 1;
            }
            double area = roundedSideLength * roundedSideLength;

            Console.WriteLine("Timber column with side length: {0} cm, rounded side length: {1} cm, area: {2} cm2 ", sideLength, roundedSideLength, area);
        }





        //Core
        //---------------------------------------------------------------------------------------------------------------
        public static void Core()
        {


        }





        //Foundation
        //---------------------------------------------------------------------------------------------------------------
        public static void Foundation()
        {


        }

    }
}
