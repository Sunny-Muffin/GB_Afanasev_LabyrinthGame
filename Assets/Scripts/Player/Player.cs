using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Labyrinth
{
    public class Player : MonoBehaviour, ICharacter
    {
        [SerializeField] private float _speed;

        private Rigidbody _rb;
        private int _keys = 0;
        
        //public float Speed { get; set; } 

        public Player(float speed)
        {
            _speed = speed;
        }

        private void Start()
        {
            if (TryGetComponent<Rigidbody>(out _rb))
            {
                //Log("Got rigidbody");
            }
        }

        public void IncreaseSpeed(float speedBonus, float bonusTime)
        {
            //Log("Increasing speed");
            _speed *= speedBonus;
            StartCoroutine(DecreaseSpeed(speedBonus, bonusTime));
        }


        public IEnumerator DecreaseSpeed(float speedBonus, float bonusTime)
        {
            yield return new WaitForSeconds(bonusTime);
            //Log("Decreasing speed");
            _speed /= speedBonus;
        }


        protected void Move(float x, float z)
        {
            Vector3 movement = new Vector3(x, 0.0f, z);
            _rb.AddForce(movement * _speed);
        }

        public void AddKey()
        {
            //Debug.Log($"{gameObject.name} collected key!");
            _keys++;
            if (_keys >= 2)
            {
                Log($"{gameObject.name} wins!");
            }
        }
    }
}
