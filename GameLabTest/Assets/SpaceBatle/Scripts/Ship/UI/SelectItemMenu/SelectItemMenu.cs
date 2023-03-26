using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceBatle.UI
{
    /// <summary>
    /// ���� ������ ������ / ������
    /// </summary>
    public class SelectItemMenu : MonoBehaviour
    {
        /// <summary>
        /// ������� ������ ������ / ������ �� ����
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
            
            // ������� ������ ������ ���� ����
            for (var i = contentContainer.childCount - 1; i >= 0; i--)
                Destroy(contentContainer.GetChild(i).gameObject);
            
            // ������� ���������� � ��������� �� �������
            for (var i = 0; i < list.Count; i++)
            {
                var button = Instantiate(buttonPrefab, contentContainer);
                button.Init(list[i]);
                button.OnSelectEvent.AddListener(SelectCall);
            }
        }

        /// <summary>
        /// ������� ���������� ������ / ������
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