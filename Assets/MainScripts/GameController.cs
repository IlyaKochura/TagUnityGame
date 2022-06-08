using UnityEngine;
using System;
using System.Collections.Generic;
using MainScripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject prefabButon;
    [SerializeField] private int fieldSize;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private List<ButtonClick> buttonList;

    private int _currentId = 15;

    void Start()
    {
        grid.constraintCount = fieldSize;
        for (int i = 0; i < buttonList.Count; i++)
        {
            var id = i;
            buttonList[i].id = i;
            buttonList[i].Delegate = MoveButton;
        }
    }
    
    private void SpawnObject()
    {

    }

    public int ItIsMark()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].itIsImage)
            {
                return i;
                break;
            }
        }
        return 0;
    }

    private void MoveButton(int index)
    {
        
        if ( (index + 1 == _currentId  && (_currentId % 4) != 0) ||
             (index - 1 == _currentId && (_currentId + 1) % 4 != 0) ||
            index + 4 == _currentId ||
            index - 4 == _currentId 
           )
        {
            var pos1 = GetButtonById(index).transform.localPosition;
            var pos2 = GetButtonById(_currentId).transform.localPosition;
            GetButtonById(index).transform.localPosition = pos2;
            GetButtonById(_currentId).transform.localPosition = pos1;

            var b1 = GetButtonById(index);
            var b2 = GetButtonById(_currentId);
            b1.id = _currentId;
            b2.id = index;
            
            _currentId = index;
            
        }
    }

    private ButtonClick GetButtonById(int id)
    {
        foreach (var button in buttonList)
        {
            if (button.id == id)
                return button;
        }

        return null;
        
    }
}
