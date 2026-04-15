using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

[System.Serializable]
public class SomeClass
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;
}

[System.Serializable]
public class ObjectSaveData
{
    public string prefabName;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;
}

public class JsonPractice : MonoBehaviour
{

    //SomeClass some;
    //string strjson;
    //private JsonSerializerSettings jsonSetting;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Awake()
    //{
    //    jsonSetting = new JsonSerializerSettings();
    //    jsonSetting.Formatting = Formatting.Indented;
    //    jsonSetting.Converters.Add(new Vector3Converter());
    //    jsonSetting.Converters.Add(new QuaternionConverter());
    //    jsonSetting.Converters.Add(new ColorConverter());


    //    some = new SomeClass
    //    {
    //        pos = new Vector3(1f, 2f, 3f),
    //        rot = new Quaternion(1f, 2f, 3f, 4f),
    //        scale = new Vector3(1f, 1f, 1f),
    //        color = new Color(1f, 1f, 1f, 1f)
    //    };

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        //직렬화
    //        strjson = JsonConvert.SerializeObject(some, jsonSetting);

    //        Debug.Log(strjson);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        SomeClass som = JsonConvert.DeserializeObject<SomeClass>(strjson, jsonSetting);

    //        Debug.Log(som); 
    //    }
    //}


    public string fileName = "test.json";
    public string FileFullPath => Path.Combine(Application.persistentDataPath, "JsonTest", fileName);

    public string[] prefabNames =
    {
        "Cube",
        "Sphere",
        "Capsule",
        "Cylinder"
    };

    public JsonSerializerSettings  jsonSettings;

    private void Awake()
    {
        jsonSettings = new JsonSerializerSettings();
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.Converters.Add(new Vector3Converter());
        jsonSettings.Converters.Add(new QuaternionConverter());
        jsonSettings.Converters.Add(new ColorConverter());
    }

    public void Save()
    {
        //cubes = GameObject.FindGameObjectsWithTag("Player");
        //SomeClass[] obj = new SomeClass[cubes.Length];
        //for(int i=0; i<cubes.Length; i++)
        //{
        //    obj[i] = new SomeClass();
        //    obj[i].pos = cubes[i].transform.position;
        //    obj[i].rot = cubes[i].transform.rotation;
        //    obj[i].scale = cubes[i].transform.localScale;
        //    obj[i].color = cubes[i].GetComponent<Renderer>().material.color;
        //}

        //var json = JsonConvert.SerializeObject(obj, jsonSettings);
        //File.WriteAllText(FileFullPath, json);
        var saveList = new List<ObjectSaveData>();
        var objs = GameObject.FindGameObjectsWithTag("TestObject");
        foreach (var obj in objs)
        {
            var jsonTestObj = obj.GetComponent<JsonTestObject>();
            saveList.Add(jsonTestObj.GetSaveData());
        }
        var json = JsonConvert.SerializeObject(saveList, jsonSettings);
        File.WriteAllText(FileFullPath, json);
    }

    public void Load()
    {
        //var json = File.ReadAllText(FileFullPath);
        //var obj = JsonConvert.DeserializeObject<SomeClass[]>(json, jsonSettings);

        //foreach (var c in GameObject.FindGameObjectsWithTag("Player"))
        //{
        //    Destroy(c);
        //}

        //cubes = new GameObject[obj.Length];

        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    GameObject newCube = Instantiate(cube);
        //    newCube.transform.position = obj[i].pos;
        //    newCube.transform.rotation = obj[i].rot;
        //    newCube.transform.localScale = obj[i].scale;
        //    newCube.GetComponent<Renderer>().material.color = obj[i].color;

        //    newCube.tag = "Player";
        //}
        // Debug.Log(obj);

        Clear();

        var json = File.ReadAllText(FileFullPath);
        var saveList = JsonConvert.DeserializeObject<List<ObjectSaveData>>(json, jsonSettings);

        foreach (var saveData in saveList)
        {
            var prefab = Resources.Load<JsonTestObject>(saveData.prefabName);
            var jsonTestObj = Instantiate(prefab);
            jsonTestObj.Set(saveData);
        }

    }

    private void CreateRandomObject()
    {
        var prefabName = prefabNames[Random.Range(0, prefabNames.Length)];
        var prefab = Resources.Load<JsonTestObject>(prefabName);
        var obj = Instantiate(prefab);
        obj.transform.position = Random.insideUnitSphere * 10f;
        obj.transform.rotation = Random.rotation;
        obj.transform.localScale = Vector3.one * Random.Range(0.5f, 3f);
        obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Create()
    {
        //for(int i = 0; i <10 ; i++)
        //{
        //    Vector3 cubesPos = new Vector3(Random.Range(-10, 11), 
        //        Random.Range(-5, 6), 0);
        //    GameObject newCube = Instantiate(cube, cubesPos, 
        //        Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), 0f));

        //    newCube.tag = "Player";
        //}
        for(int i = 0;i < 10; i++)
        {
            CreateRandomObject();
        }
    }

    public void Clear()
    {
        //cubes = GameObject.FindGameObjectsWithTag("Player");
        //for(int i = 0; i<cubes.Length; i++)
        //{
        //    Destroy(cubes[i]);
        //}
        var objs = GameObject.FindGameObjectsWithTag("TestObject");
        foreach(var obj in objs)
        {
            Destroy(obj);
        }
    }
}



