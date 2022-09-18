using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rb;

        //public float Speed { get; set; } = 3.0f;

        public Player(float speed)
        {
            _speed = speed;

        }

        private void Start()
        {
            if (TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("Got rigidbody");
            }
        }

        protected void Move(float x, float z)
        {
            Vector3 movement = new Vector3(x, 0.0f, z);
            _rb.AddForce(movement * _speed);
        }
    }
}
