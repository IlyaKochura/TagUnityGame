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
            buttonList[i].id = i;
            buttonList[i].Delegate = MoveButton;
        }
    }

    void Update()
    {

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
        if ((index + 1 <= buttonList.Count && buttonList[index + 1].itIsImage) || 
            (index - 1 >= 0 && buttonList[index - 1].itIsImage) ||
            (index - 4 >= 0 && buttonList[index - 4].itIsImage)|| 
            (index + 4 <= buttonList.Count && buttonList[index + 4].itIsImage))
        {
            var pos1 = buttonList[index].transform.localPosition;
            var pos2 = buttonList[ItIsMark()].transform.localPosition;
            buttonList[index].transform.localPosition = new Vector3(pos2.x, pos2.y);
            buttonList[ItIsMark()].transform.localPosition = new Vector3(pos1.x, pos1.y);


            var posit = ItIsMark();

            var but1 = buttonList[index];
            buttonList[index] = buttonList[posit];
            buttonList[posit] = but1;

            buttonList[index].id = index;
            buttonList[posit].id = posit;

        }
    }
}
