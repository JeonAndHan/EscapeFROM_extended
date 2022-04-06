using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingTrigger : MonoBehaviour
{
    //ending이 2가지
    //1. Normal ending -> 좀비 치료제 없이 그냥 탈출 -> clear ending Scene으로 전환 (이전과 동일)
    //2. Happly ending -> 좀비 치료제를 가지고 탈출 -> happy ending Scene으로 전환
    
    [SerializeField]
    private ActionController Player;

    private bool happyEnding = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Player.inventory.GetSlots.Length; i++)
            {
                //만약 player의 인벤토리에 RedSyringe가 있다면 Happy Ending
                if (Player.inventory.GetSlots[i].item.Id == 0)
                {
                    happyEnding = true;
                    SceneManager.LoadScene("HappyEnding");
                }
            }

            if (!happyEnding)
            {
                //없다면 Normal Ending
                SceneManager.LoadScene("ClearEnding");
            }
        }
    }


}
