using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayRoomSafe_Text_Trigger : TextTrigger
{
    [SerializeField]
    private GameObject safe_door;

    [SerializeField]
    private GameObject Key;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    public bool get_2ndFloorKey;

    // Start is called before the first frame update
    void Start()
    {
        Key.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(b_textTrigger && ingameCtrl.m_pressR && !get_2ndFloorKey)
        {
            safe_door.gameObject.transform.localEulerAngles = new Vector3(0f, -120f, 0f);
            Key.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            get_2ndFloorKey = true;
        }

        if (get_2ndFloorKey)
        {
            this.gameObject.SetActive(false);
        }
    }

}
