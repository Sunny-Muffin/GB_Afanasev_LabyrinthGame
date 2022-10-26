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
            Name = io.gameObject.name;
            X = io.transform.position.x;
            Y = io.transform.position.y;
            Z = io.transform.position.z;
        }
    }
}
