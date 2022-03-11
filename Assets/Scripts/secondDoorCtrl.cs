using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstsecondDoorCtrl : MonoBehaviour
{
    BoxCollider m_boxCollider;

    [SerializeField]
    private GameObject door;

    public bool b_useKey = false;

    // Start is called before the first frame update
    void Start()
    {
        m_boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_useKey)
        {
            //door.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            m_boxCollider.gameObject.SetActive(false);
            b_useKey = false;
        }
    }

}
