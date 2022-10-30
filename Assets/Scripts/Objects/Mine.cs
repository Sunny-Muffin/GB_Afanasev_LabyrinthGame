using System;
using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class Mine : InteractiveObject
    {
        public delegate void CaughtPlayerChange(); // это делегат, который будет менять метод соприкосновения с игроком 
        public CaughtPlayerChange CaughtPlayer; // а это экземпляр делегата
        public static event ObjectTouched OnTouched; // это событие

        [SerializeField, Range(0, 1)] private float cameraShakeTime = .4f;
        [SerializeField, Range(0, 2)] private float cameraShakeMagnitude = 1f;

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            try
            {
                OnTouched?.Invoke(cameraShakeTime, cameraShakeMagnitude);
                CaughtPlayer?.Invoke(); // а вот тут вызывается тот самый делегат, в который я натолкаю методов (или уже натолкал)
                // если использовать знак "?" то можно без try catch, но я оставил для домашки
            }
            catch (Exception ex)
            {
                Debug.Log("Caught exception: " + ex);
            }
            Destroy(player.gameObject);
        }
    }
}
