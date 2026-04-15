using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerState
{
    public string playerName;
    public int lives;
    public float health;

    [JsonConverter(typeof(Vector3Converter))]
    public Vector3 position;

    public override string ToString()
    {
        return $"{playerName} / {lives} / {health} / {position}";
    }
}

public class JsonTest1 : MonoBehaviour
{
    private JsonSerializerSettings jsonSetting;

    private void Awake()
    {
        jsonSetting = new JsonSerializerSettings();
        jsonSetting.Formatting = Formatting.Indented;
        jsonSetting.Converters.Add(new Vector3Converter());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //save
            PlayerState obj = new PlayerState
            {
                playerName = "ABC",
                lives = 10,
                health = 10.999f,
                position = new Vector3(1f, 2f, 3f)
            };

            string pathFoler = Path.Combine(
                Application.persistentDataPath,
                "JsonTest");

            if (!Directory.Exists(pathFoler))
            {
                Directory.CreateDirectory(pathFoler);
            }

            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "player2.Json");

            string json = JsonConvert.SerializeObject(obj, jsonSetting);
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
                "player2.Json");

            string json = File.ReadAllText(path);
            PlayerState obj = JsonConvert.DeserializeObject<PlayerState>(json , jsonSetting);
                
            Debug.Log(json);
            Debug.Log(obj);
        }
    }
}
