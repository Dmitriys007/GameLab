using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceBatle.UI
{
    /// <summary>
    ///  нопка дл€ выбора модул€/оружи€ в слот
    /// </summary>
    public class SelectSlotButton : MonoBehaviour
    {
        public UnityEvent<ItemTypes,int> OnClickedSlotEvent;
        public TMP_Text text;        

        private ItemTypes slotType;
        private int idSlot;

        public void Init(ItemTypes type, int idSlots)
        {
            slotType = type;
            idSlot = idSlots;
            text.text = $"Slot{idSlot}";
        }

        public void OnClick()
        {
            OnClickedSlotEvent.Invoke(slotType, idSlot);
        }
    }
}