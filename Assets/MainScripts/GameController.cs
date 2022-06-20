using System;
using UnityEngine;
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
    [SerializeField] private GameObject winEnscription;
    private List<ButtonClick> _buttonList;
    private List<ButtonClick> _variableMove = new();
    private int _currentId;

    void Start()
    {
        _buttonList = new List<ButtonClick>(fieldSize * fieldSize);
        grid.constraintCount = fieldSize;
        for (int i = 0; i < fieldSize * fieldSize; i++)
        {
            mixingButton.action = () => MixMove();
            var slot = Instantiate(prefabButon, canvasPosition);
            _buttonList.Add(slot);
            _buttonList[i].id = i;
            _buttonList[i].Delegate = MoveButton;
            _buttonList[i].ChangeText((i + 1).ToString());
            if (i == fieldSize * fieldSize - 1)
            {
                _buttonList[i].ChangeText("");
            }
        }
        
        _currentId = _buttonList.Count - 1;
        VariableMove();
    }
    private void MoveButton(int index)
    {
        if ((index + 1 == _currentId && (_currentId % fieldSize) != 0) ||
            (index - 1 == _currentId && (_currentId + 1) % fieldSize != 0) ||
            index + fieldSize == _currentId ||
            index - fieldSize == _currentId)
        {
            Movement(index);
        }

        if (WinBool())
        {
            winEnscription.SetActive(true);
        }
    }

    private ButtonClick GetButtonById(int id)
    {
        foreach (var button in _buttonList)
        {
            if (button.id == id)
                return button;
        }
        return null;
    }

    private void VariableMove()
    {
        _variableMove.Clear();
        for (int i = 0; i < _buttonList.Count; i++)
        {
            if ((_buttonList[i].id + 1 == _currentId && (_currentId % fieldSize) != 0) ||
                (_buttonList[i].id - 1 == _currentId && (_currentId + 1) % fieldSize != 0) ||
                _buttonList[i].id + fieldSize == _currentId ||
                _buttonList[i].id - fieldSize == _currentId)
            {
                _variableMove.Add(_buttonList[i]);
            }
        }
    }

    private void MixMove()
    {
        for (int i = 0; i < 200; i++)
        {
            Random rnd = new Random();
            var rand = rnd.Next( 0, _variableMove.Count);
            Movement(_variableMove[rand].id);
        }
    }
     
    private void Movement(int index)
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
        
        VariableMove();
    }
    
    private bool WinBool()
    {
        for (int i = 0; i < _buttonList.Count; i++)
        {
            if (i != _buttonList[i].id)
            {
                return false;
            }
        }
        return true;
    }
}