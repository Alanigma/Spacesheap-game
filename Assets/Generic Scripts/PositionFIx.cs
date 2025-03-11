using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFix : MonoBehaviour
{
    [SerializeField] Transform m_Reference;
    [SerializeField] Vector3 m_Offset = Vector3.down * 0.88f;

    void Update()
    {
        transform.position = m_Reference.position + m_Offset;
    }
}
