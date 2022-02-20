using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Door_Trigger : MonoBehaviour
{
    public GameObject m_left_door;
    public GameObject m_right_door;
    // Start is called before the first frame update
    void Start()
    {
        m_left_door.transform.position = new Vector3(0.9, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
