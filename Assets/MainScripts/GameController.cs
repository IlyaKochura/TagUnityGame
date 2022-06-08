using UnityEngine;
using System;
using System.Collections.Generic;
using MainScripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private ButtonClick prefabButon;
    [SerializeField] private Transform canvasPosition;
    [SerializeField] private int fieldSize;
    [SerializeField] private GridLayoutGroup grid;
    private List<ButtonClick> buttonList;

    private int _currentId = 15;

    void Start()
    {
        SpawnObject();
        
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
        var sizeField = Convert.ToInt32(Math.Pow(fieldSize, 2));
        var slot = Instantiate(prefabButon, canvasPosition);

        for (int i = 1; i <= sizeField; i++)
        {
            buttonList.Add(slot);
        }
    }

    

    private void MoveButton(int index)
    {
        
        if ((index + 1 == _currentId  && (_currentId % fieldSize) != 0) ||
             (index - 1 == _currentId && (_currentId + 1) % fieldSize != 0) ||
            index + fieldSize == _currentId ||
            index - fieldSize == _currentId)
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


// public int ItIsMark()
// {
//     for (int i = 0; i < buttonList.Count; i++)
//     {
//         if (buttonList[i].itIsImage)
//         {
//             return i;
//             break;
//         }
//     }
//     return 0;
// }