using System.IO;
using UnityEngine;

public class Encryption : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string dir = Path.Combine(Application.persistentDataPath, "Encryption");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
