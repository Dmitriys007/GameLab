using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Увеличение размера щита
    /// </summary>
    public class ShieldExpansionModule : AModule
    {
        /// <summary>
        /// Увеличение размера щита
        /// </summary>
        public float BusterShieldValue;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.MaxShield += BusterShieldValue;
            info.Shield = info.MaxShield;
        }
    }
}