using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Dice
    {
        private String url { get; set; }
        private int number { get; }

        public Dice()
        {
            Random rd = new Random();
            int rand_num = rd.Next(1, 7);
            number = rand_num;
            url = "Dice" + number.ToString() + ".png";
        }
    }
}
