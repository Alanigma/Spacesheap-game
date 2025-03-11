using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollowTransform : MonoBehaviour
{
    [SerializeField] LineRenderer m_line;
    public List<Transform> m_transforms;

    void Update()
    {
        m_line.positionCount = 0;
        foreach (Transform trans in m_transforms)
        {
            if (!trans.gameObject.activeSelf) continue;
            m_line.positionCount += 1;
            m_line.SetPosition(m_line.positionCount - 1, trans.position);
        }
    }
}
