using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceBatle.UI
{
    /// <summary>
    /// Кнопка выбора модуля / оружия
    /// </summary>
    public class SelectItemButton : MonoBehaviour
    {
        public UnityEvent<AModule> OnSelectEvent;

        [SerializeField] private TMP_Text nameText;
        
        private AModule module;

        public void Init(AModule mod)
        {
            module = mod;
            nameText.text = mod.Name;
        }

        public void OnClick()
        { 
            OnSelectEvent.Invoke(module);
        }
    }
}