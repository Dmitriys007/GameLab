using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Космический корабль с возможностью смены оборудования
    /// </summary>
    public class Ship : MonoBehaviour
    {
        /// <summary>
        /// Базовые характеристики корабля
        /// </summary>
        [SerializeField] private ShipInfo baseInfo;

        /// <summary>
        /// Текущие характеристики корабля
        /// </summary>
        private ShipInfo currentInfo;

        /// <summary>
        /// Список установленных модулей (могут быть null)
        /// </summary>
        private AModule[] modulesList;

        /// <summary>
        /// Список установленного вооружения (могут быть null)
        /// </summary>
        private AModule[] weaponsList;

        private void Awake()
        {
            weaponsList = new AModule[baseInfo.WeaponSlot];
            modulesList = new AModule[baseInfo.ModuleSlot];

            RecalculateBonuses();            
        }

        private void RecalculateBonuses()
        {
            currentInfo = baseInfo;
            for (var i = 0; i < modulesList.Length; i++)
                modulesList[i]?.UpdateBonuses(ref currentInfo);
            
            for (var i = 0; i < weaponsList.Length; i++) 
                weaponsList[i]?.UpdateBonuses(ref currentInfo);// Оружие важно обновлять после обновления модулей
        }

        public ShipInfo GetCurrentInfo()
        { 
            return currentInfo;
        }

        internal void AddModule(AModule module, int idSlot)
        {
            if (module.type == ItemTypes.Weapons)
                weaponsList[idSlot] = module;
            else if (module.type == ItemTypes.Modules)
                modulesList[idSlot] = module;
            
            RecalculateBonuses();
        }
    }
}