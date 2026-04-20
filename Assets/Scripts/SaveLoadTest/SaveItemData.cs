using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public class SaveItemData
{
    public Guid instanceId {  get; set; }
    
    [JsonConverter(typeof(ItemDataConverter))]

    public ItemData ItemData { get; set; }
    public DateTime creationTIme {  get; set; }

    public static SaveItemData GetRandomItem()
    {
        SaveItemData newItem = new SaveItemData();
        newItem.ItemData = DataTableManager.ItemTable.GetRandom();
        return newItem; 
    }

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTIme = DateTime.Now;
    }
}