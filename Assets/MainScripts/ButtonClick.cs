using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts
{
    public class ButtonClick : MonoBehaviour
    {
        public Image _img;
        public TextMeshProUGUI text;
        public Action<int> Delegate { get; set; }
        private Button _button;
        public int id { get; set; }

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => Delegate.Invoke(id));
        }

        public void SetColor()
        {
            _img.color = Color.green;
        }

        public void ChangeText(string newText)
        {
            text.text = newText;
        }
    }
}