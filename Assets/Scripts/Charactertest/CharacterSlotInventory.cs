using TMPro;
using UnityEngine;

public class CharacterSlotInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiInvenSlotList uiInvenSlotList;

    //public void OnEnalbe()
    //{
    //    OnLoad();
    //    OnChangeFiltering(sorting.value);

    //}
    //public void OnChangeSorting(int index)
    //{
    //    uiInvenSlotList.Sorting = (UiInvenSlotList.SortingOptions)index;
    //}

    //public void OnChangeFiltering(int index)
    //{
    //    uiInvenSlotList.Filtering = (UiInvenSlotList.FilteringOptions)index;
    //}

    //public void OnSave()
    //{
    //    SaveLoadManager.Data.ItemList = uiInvenSlotList.GetSaveItemDataList();
    //    SaveLoadManager.Save();

    //}

    //public void OnLoad()
    //{
    //    SaveLoadManager.Load();
    //    uiInvenSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
    //}

    public void OnCreateItem()
    {
        uiInvenSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiInvenSlotList.RemoveItem();
    }

    private void Update()
    {
        
    }
}
