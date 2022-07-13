using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public struct PlayerData
    {
        public string PlayerName;
        public int PlayerHealth;
        public bool PlayerDead;
        public SVect3 PlayerPosition;
        public int PlayerBonus;
    }

    public sealed class Player : Unit, IRotation
    {
        PlayerData SinglePlayerData = new PlayerData();
        Main main = new Main();

        private ISaveData _data;

        private void Awake()
        {
            _transform = transform;

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }

            isDead = false;
            Health = 100;

            SinglePlayerData.PlayerHealth = Health;
            SinglePlayerData.PlayerDead = isDead;
            SinglePlayerData.PlayerName = gameObject.name;
            SinglePlayerData.PlayerBonus = main.bonusScore;

            _data = new JSONData();
            _data.SaveData(SinglePlayerData);

            
        }
        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed * Time.fixedDeltaTime);
                transform.Translate(new Vector3(x, y, z) * Speed * Time.deltaTime);
                Rotate();
            }
            else
            {
                Debug.Log("NO Rgidbody");
            }

            SinglePlayerData.PlayerPosition = _transform.position;
        }
        public void Rotate()
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.deltaTime, 0));
        }

        public override void SavePlayer()
        {
            _data.SaveData(SinglePlayerData);
            PlayerData NewPlayer = _data.Load();

            Debug.Log(NewPlayer.PlayerName);
            Debug.Log(NewPlayer.PlayerPosition);
            Debug.Log(NewPlayer.PlayerHealth);
            Debug.Log(NewPlayer.PlayerBonus);
        }
    }
}