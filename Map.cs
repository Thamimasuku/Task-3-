using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Map
    {
        private Units[] units;
        Random R = new Random();

        public Units[] Units
        {
            get { return units; }
            set { units = value; }
        }

        //number of units = total number of units in the map 
        public Map (int maxX, int maxY, int numUnits)
        {
            units = new Units[numUnits];
            for(int i = 0; i < numUnits; i++)
            {

                MeleeUnit m = new MeleeUnit(R.Next(0, maxX),
                                            R.Next(0, maxY),
                                            100,
                                            10,
                                            1,
                                            1,
                                            i % 2,
                                            "M");
                Units[i] = m;
            }

            units = new Units[numUnits];
            for (int j = 0; j < numUnits; j++)
            {
                RangedUnit r = new RangedUnit(R.Next(0, maxX),
                                              R.Next(0, maxY),
                                              100,
                                              10,
                                              1,
                                              1,
                                              j % 2,
                                              "R");
                Units[j] = r;
            }
        }
    }
}
