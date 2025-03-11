using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    float m_speedRedution;
    [SerializeField]
    Vector3 m_offset;

    void Update()
    {

        transform.position = Input.mousePosition / m_speedRedution + m_offset;
    }
}
