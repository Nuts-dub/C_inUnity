using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Reference
    {
        private GameObject _restartButton;
        private Canvas _canvas;

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    GameObject Prefab = Resources.Load<GameObject>("UI/RestartGameBt");
                    _restartButton = Object.Instantiate(Prefab, Canvas.transform);
                }
                return _restartButton;
            }
            set { _restartButton = value; }
        }

        public Canvas Canvas
        {
            get { 
                if(_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
            set { _canvas = value; }
        }
    }
}