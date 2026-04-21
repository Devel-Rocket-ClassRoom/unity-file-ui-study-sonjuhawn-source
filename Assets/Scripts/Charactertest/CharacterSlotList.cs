using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterSlotList : MonoBehaviour
{
    public readonly System.Comparison<SaveItemData>[] comparisons =
    {
        (lhs, rhs) => lhs.creationTIme.CompareTo(rhs.creationTIme),
        (lhs, rhs) => rhs.creationTIme.CompareTo(lhs.creationTIme),
        (lhs, rhs) => lhs.ItemData.StringName.CompareTo(rhs.ItemData.StringName),
        (lhs, rhs) => rhs.ItemData.StringName.CompareTo(lhs.ItemData.StringName),
        (lhs, rhs) => lhs.ItemData.StringName.CompareTo(rhs.ItemData.Cost),
        (lhs, rhs) => rhs.ItemData.StringName.CompareTo(lhs.ItemData.Cost),
    };



    public readonly System.Func<SaveItemData, bool>[] filterings =
    {
        (x) => true,
        (x) => x.ItemData.Type == ItemTypes.Weapon,
        (x) => x.ItemData.Type == ItemTypes.Equip,
        (x) => x.ItemData.Type == ItemTypes.Consumable,
        (x) => x.ItemData.Type != ItemTypes.Consumable,
    };

    private List<CharacterInven> uiSlotList = new List<CharacterInven>();

    private List<SaveItemData> saveItemDataList = new List<SaveItemData>();

    private int selectedSlotIndex = -1;

    public UiInventor prefab;
    public UiItemInfo prefab1;

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
    private void OnDisable()
    {
        SaveLoadManager.Data.ItemList = saveItemDataList;
        SaveLoadManager.Save();
        saveItemDataList = null;
    }

    public void SetSaveItemDataList(List<SaveItemData> source)
    {
        saveItemDataList = source.ToList();
        UpdateSlots();
    }

    public List<SaveItemData> GetSaveItemDataList()
    {
        return saveItemDataList;
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
        prefab1.SetSaveItemData(saveItemData);
    }


    private void UpdateSlots()
    {
        var list = saveItemDataList.Where(filterings[(int)filtering]).ToList();
        list.Sort(comparisons[(int)sortring]);

        if (uiSlotList.Count < list.Count)
        {
            for (int i = uiSlotList.Count; i < list.Count; ++i)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                newSlot.button.onClick.AddListener(() =>
                {
                    selectedSlotIndex = newSlot.slotIndex;
                    onSelectSlot.Invoke(newSlot.SaveItemData);
                });

                uiSlotList.Add(newSlot);
            }
        }

        for (int i = 0; i < uiSlotList.Count; ++i)
        {
            if (i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetItem(list[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
        }

        selectedSlotIndex = -1;
        onUpdataSlots.Invoke();
    }

    public void AddRandomItem()
    {
        saveItemDataList.Add(SaveItemData.GetRandomItem());
        UpdateSlots();
    }

    public void RemoveItem()
    {
        if (selectedSlotIndex == -1)
        {
            return;
        }

        saveItemDataList.Remove(uiSlotList[selectedSlotIndex].SaveCharacterData);
        UpdateSlots();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        for(int i = 0; i < 10; i++)
    //        {
    //            var saveItemData = SaveItemData.GetRandomItem();
    //            var newInven = Instantiate(prefab, scrollRect.content);
    //            newInven.SetItem(saveItemData);
    //        }
    //    }
    //}
}
