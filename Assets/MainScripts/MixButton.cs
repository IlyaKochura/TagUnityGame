using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MainScripts
{
    public class MixButton : MonoBehaviour
    {
        public Action action { get; set; }
        private Button _button;
        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener( () => action.Invoke());
        }
    }
}