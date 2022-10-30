using UnityEditor;
using UnityEngine;

namespace Lesson9
{
    public class MyWindow : EditorWindow
    {
        public string randomText;

        private void OnGUI()
        {
            GUILayout.Label("My window lable", EditorStyles.boldLabel);
            randomText = EditorGUILayout.TextField("Enter text to print: ", randomText);
            var button = GUILayout.Button("Log random text");
            if (button)
            {
                Debug.Log($"Your random text: {randomText}");
            }
        }
    } 
}
