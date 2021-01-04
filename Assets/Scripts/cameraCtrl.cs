using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCtrl : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 20f)]
    float m_distance;
    [SerializeField]
    [Range(0f, 20f)]
    float m_height;
    [SerializeField]
    [Range(0f, 180f)]
    float m_angle;
    [SerializeField]
    [Range(0.2f, 20f)]
    float m_speed;
    [SerializeField]
    Transform m_target;

    Vector3 m_dir;

    Transform m_prevTransform;

    void UpdatePosition()
    {
        transform.position = new Vector3(Mathf.Lerp(m_prevTransform.position.x, m_target.position.x, m_speed * Time.deltaTime),
                                         Mathf.Lerp(m_prevTransform.position.y, m_target.position.y + m_height, m_speed * Time.deltaTime),
                                         Mathf.Lerp(m_prevTransform.position.z, m_target.position.z - m_distance, m_speed * Time.deltaTime));
     //   transform.eulerAngles = new Vector3(Mathf.Lerp(m_prevTransform.eulerAngles.x, m_angle, m_speed * Time.deltaTime), 0f, 0f);

        if (m_dir.x > 0)
        {
            this.transform.eulerAngles = new Vector3(Mathf.Lerp(m_prevTransform.eulerAngles.x, m_angle, m_speed * Time.deltaTime), 90f, 0f);
        }
        else if (m_dir.x < 0)
        {
            this.transform.eulerAngles = new Vector3(Mathf.Lerp(m_prevTransform.eulerAngles.x, m_angle, m_speed * Time.deltaTime), -90f, 0f);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(Mathf.Lerp(m_prevTransform.eulerAngles.x, m_angle, m_speed * Time.deltaTime), 0f, 0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_prevTransform = m_target;
        UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        m_dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        UpdatePosition();
    }

    private void LateUpdate()
    {
        m_prevTransform = transform;
    }
}
