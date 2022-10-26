using Labyrinth;
using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    [Serializable]
    public class ObjectData
    {
        public string Name;

        public float X;
        public float Y;
        public float Z;

        public ObjectData(InteractiveObject io)
        {
            if (io.TryGetComponent<Keys>(out Keys keys))
            {
                Name = "key"; // yes, hardcoding... not proud of this
            }
            else if (io.TryGetComponent<Mine>(out Mine mine))
            {
                Name = "mine";
            }
            else if (io.TryGetComponent<GoodObject>(out GoodObject goodobject))
            {
                Name = "bonus";
            }
            else
            {
                Debug.LogError($"Object {io.name} doesn't have any scripts");
            }

            X = io.transform.position.x;
            Y = io.transform.position.y;
            Z = io.transform.position.z;
        }
    }
}
