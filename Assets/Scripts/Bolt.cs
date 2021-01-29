using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private Rigidbody m_RB;
    [SerializeField]
    private float m_Speed, m_Power;
    private string m_TargetTag;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
      m_RB.velocity = transform.up * m_Speed;
    }

    public void setTargetTag(string tag)
    {
        m_TargetTag = tag;
    }

    public void setTarget(Vector3 TargetPoint)
    {
        Vector3 dir = TargetPoint - transform.position;
        m_RB.velocity = dir.normalized * m_Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(m_TargetTag))
        {
            other.gameObject.SendMessage("Hit", m_Power);
            gameObject.SetActive(false);
        }
    }
}
