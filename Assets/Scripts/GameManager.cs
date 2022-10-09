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
                    mine.CaughtPlayer += PlayerDeath; // вот тут заталкиваем методы в делегат
                    mine.CaughtPlayer += _playerGameOver.GameOver;
                }
            }
        }

        private void PlayerDeath()
        {
            // particle system
            // sound
            Dispose(); // тут вызывать? √де вызывать то?
            //Time.timeScale = 0.0f; // не хочу вызывать тут остановку времени, проблемы возникают, надо подумать как это обернуть
        }

        public void Dispose() // с диспоузом не разобралс€, где его вызывать то?
        {
            foreach (var o in _listInteractableObject)
            {
                if (o is InteractiveObject interactiveObject)
                {

                    if (o is Mine mine)
                    {
                        mine.CaughtPlayer -= PlayerDeath; // тут методы удал€ютс€ из делегата, только вот где вызывать диспоуз?
                        mine.CaughtPlayer -= _playerGameOver.GameOver;
                    }
                }
            }
        }
    }
}
