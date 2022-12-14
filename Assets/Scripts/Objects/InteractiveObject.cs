using System;
using UnityEngine;

namespace Labyrinth
{
    [Serializable]
    public class InteractiveObject : MonoBehaviour
    {
        [HideInInspector] public string Name;
        [HideInInspector] public Vector3 position;
        [HideInInspector] public float X;
        [HideInInspector] public float Y;
        [HideInInspector] public float Z;
        
        public delegate void ObjectTouched(float time, float magnitude);

        private void Awake()
        {
            SaveSystem.objects.Add(this); // adding object to save list
        }

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
            (string name, float x, float y, float z) bonusInfo = GetBonus();
            Debug.Log($"bonus name: {bonusInfo.name}, x = {bonusInfo.x}, y = {bonusInfo.y}, z = {bonusInfo.z}");
        }

        protected virtual void Interaction(Player player)
        {
            
        }

        public (string name, float x, float y, float z) GetBonus()
        {
            return (Name, X, Y, Z);
        }
    }
}
