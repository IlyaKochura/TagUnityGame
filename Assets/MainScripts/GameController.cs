using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace MainScripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ButtonClick prefabButon;
        [SerializeField] private Transform canvasPosition;
        [SerializeField] private int fieldWidth;
        [SerializeField] private int fieldLength;
        [SerializeField] private GridLayoutGroup grid;
        [SerializeField] private MixButton mixingButton;
        [SerializeField] private GameObject winEnscription;
        [SerializeField] private Restart restart;
        [SerializeField] private StartButton start;
        [SerializeField] private GameObject startButton;
        private List<ButtonClick> _buttonList;
        private int _currentId;
        private bool _game = false;

        void Start()
        {
            _buttonList = new List<ButtonClick>(fieldWidth * fieldLength);
            grid.constraintCount = fieldLength;
            for (int i = 0; i < fieldWidth * fieldLength; i++)
            {
                var slot = Instantiate(prefabButon, canvasPosition);
                _buttonList.Add(slot);
                _buttonList[i].ID = i;
                _buttonList[i].Delegate = MoveButton;
                _buttonList[i].ChangeText((i + 1).ToString());
                if (i == fieldWidth * fieldLength - 1)
                {
                    _buttonList[i].ChangeText("");
                }
            }
            start.Action = () => Start();
            restart.Action = () => Restart();
            mixingButton.Action = () => MixMove();
            _currentId = _buttonList.Count - 1;
            VariableMove();
        }

        private void MoveButton(int index)
        {
            if (_game)
            {
                if ((index + 1 == _currentId && (_currentId % fieldLength) != 0) ||
                    (index - 1 == _currentId && (_currentId + 1) % fieldLength != 0) ||
                    index + fieldLength == _currentId ||
                    index - fieldLength == _currentId)
                {
                    Movement(index);
                }
                if (WinBool())
                {
                    winEnscription.SetActive(true);
                    _game = false;
                }
            }
        }

        private ButtonClick GetButtonById(int id)
        {
            foreach (var button in _buttonList)
            {
                if (button.ID == id)
                    return button;
            }
            return null;
        }

        private List<ButtonClick> VariableMove()
        {
            var array = new List<ButtonClick>(4);
            for (int i = 0; i < _buttonList.Count; i++)
            {
                if ((_buttonList[i].ID + 1 == _currentId && (_currentId % fieldLength) != 0) ||
                    (_buttonList[i].ID - 1 == _currentId && (_currentId + 1) % fieldLength != 0) ||
                    _buttonList[i].ID + fieldLength == _currentId ||
                    _buttonList[i].ID - fieldLength == _currentId)
                {
                    array.Add(_buttonList[i]);
                }
            }
            return array;
        }

        private void MixMove()
        {
            for (int i = 0; i < 200; i++)
            {
                Random rnd = new Random();
                var rand = rnd.Next(0, VariableMove().Count);
                Movement(VariableMove()[rand].ID);
            }
        }

        private void Movement(int index)
        {
            if (_game)
            {
                var pos1 = GetButtonById(index).transform.localPosition;
                var pos2 = GetButtonById(_currentId).transform.localPosition;
                GetButtonById(index).transform.localPosition = pos2;
                GetButtonById(_currentId).transform.localPosition = pos1;

                var b1 = GetButtonById(index);
                var b2 = GetButtonById(_currentId);
                b1.ID = _currentId;
                b2.ID = index;

                _currentId = index;

                VariableMove();
            }
        }

        private bool WinBool()
        {
            for (int i = 0; i < _buttonList.Count; i++)
            {
                if (i != _buttonList[i].ID)
                {
                    return false;
                }
            }
            return true;
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void StartGame()
        {
            _game = true;
            startButton.SetActive(false);
        }
    }
}