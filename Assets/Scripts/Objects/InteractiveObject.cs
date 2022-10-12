using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class InteractiveObject : MonoBehaviour
    {
        public delegate void ObjectTouched(float time, float magnitude);

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
