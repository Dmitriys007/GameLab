using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Космический корабль с возможностью смены оборудования
    /// </summary>
    public class Ship : MonoBehaviour, IDamageble, IStateParent
    {
        /// <summary>
        /// Цель для стрельбы (IDamageble указать лучше, но прямой ссылкой на Ship в юнити для упрощения сделано)
        /// </summary>
        public Ship target;

        public AudioSource FireSound; // todo: здесь пока звук выстрелов, по уму в модуле оружия его звук должен быть

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
        public WeaponModule[] weaponsList;

        private void Awake()
        {
            weaponsList = new WeaponModule[baseInfo.WeaponSlot];
            modulesList = new AModule[baseInfo.ModuleSlot];

            RecalculateBonuses();            
        }

        private void FixedUpdate()
        {
            if (state != null)
                if (state is IFixedUpdateble)
                    (state as IFixedUpdateble).FixedUpdate();
        }

        /// <summary>
        /// Пересчет бонусов от установленных улучшений
        /// </summary>
        private void RecalculateBonuses()
        {
            currentInfo = baseInfo;
            for (var i = 0; i < modulesList.Length; i++)
                modulesList[i]?.UpdateBonuses(ref currentInfo);
            
            for (var i = 0; i < weaponsList.Length; i++) 
                weaponsList[i]?.UpdateBonuses(ref currentInfo);// Оружие важно обновлять после обновления модулей
        }

        /// <summary>
        /// Вернуть текущие характеристики корабля (для отображение состояния в UI)
        /// </summary>
        /// <returns></returns>
        public ShipInfo GetCurrentInfo()
        { 
            return currentInfo;
        }

        /// <summary>
        /// Добавить модуль / оружие
        /// </summary>
        /// <param name="module"></param>
        /// <param name="idSlot"></param>
        internal void AddModule(AModule module, int idSlot)
        {
            if (module.type == ItemTypes.Weapons)
                weaponsList[idSlot] = module as WeaponModule;
            else if (module.type == ItemTypes.Modules)
                modulesList[idSlot] = module;
            
            RecalculateBonuses();
        }

        /// <summary>
        /// Запуск боя
        /// </summary>
        public void StartBatle()
        {
            this.AplyState(new BatleState());
        }
        public void PlayFireSound()
        {
            FireSound.Play();
        }

        /// <summary>
        /// Получили урон
        /// </summary>
        /// <param name="damag"></param>
        void IDamageble.SetDamage(float damag)
        {
            currentInfo.Shield -= damag;
            if (currentInfo.Shield < 0) // пробили щит?
            {
                currentInfo.HP += currentInfo.Shield;
                currentInfo.Shield = 0;
                if (currentInfo.HP < 0)
                {
                    Debug.Log($"Ship {name} is dead!");
                    AplyState(null); 
                    target.AplyState(null);
                }
            }
        }

        #region Реализация машины состояний

        /// <summary>
        /// Текущее состояние
        /// </summary>
        private IState state;

        /// <summary>
        /// Применить новое состояние
        /// </summary>
        /// <param name="state"></param>
        public void AplyState(IState newState)
        {
            if (state != null)
                if (state is IExitState)
                    (state as IExitState).OnExitState(); // если текущий стейт требует уведомления об изменении стейта

            state = newState; // применяем новый стейт

            if (state != null)
                if (state is IEnterState)
                    (state as IEnterState).OnEnter(this); // если новый стейт требует уведомления о получении управления
        }

        /// <summary>
        /// Получить текущее состояние
        /// </summary>
        /// <returns></returns>
        public IState GetState()
        {
            return state;
        }
        #endregion
    }
}