using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Keys : InteractiveObject
    {


        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            //Debug.Log("Key collected");
            player.AddKey();
            // sound
            // particle system

        }
    }
}
