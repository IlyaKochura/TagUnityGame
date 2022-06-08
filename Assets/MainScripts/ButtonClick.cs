using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts
{
    public class ButtonClick : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public Action<int> Delegate { get; set; }
        private Button _button;
        public int id { get; set; }
        public bool itIsImage = false;
    
        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener( () => Delegate.Invoke(id));
        }
    
        public void ChangeText(string newText)
        {
            text.text = newText;
        }
    
    }
}
