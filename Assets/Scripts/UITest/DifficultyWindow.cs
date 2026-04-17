using CsvHelper.Configuration;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public Toggle[] toggles;

    public int selected;

    private string difficulty;
    private string path;

    public void Awake()
    {
        toggles[0].onValueChanged.AddListener(OnEasy);
        toggles[1].onValueChanged.AddListener(OnNormal);
        toggles[2].onValueChanged.AddListener(OnHard);

        path = Path.Combine(Application.persistentDataPath, "Difficulty");
    }

    public override void Open()
    {
        base.Open();
        toggles[selected].isOn = true;
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnEasy(bool active)
    {
        if(active)
        {
            Debug.Log("OnEasy");
            difficulty = "Easy";
        }
    }

    public void OnNormal(bool active)
    {
        if (active)
        {
            Debug.Log("OnNormal");
            difficulty = "Normal";
        }
    }

    public void OnHard(bool active)
    {
        if (active)
        {
            Debug.Log("OnHard");
            difficulty = "Hard";
        }
    }

    public void Cancel()
    {
        windowManager.Open(0);
    }

    public void Apply()
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(Path.Combine(path, "Difficult"), FileMode.Create))
            {
                File.WriteAllText(Path.Combine(path, "Difficult"), $"{difficulty}");
            }
        }
        windowManager.Open(0);
    }
}
