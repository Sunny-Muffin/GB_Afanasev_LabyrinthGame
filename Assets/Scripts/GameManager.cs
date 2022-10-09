using System;
using TMPro;
using UnityEngine;

namespace Labyrinth
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gameOverText;
        private PlayerGameOver _playerGameOver;
        private ListInteractableObject _listInteractableObject;

        private void Awake()
        {
            _listInteractableObject = new ListInteractableObject();
            try
            {
                _playerGameOver = new PlayerGameOver(_gameOverText);
            }
            catch (Exception ex)
            {
                Debug.Log("Caught exception: " + ex);
            }
            
            foreach (var obj in _listInteractableObject)
            {
                if(obj is Mine mine)
                {
                    mine.CaughtPlayer += PlayerDeath; // ��� ��� ����������� ������ � �������
                    mine.CaughtPlayer += _playerGameOver.GameOver;
                }
            }
        }

        private void PlayerDeath()
        {
            // particle system
            // sound
            Dispose(); // ��� ��������? ��� �������� ��?
            //Time.timeScale = 0.0f; // �� ���� �������� ��� ��������� �������, �������� ���������, ���� �������� ��� ��� ��������
        }

        public void Dispose() // � ��������� �� ����������, ��� ��� �������� ��?
        {
            foreach (var o in _listInteractableObject)
            {
                if (o is InteractiveObject interactiveObject)
                {

                    if (o is Mine mine)
                    {
                        mine.CaughtPlayer -= PlayerDeath; // ��� ������ ��������� �� ��������, ������ ��� ��� �������� �������?
                        mine.CaughtPlayer -= _playerGameOver.GameOver;
                    }
                }
            }
        }
    }
}
