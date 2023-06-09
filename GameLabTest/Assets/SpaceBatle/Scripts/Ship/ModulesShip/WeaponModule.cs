using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Модуль оружия
    /// </summary>
    public class WeaponModule : AModule
    {
        /// <summary>
        /// Урон за выстрел
        /// </summary>
        public float Damage;

        /// <summary>
        /// Время перезарядки
        /// </summary>
        public float ReloadTime;
        private float nextFireTime = 0;

        /// <summary>
        /// Текущий бонус к перезарядке оружия от корабля
        /// </summary>
        private float currentCoefficient;

        public override ItemTypes type => ItemTypes.Weapons;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            currentCoefficient = info.WeaponReloadKoefficient;
        }

        public bool Fire(IDamageble target)
        {
            if (Time.realtimeSinceStartup > nextFireTime)
            { 
                target.SetDamage(Damage);
                nextFireTime = Time.realtimeSinceStartup + ReloadTime;
                return true;
            }

            return false;
        }
    }
}