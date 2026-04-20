using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemInfo : MonoBehaviour
{
    public static readonly string FormatCommon = "{0}: {1};";

    public Image imageIcon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDescription;
    public TextMeshProUGUI textType;
    public TextMeshProUGUI textValue;
    public TextMeshProUGUI textCost;

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        textDescription.text = string.Empty;
        textType.text = string.Empty;
        textValue.text = string.Empty;
        textCost.text = string.Empty;
    }

    public void SetSaveItemData(SaveItemData saveItemdata)
    {
        ItemData data = saveItemdata.ItemData;

        imageIcon.sprite = data.SpriteIcon;
        textName.text = 
            string.Format(FormatCommon, DataTableManager.StringTable.Get("Name"), data.StringName);
        textDescription.text =
            string.Format(FormatCommon, DataTableManager.StringTable.Get("DESC"), data.StringDesc);
        string id  = data.Type.ToString().ToUpper();

        textType.text = 
            string.Format(FormatCommon, DataTableManager.StringTable.Get("TYPE"), data.Type);

        textValue.text = 
            string.Format(FormatCommon, DataTableManager.StringTable.Get("VALUE"), data.Value);
        textCost.text =
            string.Format(FormatCommon, DataTableManager.StringTable.Get("COST"), data.Cost);
    }

    public void Updata()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetEmpty();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSaveItemData(SaveItemData.GetRandomItem());
        }
    }
}
