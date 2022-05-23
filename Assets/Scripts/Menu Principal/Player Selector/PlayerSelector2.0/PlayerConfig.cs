using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Menu_Principal.Player_Selector.PlayerSelector2._0
{
    class PlayerConfig
    {
        public readonly String Name;
        public readonly String HabilitiesText;
        public readonly int FontSize;

        public PlayerConfig(string name, String habilitiesText, int fontSize)
        {
            Name = name;
            HabilitiesText = habilitiesText;
            FontSize = fontSize;
        }


    }
}
