using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Увеличение жизни корабля
    /// </summary>
    public class HPExpandModule : AModule
    {
        /// <summary>
        /// Увленичение жизни корабля на указанную величину
        /// </summary>
        public float BusterHPValue;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.MaxHP += BusterHPValue;
            info.HP = info.MaxHP;
        }
    }
}