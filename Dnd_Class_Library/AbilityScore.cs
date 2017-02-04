using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Class_Library
{
    public class AbilityScore
    {
        string name { get; set; }
        int value { get; set; }
        int modifier { get; set; }
        public AbilityScore(string nam, int val)
        {
            name = nam;
            value = val;
            determineModifier(value);
        }
        public void increaseAbilityScore(int val)
        {
            value += val;
            determineModifier(value);
        }
        public void decreaseAbilityScore(int val)
        {
            value -= val;
            determineModifier(value);
        }

        private void determineModifier(int value)
        {
            switch (value)
            {
                case 1:
                    modifier = -5;
                    break;
                case 2:
                    modifier = -4;
                    break;
                case 3:
                    modifier = -4;
                    break;
                case 4:
                    modifier = -3;
                    break;
                case 5:
                    modifier = -3;
                    break;
                case 6:
                    modifier = -2;
                    break;
                case 7:
                    modifier = -2;
                    break;
                case 8:
                    modifier = -1;
                    break;
                case 9:
                    modifier = -1;
                    break;
                case 10:
                    modifier = 0;
                    break;
                case 11:
                    modifier = 0;
                    break;
                case 12:
                    modifier = 1;
                    break;
                case 13:
                    modifier = 1;
                    break;
                case 14:
                    modifier = 2;
                    break;
                case 15:
                    modifier = 2;
                    break;
                case 16:
                    modifier = 3;
                    break;
                case 17:
                    modifier = 3;
                    break;
                case 18:
                    modifier = 4;
                    break;
                case 19:
                    modifier = 4;
                    break;
                case 20:
                    modifier = 5;
                    break;
                case 21:
                    modifier = 5;
                    break;
                case 22:
                    modifier = 6;
                    break;
                case 23:
                    modifier = 6;
                    break;
                case 24:
                    modifier = 7;
                    break;
                case 25:
                    modifier = 7;
                    break;
                case 26:
                    modifier = 7;
                    break;
                case 27:
                    modifier = 8;
                    break;
                case 28:
                    modifier = 8;
                    break;
                case 29:
                    modifier = 9;
                    break;
                case 30:
                    modifier = 10;
                    break;
                default:
                    break;
            }
        }
    }
}
