using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class GoodObject : InteractiveObject
    {
        [SerializeField, Tooltip ("Amount of speed, that will add to player's speed")] float speedBonus = 5f;
        [SerializeField, Tooltip("Period of time, in witch bonus works")] float bonusTime = 5f;

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            //Debug.Log("Bonus");
            player.IncreaseSpeed(speedBonus, bonusTime);
        }
    }
}
