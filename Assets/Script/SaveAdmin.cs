using System.IO;
using UnityEngine;

public class SaveAdmin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string dir = Application.persistentDataPath;

        if(!Directory.Exists(Path.Combine(dir, "SaveData")))
        {
            Directory.CreateDirectory((Path.Combine(dir, "SaveData")));
        }

        using (FileStream fs = new FileStream(Path.Combine(dir, "SaveData", "save1.txt"),
            FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("save1");
            }
        }
        using (FileStream fs = new FileStream(Path.Combine(dir, "SaveData", "save2.txt"),
            FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("save2");
            }
        }
        using (FileStream fs = new FileStream(Path.Combine(dir, "SaveData", "save3.txt"),
            FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("save3");
            }
        }

        string saveDir = Path.Combine(dir, "SaveData");
        string[] files = Directory.GetFiles(saveDir);
        Debug.Log($"=== 세이브 파일 목록 ===");
        foreach (string file in files)
        {
            Debug.Log($"{Path.GetFileName(file)} ({Path.GetExtension(file)})");
        }

        File.Copy(Path.Combine(dir, "SaveData", "save1.txt"), "save1_backup.txt");
        Debug.Log($" save1.txt → save1_backup.txt복사 완료");
        File.Delete("save3");
        Debug.Log($"save3.txt 삭제 완료");
        Debug.Log($"=== 작업 후 파일 목록 ===");

        saveDir = Path.Combine(dir, "SaveData");
        files = Directory.GetFiles(saveDir);
        foreach (string file in files)
        {
            Debug.Log($"{Path.GetFileName(file)} ({Path.GetExtension(file)})");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
