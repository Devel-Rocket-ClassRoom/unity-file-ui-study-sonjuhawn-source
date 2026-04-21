using Newtonsoft.Json;
using System;
using UnityEngine;

public class SaveCharacterData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]

    public CharacterData CharacterData { get; set; }
    public DateTime creationTIme { get; set; }

    public static SaveCharacterData GetRandomCharacter()
    {
        SaveCharacterData newCharacter = new SaveCharacterData();
        newCharacter.CharacterData = DataTableManager.CharacterTable.GetRandom();
        return newCharacter;
    }

    public SaveCharacterData()
    {
        InstanceId = Guid.NewGuid();
        creationTIme = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId}{creationTIme}{CharacterData}";
    }
}
