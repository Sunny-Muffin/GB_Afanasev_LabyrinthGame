using System;
using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class Mine : InteractiveObject
    {
        public delegate void CaughtPlayerChange(); // это делегат, который будет менять метод соприкосновения с игроком 
        public CaughtPlayerChange CaughtPlayer; // а это экземпляр делегата

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            try
            {
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
