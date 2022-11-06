using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static Labyrinth.InteractiveObject;
using static UnityEngine.Debug;
using UnityEngine.UI;
using TMPro;

namespace Labyrinth
{
    public class Player : MonoBehaviour, ICharacter
    {
        [SerializeField, Range(1,10)] private float _speed;
        [SerializeField] private TextMeshProUGUI _speedText;

        public delegate void PlayerWins(GameObject gameObject); // ������� �������
        public static event PlayerWins PlayerVictory; // ����������� �������� ����� �������

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
            _speedText.text = $"{_speed}";
        }

        public void IncreaseSpeed(float speedBonus, float bonusTime)
        {
            //Log("Increasing speed");
            
            _speed *= speedBonus;
            _speedText.text = $"{_speed}";
            StartCoroutine(DecreaseSpeed(speedBonus, bonusTime));
        }


        public IEnumerator DecreaseSpeed(float speedBonus, float bonusTime)
        {
            yield return new WaitForSeconds(bonusTime);
            //Log("Decreasing speed");
            _speed /= speedBonus;
            _speedText.text = $"{_speed}";
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
                PlayerVictory?.Invoke(gameObject); // �������� �������
            }
        }


    }
}
