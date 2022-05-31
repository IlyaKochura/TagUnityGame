using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject prefabButon;
    [SerializeField] private int fieldSize;
    [SerializeField] private GridLayoutGroup grid;
    private List<ButtonClick> _buttonList;
    
    void Start()
    {
        grid.constraintCount = fieldSize;
        for (int i = 0; i < _buttonList.Count; i++)
        {
            var id = i;
            _buttonList[i].Delegate = () => MoveButton(id);
        }
    }
    
    void Update()
    {
        
    }

    private void SpawnObject()
    {
        
    }

    private void MoveButton(int index)
    {
        
    }
}
