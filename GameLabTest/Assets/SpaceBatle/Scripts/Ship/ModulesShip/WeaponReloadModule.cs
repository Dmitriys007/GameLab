using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Ускоряет перезарядку модулей вооружения
    /// </summary>
    public class WeaponReloadModule : AModule
    {
        /// <summary>
        /// Коэфициэнт перезарядки оружия (например чтобы ускорить перезарядку на 20% - требуется поставить значение 0.8f)
        /// </summary>
        public float ReloadKoefficient;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.WeaponReloadKoefficient *= ReloadKoefficient;
        }
    }
}