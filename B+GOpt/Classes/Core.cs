using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace B_GOpt.Classes
{
    public class Core : Brep
    {
        //Properties with getter and setter
        public Brep Brep { get; set; }

        //Constructor
        public Core(Brep brep)
        {
            Brep = brep;
        }



        //Methods
        //----------------------------------------------------------------------------------------------------------

    }
}
