using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCopy : MonoBehaviour
{
    [SerializeField] LineRenderer m_LineCopy;
    [SerializeField] LineRenderer m_LinePaste;
    [SerializeField] Vector3 m_Offset;

    int m_Index;

    void Update()
    {
        m_LinePaste.positionCount = m_LineCopy.positionCount;
        for (m_Index = 0; m_Index < m_LineCopy.positionCount; m_Index++)
        {
            m_LinePaste.SetPosition(m_Index, m_LineCopy.GetPosition(m_Index) + m_Offset);
        }
    }
}
