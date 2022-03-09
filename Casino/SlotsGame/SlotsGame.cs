using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.SlotsGame
{
    class SlotsGame
    {
       
        public SlotType[] Slots = new SlotType[3];
        Random Rnd = new Random();
        private bool IsWin = false;
        public SlotsGame()
        {

        }
        public void Spin()
        {
            GetRandomSlots();
        }
        public string GetSlotsText()
        {
            StringBuilder SlotsText = new StringBuilder();
            for (int i = 0; i < Slots.Length; i++)
            {
                SlotsText.Append("[");
                SlotsText.Append(Slots[i].ToString());
                SlotsText.Append("]");
            }

            if (CheckSlotsWin() == true)
            {
                SlotsText.Append("You Won!");
            }
            return SlotsText.ToString();
        }
        public int GetWinnings(int betAmount)
        {
            switch(Slots[0]){
                case SlotType.Cherry: return betAmount * 15; break;
                case SlotType.Bells: return betAmount * 35; break;
                case SlotType.Bars: return betAmount * 100; break;
                case SlotType.Seven: return betAmount * 1000; break;
                default: return betAmount;
            }
        }
        public bool CheckSlotsWin()
        {
            IsWin =  Slots.Distinct().Count() == 1;
            return IsWin;
        }


        private void GetRandomSlots()
        {
            Slots = new SlotType[Slots.Length];
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = CalculateSlot();
            }
        }
        /*
    Cherry (4 in 10 per Wheel) - 15:1
    Bells (3 in 10 per Wheel) - 35:1
    Bars  (2 in 10 per Wheel) - 100:1
    Sevens (1 in 10 per Wheel) - 1000:1
*/
        private SlotType CalculateSlot()
        {
            int rand = Rnd.Next(0, 100);

            if (rand < 40) //40%
            {
                return SlotType.Cherry;
            }
            else if(rand > 40 && rand < 70) //30%
            {
                return SlotType.Bells;
            }
            else if (rand > 70 && rand < 90)// 20%
            {
                return SlotType.Bars;
            }
            else //10%
            {
                return SlotType.Seven;
            }

        }
    }
}
