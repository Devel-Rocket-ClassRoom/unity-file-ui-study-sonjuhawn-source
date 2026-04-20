using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInventor : MonoBehaviour
{
    public Image imageIcon;
    public TextMeshProUGUI textName;

    public SaveItemData SaveItemtemdata {  get; private set; }

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        SaveItemtemdata = null;

    }

    public void SetItem(SaveItemData data)
    {
        SaveItemtemdata = data;
        imageIcon.sprite = SaveItemtemdata.ItemData.SpriteIcon;
        textName.text = SaveItemtemdata.ItemData.StringName;
    }
}
