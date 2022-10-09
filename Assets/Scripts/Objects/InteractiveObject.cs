using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class InteractiveObject : MonoBehaviour
    {
        public delegate void ObjectTouched(float time, float magnitude);
        public static event ObjectTouched OnTouched; // это событие

        [SerializeField] private float cameraShakeTime = .4f;
        [SerializeField] private float cameraShakeMagnitude = 1f;


        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                OnTouched?.Invoke(cameraShakeTime, cameraShakeMagnitude);
                Interaction(player);
                Destroy(gameObject);
            }

        }

        protected virtual void Interaction(Player player)
        {
            
        }
    }
}
