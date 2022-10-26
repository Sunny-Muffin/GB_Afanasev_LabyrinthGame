using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

namespace Labyrinth
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] Keys keyPrefab;
        [SerializeField] Mine minePrefab;
        [SerializeField] GoodObject goodObjectPrefab;

        public static List<InteractiveObject> objects = new List<InteractiveObject>();
        const string fileName = "/obj";
        const string fileCount = "/obj.count";

        public void SaveObject()
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + fileName + SceneManager.GetActiveScene().buildIndex;
            
            string countPath = Application.persistentDataPath + fileCount + SceneManager.GetActiveScene().buildIndex;
            FileStream countStream = new FileStream(countPath, FileMode.Create);
            bf.Serialize(countStream, objects.Count);
            countStream.Close(); // this block is saving the ammount of objects that we saved


            for (int i = 0; i < objects.Count; i++)
            {
                FileStream fs = new FileStream(path + i, FileMode.Create);
                ObjectData data = new ObjectData(objects[i]);
                bf.Serialize(fs, data);
                fs.Close();
            }
        }
        
        public void LoadObject()
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + fileName + SceneManager.GetActiveScene().buildIndex;
            string countPath = Application.persistentDataPath + fileCount + SceneManager.GetActiveScene().buildIndex;
            int objCount = 0;

            if (File.Exists(countPath))
            {
                FileStream countStream = new FileStream(countPath, FileMode.Open);
                objCount = (int)bf.Deserialize(countStream);
                countStream.Close();
            }
            else
            {
                Debug.LogError("File not found in " + countPath);
            }

            for (int i = 0; i < objCount; i++)
            {
                if (File.Exists(path + 1))
                {
                    FileStream stream = new FileStream(path + i, FileMode.Open);
                    ObjectData data = bf.Deserialize(stream) as ObjectData;
                    stream.Close();

                    Vector3 position = new Vector3(data.X, data.Y, data.Z); 
                    
                    if (data.Name == "key")
                    { 
                        Keys key = Instantiate(keyPrefab, position, Quaternion.identity);
                    }
                    else if (data.Name == "mine")
                    {
                        Mine mine = Instantiate(minePrefab, position, Quaternion.identity);
                    }
                    else if (data.Name == "bonus")
                    {
                        GoodObject goodObject = Instantiate(goodObjectPrefab, position, Quaternion.identity);
                    }
                }
                else
                {
                    Debug.LogError("File not found in " + path + i);
                }
            }
        }
    }
}
