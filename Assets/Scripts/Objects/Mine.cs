using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Mine : InteractiveObject
    {
        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            Debug.Log("BOOM!");
            // sound
            // particle system
            Destroy(player.gameObject);
        }
    }
}
