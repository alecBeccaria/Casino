using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.SlotsGame
{
    class SlotsGame
    {
        //There are only 4 total signs so this array will only ever be 0-3
        //But the probility of each sign happening is calculated out of 10 then translated into 0-3
        int[] slotsSpaces = new int[] { 0, 0, 0 };
        Random rnd = new Random();
        private bool isWin = false;
        public SlotsGame()
        {

        }
        public string StartGame() {
            int[] randomGame = GetRandomSlots();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < randomGame.Length; i++)
            {
                sb.Append(randomGame[i]);
            }
            return randomGame[1].ToString();
        }

        private void CheckSlotsWin()
        {

        }

        private int GetRandomIntInRange(int min, int max)
        {
            return rnd.Next(min, max);
        }

        private int[] GetRandomSlots()
        {
            int[] slotArray = new int[4];
            for(int i = 0; i < 3; i++)
            {
                _ = slotArray.Append(GetRandomIntInRange(0, 11));
            }
            for(int i = 0; i < slotArray.Length; i++)
            {
                
            }
            return slotArray;
        }
    }
}
