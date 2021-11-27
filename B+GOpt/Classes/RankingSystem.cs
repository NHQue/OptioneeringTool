using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_GOpt.Classes
{
    public static class RankingSystem
    {
        //Static Methods
        //--------------------------------------------------------------------------------------------------------------------
        public static int RankCarbon(BuildingVariant buildingVariant, List<BuildingVariant> buildingVariants)
        {
            buildingVariants = buildingVariants.OrderByDescending(x => x.EmbodiedCO2).ToList();

            int ranking = 0;

            for (int i = 0; i < buildingVariants.Count; i++)
            {
                if (buildingVariant.EmbodiedCO2 >= buildingVariants[i].EmbodiedCO2)
                {
                    ranking = ranking + 1;
                    break;
                }
                ranking = ranking + 1;
            }

            return ranking; 
        }
    }
}
