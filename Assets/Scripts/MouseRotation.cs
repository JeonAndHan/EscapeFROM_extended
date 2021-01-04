using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField]
    private Transform m_charactorBody;
    [SerializeField]
    private Transform m_cameraArm;

    Animator m_Anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = m_charactorBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("MouseX"), Input.GetAxis("MouseY"));
        Vector3 camAngle = m_cameraArm.rotation.eulerAngles;

        m_cameraArm.rotation = Quaternion.Euler(camAngle.x - mouseDelta.y, camAngle.y + mouseDelta.x, camAngle.z);

    }
}
