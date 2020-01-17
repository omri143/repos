using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Methods
    {

        /*
         * The method translates a given number between 1-9 and return the specific coordinate inside the board at the following format
         * coordinat[0] --> row
         * coordinat[1] --> column
         */
        public static int[] TranslateNumberToCoordinate(int num)
        {
            int[] coordinate = new int[2];
            if(num>=1 &&num<=3) // if 1 , 2 , 3
            {
                coordinate[0] = 0;
            }
            else if(num>=4 && num<=6)
            {
                coordinate[0] = 1;
            }
            else
            {
                coordinate[0] = 2;
            }
            if(num == 1 || num ==4 || num == 7)
            {
                coordinate[1] = 0;
            }
            else if(num == 2|| num == 5 || num == 8 )
            {
                coordinate[1] = 1;
            }
            else
            {
                coordinate[1] = 2;
            }
            return coordinate;
        }

    }
}
