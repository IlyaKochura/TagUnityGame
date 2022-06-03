using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Action Delegate { get; set; }
    private Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener( () => Delegate.Invoke());
    }
    
    public void ChangeText(string newText)
    {
        GetComponentInChildren<Text>().text = newText;
    }
    
}
