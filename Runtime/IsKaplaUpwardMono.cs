using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsKaplaUpwardMono : MonoBehaviour
{
    public Transform m_kaplaDirection;
    public float m_angleFromUpward = 45;

    public bool m_refreshWithUpdate = true;
    public bool m_isUpward;
    public UnityEvent<bool> m_onIsUpwardChanged;

    public float m_currentAngle;
    private void Reset()
    {
        m_kaplaDirection = transform;
    }

    void Update()
    {
        if(m_refreshWithUpdate)
        {
            Vector3 kaplaDirection = m_kaplaDirection.up ;
            float angle = Mathf.Abs(Vector3.Angle(Vector3.forward, kaplaDirection));
            if(angle > 90)
                angle = 180-angle;

            m_currentAngle = angle;


            bool isUpward =  angle < m_angleFromUpward;
            if(m_isUpward != isUpward)
            {
                m_isUpward = isUpward;
                m_onIsUpwardChanged.Invoke(m_isUpward);
            }
        }
    }
}

