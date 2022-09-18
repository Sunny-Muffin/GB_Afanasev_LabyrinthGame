using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Player1 : Player
    {
        public Player1(float speed) : base(speed)
        {

        }

        void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Move(x, y);
        }
    }
}
