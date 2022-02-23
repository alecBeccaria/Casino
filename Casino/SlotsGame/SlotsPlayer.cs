using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.SlotsGame
{
    class SlotsPlayer : Player
    {
        int SlotWins = 0;
        bool ActiveGame = false;
        public SlotsPlayer(Player player)
        {
            this.cash = player.cash;
            this.chips = player.chips;
        }

    }
}
