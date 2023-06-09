using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceBatle
{
    /// <summary>
    /// Магазин со всеми модулями
    /// </summary>
    public class ShopModules
    {
        private static ShopModules instance { get { if (savedLink == null) savedLink = new ShopModules(); return savedLink; } }
        private static ShopModules savedLink;

        public List<AModule> modulesList { get; private set; } = new List<AModule>();

        public ShopModules()
        {
            modulesList.Add(new WeaponModule() 
            { 
                Name = "Пушка А",
                ReloadTime = 3.0f,
                Damage = 5.0f,
            });
            modulesList.Add(new WeaponModule()
            {
                Name = "Пушка Б",
                ReloadTime = 2.0f,
                Damage = 4.0f,
            });
            modulesList.Add(new WeaponModule()
            {
                Name = "Пушка В",
                ReloadTime = 5.0f,
                Damage = 20.0f,
            });

            modulesList.Add(new ShieldExpansionModule()
            {
                Name = "Модуль А",
                BusterShieldValue = 50,
            });

            modulesList.Add(new HPExpandModule()
            {
                Name = "Модуль Б",
                BusterHPValue = 50,
            });

            modulesList.Add(new WeaponReloadModule()
            {
                Name = "Модуль C",
                ReloadKoefficient = 0.8f,
            });

            modulesList.Add(new ShieldRechangerModule()
            {
                Name = "Модуль Д",
                BustKoefficient = 1.2f,
            });            
        }

        /// <summary>
        /// Вернуть список доступных модулей заданного типа
        /// </summary>
        /// <returns></returns>
        public static List<AModule> GetModules(ItemTypes type)
        {
            List<AModule> modules = new List<AModule>();
            List<AModule> fullList = instance.modulesList;

            for (var i = 0; i < fullList.Count; i++)
                if (fullList[i].type == type )
                    modules.Add(fullList[i]);

            return modules;
        }
    }
}