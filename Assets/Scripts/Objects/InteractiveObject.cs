using System;
using UnityEngine;

namespace Labyrinth
{
    [Serializable]
    public class InteractiveObject : MonoBehaviour
    {
        public string Name;
        public Vector3 position;
        public float X;
        public float Y;
        public float Z;
        
        public delegate void ObjectTouched(float time, float magnitude);


        private void Start()
        {
            Name = gameObject.name;
            position = gameObject.transform.position;
            X = position.x;
            Y = position.y;
            Z = position.z;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                Interaction(player);
                Destroy(gameObject);
            }

        }

        protected virtual void Interaction(Player player)
        {
            
        }
    }
}
