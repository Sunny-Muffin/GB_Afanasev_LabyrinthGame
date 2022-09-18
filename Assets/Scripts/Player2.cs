using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Player2 : Player
    {
        public Player2(float speed) : base(speed)
        {

        }

        void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal2");
            float y = Input.GetAxis("Vertical2");
            Move(x, y);
        }
    }
}
