using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts
{
    public class StartButton : MonoBehaviour
    {
        public Action Action { get; set; }
        private Button _button;
        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener( () => Action.Invoke());
        }
    }
}