using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    public enum ItemTypes: int
    { 
        /// <summary>
        /// Неизвестный тип
        /// </summary>
        Uncknown = 0,

        /// <summary>
        /// Оружие
        /// </summary>
        Weapons = 1,

        /// <summary>
        /// Модули улучшений корабля
        /// </summary>
        Modules = 2,
    }

    /// <summary>
    /// Базовый класс - от него наследуются все классы модулей
    /// </summary>
    public abstract class AModule
    {
        public string Name;
        public abstract ItemTypes type { get; }


        /// <summary>
        /// Задать кораблю бонусы или получить от корабля свои бонусы
        /// </summary>
        /// <param name="currentInfo"></param>
        public abstract void UpdateBonuses(ref ShipInfo info);
    }
}