using System.IO;
using UnityEngine;
using UnityEngine.Rendering;


public class PlayerInfo
{
    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;

}



public class JsonUtilityTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //save
            PlayerInfo obj = new PlayerInfo
            {
                playerName = "ABC",
                lives = 10,
                health = 10.999f,
                position = new Vector3(1f, 2f, 3f)
            };

            string pathFoler = Path.Combine(
                Application.persistentDataPath, 
                "JsonTest");

            if(!Directory.Exists(pathFoler))
            {
                Directory.CreateDirectory(pathFoler);
            }

            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "player.Json");

            string json = JsonUtility.ToJson(obj, prettyPrint: true);
            File.WriteAllText(path, json);

            Debug.Log(path);
            Debug.Log(json);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //load
            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "player.Json");

            string json = File.ReadAllText(path);
            //PlayerInfo obj = JsonUtility.FromJson<PlayerInfo>(json);
            PlayerInfo obj = new PlayerInfo();
            JsonUtility.FromJsonOverwrite(json, obj);
            

            Debug.Log($"{obj.playerName} / {obj.health}");
        }
    }
}
