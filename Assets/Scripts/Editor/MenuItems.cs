using UnityEngine;
using UnityEditor;

namespace Lesson9
{
    public class MenuItems : MonoBehaviour
    {
        [MenuItem("MyMenu/MyWindow #0")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "MyWindow");
        }

        [MenuItem("MyMenu/Debug.Log something #1")]
        private static void PrintSmth()
        {
            Debug.Log("Congrats, you printed something through menu!");
        }


    }
}
