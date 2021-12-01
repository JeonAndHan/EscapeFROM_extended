using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public ItemObject _item;
    public string[] part;
    public int[] num;
}

public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    [SerializeField]
    private Tooltip theSlotToolTip;

    [SerializeField]
    private Weapon GunCtrl;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    public bool b_canCraft = false;

    private const string RedSyringe = "RedSyringe", GreenSyringe = "GreenSyringe";

    // private AudioSource pickup;

    private void Awake()
    {
        //  pickup = GetComponent<AudioSource>();
    }

    private void Start()
    {
        theSlotToolTip = GameObject.Find("GUI").transform.Find("Tooltip").GetComponent<Tooltip>();
    }

    //아이템 사용 시 불릴 함수
    public void UseItem(Item item)
    {
        for (int i = 0; i < itemEffects.Length; i++)
        {

            if (itemEffects[i]._item.data.Name == item.Name)
            {
                if (itemEffects[i]._item.data.itemType == ItemType.Food)
                {
                    if (item.Name == "GreenSyringe")
                    {
                        //좀비 치료제 사용 -> 아무 효과도 없을듯?
                    }
                    else if (item.Name == "RedSyringe")
                    {
                        //좀비로 만드는 약 얻음 -> 좀비가 되면서 game over
                    }
                    else if (item.Name == "Recipe")
                    {
                        //Recipe 사용
                        b_canCraft = true;
                        ingameCtrl.recipeGuide();
                        ingameCtrl.CoroutineDeleteRecipeGuide();
                        Debug.Log("bool can craft : " + b_canCraft);
                    }
                    Debug.Log(item.Name + " 을 사용했습니다.");
                    return;
                }
                else if (itemEffects[i]._item.data.itemType == ItemType.Tool)
                {
                    if (item.Name == "Bullet")
                    {
                        //bullet 사용시 총알 개수 + 10
                        GunCtrl.bulletsTotal += 10;
                    }
                    else if (item.Name == "Gun")
                    {
                        //총 장착 -> 장착되어 있다면 못 누르게 하거나 inventory에서 없애기
                    }
                    else if (item.Name == "Axe")
                    {
                        //도끼 장착 -> 장착되어 있다면 못 누르게 하거나 inventory에서 없애기
                    }
                    Debug.Log(item.Name + " 을 사용했습니다.");
                    return;
                }
                
            }
        }
        Debug.Log("itemEffectDatabase에 일치하는 itemName이 없습니다.");
    }



    public void ShowToolTip(ItemObject _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

    //public void pickupSound()
    //{
    //    pickup.Play();
    //}
}