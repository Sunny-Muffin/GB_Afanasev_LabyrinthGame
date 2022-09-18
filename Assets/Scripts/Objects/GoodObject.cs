using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class GoodObject : InteractiveObject
    {
        [SerializeField] float speedBonus = 5f;
        [SerializeField] float bonusTime = 5f;

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            //Debug.Log("Bonus");
            player.IncreaseSpeed(speedBonus, bonusTime);
        }
    }
}
