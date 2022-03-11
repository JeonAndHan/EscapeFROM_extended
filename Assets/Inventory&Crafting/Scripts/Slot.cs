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

    private Mouse_Text_Trigger mouse_TextTrigger;
    private Zomebie_Mouse_Text_Trigger zombie_TextTrigger;

    private firstFloorDoorCtrl firstDoorCtrl;
    private secondDoorCtrl secondDoorCtrl;

    private IngameCtrl ingameCtrl;

    public bool b_Normal_to_ZombieMouse;
    public bool b_Zombie_to_NormalMouse;


    private void Start()        //동적으로 생성되는 프리팹이기 때문에 시작 후에 필요한 요소들을 연결한다.
    {        
        slotScreen = gameObject.GetComponentInParent<UserInterface>();
        _theItemEffectDatabase = slotScreen.theItemEffectDatabase;
        _inventory = slotScreen.inventory;
        firstFloor_DoorTrigger = FindObjectOfType<FirstFloor_DoorTrigger>();
        secondFloor_DoorTrigger = FindObjectOfType<SecondFloor_DoorTrigger>();
        mouse_TextTrigger = FindObjectOfType<Mouse_Text_Trigger>();
        zombie_TextTrigger = FindObjectOfType<Zomebie_Mouse_Text_Trigger>();
        ingameCtrl = FindObjectOfType<IngameCtrl>();
        firstDoorCtrl = FindObjectOfType<firstFloorDoorCtrl>();
        secondDoorCtrl = FindObjectOfType<secondDoorCtrl>();
    }

    public void OnPointerClick(PointerEventData eventData)      //PointerEventData를 이용하기 위해 프리팹에 직접 붙여준다.
    {
        InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];

        if (eventData.button == PointerEventData.InputButton.Right && MouseData.slotHoveredOver != null)    //우클릭
        {
            if (mouseHoverSlotData.item.itemType == ItemType.Food || mouseHoverSlotData.item.itemType == ItemType.Tool)  //아이템이 음식 또는 툴이라면 수치를 1 감소시킨다.
            {
                //1층 열쇠나 2층 열쇠는 특정 구역에 들어갔을 경우에만 사용하도록 && Red Syringe와 Green Syringe도
                if (mouseHoverSlotData.item.Id == 13) //1층 열쇠
                {
                    if (firstFloor_DoorTrigger.b_FirstDoor)
                    {
                        ingameCtrl.b_fistFloor_DoorOpen = true;
                        firstDoorCtrl.b_useKey = true;
                        Debug.Log("1층 문 열림");
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (mouseHoverSlotData.item.Id == 14) //2층 열쇠
                {
                    if (secondFloor_DoorTrigger.b_SecondFloor_DoorTrigger)
                    {
                        ingameCtrl.b_secondFloor_DoorOpen = true;
                        secondDoorCtrl.b_useKey = true;
                        Debug.Log("2층 문 열림");
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                    }
                    else
                    {
                        return;
                    }
                }
                else if(mouseHoverSlotData.item.Id == 0) //RedSyringe
                {
                    if (mouse_TextTrigger.b_NormalMouse_TextTrigger)
                    {
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                        Debug.Log("그냥 쥐 -> 치료제 : 아무런 변화 X");
                    }
                    else if (zombie_TextTrigger.b_ZombieMouse_TextTrigger)
                    {
                        zombie_TextTrigger.b_makeNormalMouse = true;
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                        Debug.Log("좀비쥐 -> 치료제 : 일반쥐");
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else if(mouseHoverSlotData.item.Id == 6) //GreenSyringe
                {
                    if (mouse_TextTrigger.b_NormalMouse_TextTrigger)
                    {
                        mouse_TextTrigger.b_makeZombieMouse = true;
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                        Debug.Log("그냥 쥐 -> 좀비약 : 좀비UI 띄우기");
                    }
                    else if (zombie_TextTrigger.b_ZombieMouse_TextTrigger)
                    {
                        _theItemEffectDatabase.UseItem(mouseHoverSlotData.item);
                        _inventory.AddItem(mouseHoverSlotData.item, -1);
                        Debug.Log("좀비쥐 -> 좀비약 : 변화 X");
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
