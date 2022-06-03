using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
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
        GetComponentInChildren<Text>().text = newText;
    }
    
}
