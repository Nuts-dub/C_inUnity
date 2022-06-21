using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;
        private Reference _reference;

        [SerializeField] private BadBonus badBonus;
        [SerializeField] private GoodBonus goodBonus;

        [SerializeField] private GameObject _player;
        //[SerializeField] private Button _restartButton;
        //[SerializeField] private Button _exitGameButton;

        void Awake()
        {
            _reference = new Reference();

            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();


            //_restartButton.onClick.AddListener(RestartGame);

            //_restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);

            badBonus.OnCaughtPlayer += GameOver;
            goodBonus.AddPoints += bonusPoints;
        }

        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
        }

        public void bonusPoints(int i)
        {
            Debug.Log("points: " + i);
        }

        //private void RestartGame()
        //{
        //    SceneManager.LoadScene(0);
        //}    

        void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }
        }
    }
}