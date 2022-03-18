using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum InforType{ Item, }

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;

    private bool pickupActivated = false;

    private RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private TextMeshProUGUI actionText;

    public InventoryObject inventory, crafting;

    public GameObject inventoryScreen, craftingScreen;

    [SerializeField]
    private GameObject StartStory_UI;

    [SerializeField]
    private GameObject Manipulation_UI;


    private bool inventoryOpen = false;
    private bool CraftingOpen = false;

    public bool playerLock = false;

    private Item _item;
    private GameObject m_item;


    [SerializeField]
    private ItemEffectDatabase effectDatabase;

    //게임 시작시 인벤토리가 한번 활성화되야해서 활성화 된채로 시작해 비활성화 시킨다.
    private void Start()
    {
        CloseInventory();
        crafting.CraftingUpdate();
        CloseCrafting();

        actionText = GameObject.Find("GUI").transform.Find("CursorOnItemText").transform.Find("ActionText").GetComponent<TextMeshProUGUI>();       
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z) && pickupActivated && m_item.gameObject.activeInHierarchy)
        {
            if (!m_item.gameObject.CompareTag("Gun"))
            {
                inventory.AddItem(_item, 1);
                Destroy(m_item);
                actionText.gameObject.SetActive(false);
                //pickup sound
            }
        }

        //단축키 i를 입력받으면 인벤토리 창을 띄우거나 닫는다.
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
        //단축키 c를 입력받으면 제작 창을 띄우거나 닫는다.
        else if(Input.GetKeyDown(KeyCode.C))
        {
            //recipe를 습득 후 사용했다면
            if (effectDatabase.b_canCraft)
            {
                Debug.Log("bool can craft : " + effectDatabase.b_canCraft);
                if (CraftingOpen)
                {
                    CloseCrafting();
                }
                else
                {
                    OpenCrafting();
                }
            }
        }
    }
 
    //인벤토리 창 활성화
    public void OpenInventory()
    {
        inventoryOpen = true;
        inventoryScreen.SetActive(true);
        PlayLock();
    }
    //인벤토리 창 비활성화
    public void CloseInventory()
    {
        inventoryOpen = false;
        inventoryScreen.GetComponent<UserInterface>().theItemEffectDatabase.HideToolTip();
        inventoryScreen.SetActive(false);
        PlayLock();

    }
    //제작 창 활성화
    public void OpenCrafting()
    {
        CraftingOpen = true;
        craftingScreen.SetActive(true);
        PlayLock();
    }
    //제작 창 비활성화
    public void CloseCrafting()
    {
        CraftingOpen = false;
        craftingScreen.GetComponent<UserInterface>().theItemEffectDatabase.HideToolTip();
        craftingScreen.SetActive(false);
        PlayLock();
    }

    public void PlayLock()
    {
        if (CraftingOpen == false && inventoryOpen == false)
        {
            playerLock = false;
            Debug.Log("player lock false : " + playerLock);
        }
        else
        {
            playerLock = true;
            Debug.Log("player lock true : " + playerLock);
        }
    }

    //종료시 인벤토리와 퀵슬롯을 초기화한다.
    public void OnApplicationQuit()
    {
        OnQuit();
    }

    public void OnQuit()
    {
        inventory.Clear();
    }

    public void Lock(bool Lock)
    {
        playerLock = Lock;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            actionText.gameObject.SetActive(true);
            actionText.text = "Press " + "<color=yellow>" + "'Z'" + "</color>" + " to aquire " + other.gameObject.GetComponent<GroundItem>().item.name;
            pickupActivated = true;

            _item = new Item(other.gameObject.GetComponent<GroundItem>().item);
            m_item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            actionText.gameObject.SetActive(false);
            pickupActivated = false;
        }
    }
}