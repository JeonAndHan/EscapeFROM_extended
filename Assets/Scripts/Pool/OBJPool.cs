using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    protected T[] m_Origin;
    protected List<T>[] m_Pool;

    // Start is called before the first frame update
    void Start()
    {
        m_Pool = new List<T>[m_Origin.Length];
        for(int i=0; i<m_Pool.Length; i++)
        {
            m_Pool[i] = new List<T>();
        }

    }

    public T GetFromPool(int id = 0)
    {
        for(int i=0; i<m_Pool[id].Count; i++)
        {
            if (m_Pool[id][i].gameObject.activeInHierarchy)
            {
                m_Pool[id][i].gameObject.SetActive(true);
                return m_Pool[id][i];
            }
        }
        return MakeNewInstance(id);
    }

    protected virtual T MakeNewInstance(int id)
    {
        T newObj = Instantiate(m_Origin[id]);
        m_Pool[id].Add(newObj);
        return newObj;
    }
}
