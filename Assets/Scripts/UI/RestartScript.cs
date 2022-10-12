using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth
{
    public class RestartScript : MonoBehaviour
    {
        public void RestartLevel()
        {
            
            SceneManager.LoadScene(0);
        }

    }
}
