using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public InterfaceType type;
    [SerializeField]
    private Inventory Container = new Inventory();
    public InventorySlot[] GetSlots => Container.Slots;
    
    //인벤토리에 아이템을 추가한다.
    public bool AddItem(Item item, int amount)
    {
        if (EmptySlotCount <= 0 && amount > 0)
            return false;
        InventorySlot slot = FindItemOnInventory(item);
        if (!database.ItemObjects[item.Id].stackable || slot == null)
        {
            //물, 물약들, 빈 주사기는 2개씩 습득되도록
            if (item.Id == 5 || item.Id == 6 || item.Id == 0 || item.Id == 7)
            {
                Debug.Log("물약 또는 물 습득");
                GetEmptySlot().UpdateSlot(item, amount + 1);
            }
            else
            {
                GetEmptySlot().UpdateSlot(item, amount);
            }
            return true;
        }
        slot.AddAmount(amount);
        return true;
    }
    //인벤토리 내의 빈 슬롯을 센다.
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++)
            {
                if (GetSlots[i].item.Id <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    //인벤토리 내의 해당 아이템을 저장한 슬롯을 찾는다.
    public InventorySlot FindItemOnInventory(Item item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.Id == item.Id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }
    //인벤토리 내에 해상 아이템이 있는지 검사한다.
    public bool IsItemInInventory(ItemObject item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.Id == item.data.Id)
            {
                return true;
            }
        }
        return false;
    }
    //인벤토리 내의 첫 빈슬롯을 찾는다.
    public InventorySlot GetEmptySlot()
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.Id <= -1)
            {
                return GetSlots[i];
            }
        }
        return null;
    }
    //인벤토리 내의 두 아이템의 위치를 바꾼다.
    //public void SwapItems(InventorySlot item1, InventorySlot item2)
    //{
    //    if (item1 == item2)
    //        return;
    //    if (item2.CanPlaceInSlot(item1.GetItemObject()) && item1.CanPlaceInSlot(item2.GetItemObject()))
    //    {
    //        InventorySlot temp = new InventorySlot(item2.item, item2.amount);
    //        item2.UpdateSlot(item1.item, item1.amount);
    //        item1.UpdateSlot(temp.item, temp.amount);
    //    }

    //}

    //public void RemoveItem(Item item)
    //{
    //    InventorySlot slot = FindItemOnInventory(item);
    //    slot.RemoveItem();
    //}

    public void CraftingUpdate()
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            GetSlots[i].UpdateSlot(this.Container.Slots[i].item, this.Container.Slots[i].amount);
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }
}

