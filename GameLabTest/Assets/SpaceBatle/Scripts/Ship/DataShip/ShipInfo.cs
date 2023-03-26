using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    [System.Serializable]
    public struct ShipInfo
    {
        /// <summary>
        /// Текущая прочность
        /// </summary>
        public float HP;

        /// <summary>
        /// Максимальная прочность
        /// </summary>
        public float MaxHP;

        /// <summary>
        /// Текущий щит
        /// </summary>
        public float Shield;

        /// <summary>
        /// Максимальный щит
        /// </summary>
        public float MaxShield;

        /// <summary>
        /// Слоты под оружие
        /// </summary>
        public int WeaponSlot;

        /// <summary>
        /// Слоты под модули
        /// </summary>
        public int ModuleSlot;

        /// <summary>
        /// Коэффициэнт перезарядки орудий
        /// </summary>
        public float WeaponReloadKoefficient;

        /// <summary>
        /// Коэффициэнт перезарядки щита
        /// </summary>
        public float ShieldReloadKoefficient;
    }
}