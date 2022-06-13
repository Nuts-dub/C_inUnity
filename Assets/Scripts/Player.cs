using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public sealed class Player : Unit, IRotation
    {
        private void Awake()
        {
            _transform = transform;

            if (GetComponent<Rigidbody>())
            {
                _rb = GetComponent<Rigidbody>();
            }

            isDead = false;
            Health = 100;
        }
        public override void Move(float x, float y, float z)
        {
            if(_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed * Time.fixedDeltaTime);
                transform.Translate(new Vector3(x, y, z) * Speed * Time.fixedDeltaTime);
                Rotate();
            }
            else
            {
                Debug.Log("NO Rgidbody");
            }
        }
        public void Rotate()
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }
    }
}