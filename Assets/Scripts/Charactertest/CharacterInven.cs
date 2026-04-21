using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInven : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int slotIndex = -1;

    public Image imageIcon;
    public TextMeshProUGUI textName;
    public Button button;
    public SaveCharacterData SaveCharacterData { get; private set; }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        SetCharacter(SaveCharacterData.GetRandomCharacter());
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        SetEmpty();
    //    }
    //}

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        SaveCharacterData = null;

    }

    public void SetCharacter(SaveCharacterData data)
    {
        SaveCharacterData = data;
        imageIcon.sprite = SaveCharacterData.CharacterData.SpriteIcon;
        textName.text = SaveCharacterData.CharacterData.Name;
    }
}

