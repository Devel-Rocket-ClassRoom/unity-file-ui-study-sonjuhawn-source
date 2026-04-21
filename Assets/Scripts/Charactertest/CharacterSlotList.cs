using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterSlotList : MonoBehaviour
{
    public readonly System.Comparison<SaveCharacterData>[] comparisons =
    {
        (lhs, rhs) => lhs.creationTIme.CompareTo(rhs.creationTIme),
        (lhs, rhs) => rhs.creationTIme.CompareTo(lhs.creationTIme),
        (lhs, rhs) => lhs.CharacterData.StringName.CompareTo(rhs.CharacterData.StringName),
        (lhs, rhs) => rhs.CharacterData.StringName.CompareTo(lhs.CharacterData.StringName),

    };



    //public readonly System.Func<SaveItemData, bool>[] filterings =
    //{
    //    (x) => true,
    //    (x) => x.ItemData.Type == ItemTypes.Weapon,
    //    (x) => x.ItemData.Type == ItemTypes.Equip,
    //    (x) => x.ItemData.Type == ItemTypes.Consumable,
    //    (x) => x.ItemData.Type != ItemTypes.Consumable,
    //};

    private List<CharacterInven> saveItemDataList = new List<CharacterInven>();

    private List<SaveCharacterData> saveCharacterDataList = new List<SaveCharacterData>();

    private int selectedSlotIndex = -1;

    public CharacterInven prefab;
    public ScrollRect scrollRect;

    public UnityEvent onUpdataSlots;
    public UnityEvent<SaveItemData> onSelectSlot;

    private void Start()
    {
        onSelectSlot.AddListener(OnSelectSlot);
    }

    private void OnEnable()
    {
        OnLoad();
    }

    public void OnLoad()
    {


    }
    //private void OnDisable()
    //{
    //    SaveLoadManager.Data.ItemList = saveCharacterDataList;
    //    SaveLoadManager.Save();
    //    saveCharacterDataList = null;
    //}

    public void SetSaveItemDataList(List<SaveItemData> source)
    {
        
    }

    public List<SaveCharacterData> GetSaveItemDataList()
    {
        return saveCharacterDataList;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        for (int i = 0; i < 10; ++i)
    //        {
    //            saveItemDataList.Add(SaveItemData.GetRandomItem());
    //        }
    //        UpdateSlots(saveItemDataList);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        Filtering = (FilteringOptions)((int)(Filtering + 1) % 4);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        Sorting = (SortingOptions)((int)(Filtering + 1));
    //    }
    //}


    private void OnSelectSlot(SaveItemData saveItemData)
    {
        
    }


    //private void UpdateSlots()
    //{
    //    var list = saveItemDataList.Where(filterings[(int)filtering]).ToList();
    //    list.Sort(comparisons[(int)sortring]);

    //    if (saveItemDataList.Count < list.Count)
    //    {
    //        for (int i = saveItemDataList.Count; i < list.Count; ++i)
    //        {
    //            var newSlot = Instantiate(prefab, scrollRect.content);
    //            newSlot.slotIndex = i;
    //            newSlot.SetEmpty();
    //            newSlot.gameObject.SetActive(false);

    //            newSlot.button.onClick.AddListener(() =>
    //            {
    //                selectedSlotIndex = newSlot.slotIndex;
    //                onSelectSlot.Invoke(newSlot.SaveItemData);
    //            });

    //            saveItemDataList.Add(newSlot.);
    //        }
    //    }

    //    for (int i = 0; i < saveItemDataList.Count; ++i)
    //    {
    //        if (i < list.Count)
    //        {
    //            saveItemDataList[i].gameObject.SetActive(true);
    //            saveItemDataList[i].SetCharacter(list[i]);
    //        }
    //        else
    //        {
    //            saveItemDataList[i].gameObject.SetActive(false);
    //            saveItemDataList[i].SetEmpty();
    //        }
    //    }

    //    selectedSlotIndex = -1;
    //    onUpdataSlots.Invoke();
    //}

    //public void AddRandomItem()
    //{
    //    saveItemDataList.Add(SaveItemData.GetRandomItem());
    //    UpdateSlots();
    //}

    //public void RemoveItem()
    //{
    //    if (selectedSlotIndex == -1)
    //    {
    //        return;
    //    }

    //    saveItemDataList.Remove(uiSlotList[selectedSlotIndex].SaveCharacterData);
    //    UpdateSlots();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < 10; i++)
            {
                var saveItemData = SaveCharacterData.GetRandomCharacter();
                var newInven = Instantiate(prefab, scrollRect.content);
                newInven.SetCharacter(saveItemData);
            }
        }
    }
}
