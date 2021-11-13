using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    class LCACalculation
    {
        //CO2 values according to IStructE database
        //
        //CHECK UNITS!!!!!!!!!!!!!!
        //------------------------------------------------------------------------
        //Steel
        double reinforcBars = 1.99;             //kgC02e per kg
        double hotRolledSect = 1.55;
        double platedSect = 2.46;
        double galvProfiledSheet = 2.76;

        //Concrete
        double C30_37_CEMI = 342;               //kgCO2e per m3
        double C30_37_CEMII_A_V = 318;
        double C30_37_CEMII_B_V = 285.6;
        double C30_37_CEMIV_B_V = 249.6;
        double C30_37_CEMII_B_S = 272.4;
        double C30_37_CEMIII_A = 200.4;
        double C30_37_CEMIII_B = 145.2;

        //Timber 
        //Excluding Carbon Storage
        double softwoodExclCS = 110.46;           //kgCO2e per m3
        double cltExclCS = 206.96;
        double glulamExclCS = 225.28;
        double plywoodExclCS = 367.74;
        //Including Carbon Storage
        double softwoodInclCS = -510.80;           //kgCO2e per m3
        double cltInclCS = -568.32;
        double glulamInclCS = -396.00;
        double plywoodInclCS = -502.20;

    }
}
