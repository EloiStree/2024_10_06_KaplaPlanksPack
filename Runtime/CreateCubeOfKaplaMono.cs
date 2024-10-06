using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateCubeOfKaplaMono : MonoBehaviour
{

    public GameObject m_prefab;
    public Transform m_parent;

    public float m_distanceX = 0.3f;
    public float m_distanceY = 0.3f;
    public float m_distanceZ = 0.12f;

    public int m_countX = 5;
    public int m_countY = 5;
    public int m_countZ = 5;

    public float m_destroyTime=9;
    public Vector3 m_rotationWhenCreated;
    public UnityEvent m_onCreated;
    [ContextMenu("Create Cube of Kapla")]
    public void CreateKaplaCube() {
        if (m_parent == null)
            return;

   
        DestroyAllChildrensOf(m_parent);

        for (int x = 0; x < m_countX; x++)
        {
            for (int y = 0; y < m_countY; y++)
            {
                for (int z = 0; z < m_countZ; z++)
                {
                    Vector3 worldPosition = 
                        m_parent.position + (
                            m_parent.right * x * m_distanceX + 
                            m_parent.up * y * m_distanceY +
                            m_parent.forward * z * m_distanceZ
                        );
                    GameObject go = GameObject.Instantiate(m_prefab, worldPosition, Quaternion.identity);

                    go.transform.position = worldPosition;
                    go.transform.SetParent(m_parent);
                    go.transform.Rotate(m_rotationWhenCreated, Space.Self);
                 
                    if (m_destroyTime > 0 && Application.isPlaying)
                        Destroy(go, m_destroyTime);
                }
            }
        }
        m_onCreated.Invoke();
    }

    [ContextMenu("Destoy Children")]
    public void DestroyAllChildrent()
    {
        DestroyAllChildrensOf(m_parent);
    }

    public void DestroyAllChildrensOf(Transform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            if(parent == parent.GetChild(i))
                continue;

            if(Application.isPlaying)
                Destroy(parent.GetChild(i).gameObject);
            else
                DestroyImmediate(parent.GetChild(i).gameObject);
        }
    }
}
