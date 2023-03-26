using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Ускоритель зарядки щита
    /// </summary>
    public class ShieldRechangerModule : AModule
    {
        /// <summary>
        /// Коэфициэнт на который умножается перезарядка щита (например чтоб увеличить перезарядку на 20% - следует указать значение 1.2f)
        /// </summary>
        public float BustKoefficient;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.ShieldReloadKoefficient *= BustKoefficient;
        }
    }
}