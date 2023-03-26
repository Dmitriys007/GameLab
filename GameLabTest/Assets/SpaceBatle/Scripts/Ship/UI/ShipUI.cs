using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceBatle.UI
{
    public class ShipUI : MonoBehaviour
    {
        public Ship ship;

        [SerializeField] private TMP_Text HPText;
        [SerializeField] private TMP_Text ShieldText;
        [SerializeField] private TMP_Text WeaponsText;
        [SerializeField] private TMP_Text ModulesText;        
        [SerializeField] private SelectSlotButton selectSlotButtonPrefab;
        [SerializeField] private SelectItemMenu selectMenu;

        private void Start()
        {
            ShipInfo currentInfo = ship.GetCurrentInfo();

            for (var i = 0; i < currentInfo.WeaponSlot; i++)
            {
                var slot = Instantiate(selectSlotButtonPrefab, WeaponsText.transform);
                slot.Init(ItemTypes.Weapons, i);
                slot.OnClickedSlotEvent.AddListener(SlotSelect);
            }

            for (var i = 0; i < currentInfo.ModuleSlot; i++)
            {
                var slot = Instantiate(selectSlotButtonPrefab, ModulesText.transform);
                slot.Init(ItemTypes.Modules, i);
                slot.OnClickedSlotEvent.AddListener(SlotSelect);
            }

            Destroy(selectSlotButtonPrefab.gameObject);
        }

        public void Update()
        {
            ShipInfo currentInfo = ship.GetCurrentInfo();
            HPText.text = $"HP = {currentInfo.HP} / {currentInfo.MaxHP}";
            ShieldText.text = $"Shield = {currentInfo.Shield} / {currentInfo.MaxShield} (+ { 1 * currentInfo.ShieldReloadKoefficient} hp/s)";
            WeaponsText.text = $"Weapons: {currentInfo.WeaponSlot}";
            ModulesText.text = $"Modules: {currentInfo.ModuleSlot}";            
        }

        /// <summary>
        /// ¬ыбрали слот дл€ установки модул€ или оружи€
        /// </summary>
        private void SlotSelect(ItemTypes type, int idSlot)
        {
            selectMenu.ShowMenu(type, idSlot);
            selectMenu.OnModSelectedEvent.AddListener(OnModSelect);
        }

        private void OnModSelect(AModule module, int idSlot)
        {
            Debug.Log($"Slot selected: {idSlot} => {module.Name}");
            ship.AddModule(module, idSlot);
        }
    }
}