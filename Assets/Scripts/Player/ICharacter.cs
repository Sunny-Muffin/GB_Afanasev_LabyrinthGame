using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public interface ICharacter
    {
        public void AddKey()
        {
            Debug.Log("Interface works!");
        }

        public void IncreaseSpeed(float speedBonus, float bonusTime)
        {

        }

        public IEnumerator DecreaseSpeed(float speedBonus, float bonusTime)
        {
            yield return new WaitForSeconds(bonusTime);

        }
    }
}
