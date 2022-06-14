using UnityEngine;
using System;
using System.Collections.Generic;
using MainScripts;
using UnityEngine.UI;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private ButtonClick prefabButon;
    [SerializeField] private Transform canvasPosition;
    [SerializeField] private int fieldSize;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private MixButton mixingButton;
    [SerializeField] private List<ButtonClick> buttonList;


    private int _currentId;

    void Start()
    {
        buttonList = new List<ButtonClick>(fieldSize * fieldSize);
        grid.constraintCount = fieldSize;
        for (int i = 0; i < fieldSize * fieldSize; i++)
        {
            var slot = Instantiate(prefabButon, canvasPosition);


            buttonList.Add(slot);
            buttonList[i].ChangeText((i + 1).ToString());

            if (i == fieldSize * fieldSize - 1)
            {
                buttonList[i].ChangeText("");
            }
        }
        
        mixingButton.action = MixingCells;
        
        for (int i = 0; i < fieldSize * fieldSize; i++)
        {
            var id = i;
            buttonList[i].id = i;
            buttonList[i].Delegate = MoveButton;
        }
        
    }

    private void Update()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].text.text == "")
            {
                _currentId = i;
            }
        }
    }

    private void MoveButton(int index)
    {
        Debug.LogError(index);

        if ((index + 1 == _currentId && (_currentId % fieldSize) != 0) ||
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

    private void MixingCells()
    {
        Random rnd = new Random();

        Debug.LogError(buttonList.Count);

        for (int i = 0; i < fieldSize * fieldSize; i++)
        {
            var RND = rnd.Next(0, fieldSize * fieldSize - 1);
            var posI = buttonList[i].text.text;
            var posRND = buttonList[RND].text.text;
            
            buttonList[i].text.text = posRND;
            buttonList[RND].text.text = posI;
            
        }
        
    }
}