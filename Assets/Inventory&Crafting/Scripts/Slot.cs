using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public UserInterface slotScreen;

    private ItemEffectDatabase _theItemEffectDatabase;
    public InventoryObject _inventory;

    private FirstFloor_DoorTrigger firstFloor_DoorTrigger;
    private SecondFloor_DoorTrigger secondFloor_DoorTrigger;

    private IngameCtrl ingameCtrl;


    private void Start()        //동적으로 생성되는 프리팹이기 때문에 시작 후에 필요한 요소들을 연결한다.
    {        
        slotScreen = gameObject.GetComponentInParent<UserInterface>();
        _theItemEffectDatabase = slotScreen.theItemEffectDatabase;
        _inventory = slotScreen.inventory;
        firstFloor_DoorTrigger = FindObjectOfType<FirstFloor_DoorTrigger>();
        secondFloor_DoorTrigger = FindObjectOfType<SecondFloor_DoorTrigger>();
        ingameCtrl = FindObjectOfType<IngameCtrl>();
    }

    public void OnPointerClick(PointerEventData eventData)      //PointerEventData를 이용하기 위해 프리팹에 직접 붙여준다.
    {
        InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];

        if (eventData.button == PointerEventData.InputButton.Right && MouseData.slotHoveredOver != null)    //우클릭
        {
            if (mouseHoverSlotData.item.itemType == ItemType.Food || mouseHoverSlotData.item.itemType == ItemType.Tool)  //아이템이 음식 또는 툴이라면 수치를 1 감소시킨다.
            {
                //1층 열쇠나 2층 열쇠는 특정 구역에 들어갔을 경우에만 사용하도록
                if (mouseHoverSlotData.item.Id == 13)
                {
                    if (firstFloor_DoorTrigger.b_FirstDoor)
                    {
                        ingameCtrl.b_fistFloor_DoorOpen = true;
                        Debug.Log("1층 문 열림");
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (mouseHoverSlotData.item.Id == 14)
                {
                    if (secondFloor_DoorTrigger.b_SecondFloor_DoorTrigger)
                    {
                        ingameCtrl.b_secondFloor_DoorOpen = true;
                        Debug.Log("2층 문 열림");
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                    _inventory.AddItem(mouseHoverSlotData.item, -1);
                }
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Left && MouseData.slotHoveredOver != null)       //좌클릭
        {
            if (mouseHoverSlotData.item.itemType == ItemType.Recipe)    //레시피라면 제작한다.
            {
                _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                ItemObject io = mouseHoverSlotData.GetItemObject();
                io.Crafting();
            }
        }
    }
}
