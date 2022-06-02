using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject prefabButon;
    [SerializeField] private int fieldSize;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private List<ButtonClick> buttonList;
    
    void Start()
    {
        grid.constraintCount = fieldSize;
        for (int i = 0; i < buttonList.Count; i++)
        {
            var id = i;
            buttonList[i].Delegate = () => MoveButton(id);
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
