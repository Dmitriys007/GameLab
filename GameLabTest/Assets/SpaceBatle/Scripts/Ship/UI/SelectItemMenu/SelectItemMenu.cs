using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceBatle.UI
{
    /// <summary>
    /// Меню выбора модуля / оружия
    /// </summary>
    public class SelectItemMenu : MonoBehaviour
    {
        /// <summary>
        /// Событие выбора модуля / оружия из меню
        /// </summary>
        public UnityEvent<AModule, int> OnModSelectedEvent;

        [SerializeField] private SelectItemButton buttonPrefab;
        [SerializeField] private RectTransform contentContainer;
        private ItemTypes slotsType;
        private int slotIndex;

        public void ShowMenu(ItemTypes typeSlot, int idSlot)
        {
            gameObject.SetActive(true);
            slotsType = typeSlot;
            slotIndex = idSlot;

            var list = ShopModules.GetModules(typeSlot);
            
            // Очищаем старые кнопки если есть
            for (var i = contentContainer.childCount - 1; i >= 0; i--)
                Destroy(contentContainer.GetChild(i).gameObject);
            
            // рождаем подходящие с подпиской на нажатия
            for (var i = 0; i < list.Count; i++)
            {
                var button = Instantiate(buttonPrefab, contentContainer);
                button.Init(list[i]);
                button.OnSelectEvent.AddListener(SelectCall);
            }
        }

        /// <summary>
        /// Выбрали подходящий модуль / оружие
        /// </summary>
        /// <param name="module"></param>
        private void SelectCall(AModule module)
        {
            OnModSelectedEvent.Invoke(module, slotIndex);
            OnModSelectedEvent.RemoveAllListeners();
            gameObject.SetActive(false);
        }
    }
}