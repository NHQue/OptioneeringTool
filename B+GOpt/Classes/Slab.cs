﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    class Slab : Surface
    {
        //Properties with getter and setter
        public Surface Surface { get; set; }

        //Constructor
        public Slab(Surface surfaceep)
        {
            Surface = surfaceep;
        }



        //Methods
        //----------------------------------------------------------------------------------------------------------


    }
}