using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstFloorDoorCtrl : MonoBehaviour
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
            Debug.Log("�κ��丮���� 1�� Ű ���");
            m_boxCollider.gameObject.SetActive(false);
            b_useKey = false;
        }
    }
}
