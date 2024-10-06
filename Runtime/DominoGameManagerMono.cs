using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DominoGameManagerMono : MonoBehaviour
{
    public IsKaplaUpwardMono m_start;
    public IsKaplaUpwardMono m_end;
    public UnityEvent m_onGameStarted;
    public UnityEvent m_onGameEnded;

    public bool m_startState = false;
    public bool m_endState = false;

    



    private void Update()
    {
        bool startState = m_start.IsUpward();
        bool endState = m_end.IsUpward();

        if (startState != m_startState)
        {
            m_startState = startState;
            if (startState)
            {
                m_onGameStarted.Invoke();
            }
        }
        if (endState != m_endState)
        {
            m_endState = endState;
            if (endState)
            {
                m_onGameEnded.Invoke();
            }
        }

    }

    public void DebugLogMessage(string message) { 
        Debug.Log(message);

    }

}
