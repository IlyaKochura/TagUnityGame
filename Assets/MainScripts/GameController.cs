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
        for (int i = 0; i < buttonList.Count - 1; i++)
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
        Debug.LogError("Сработал");

        var pos1 = buttonList[index].transform.localPosition;
        var pos2 = buttonList[15].transform.localPosition;
        buttonList[index].transform.localPosition = new Vector3(pos2.x,pos2.y);
        buttonList[15].transform.localPosition = new Vector3(pos1.x, pos1.y);
    }
}
