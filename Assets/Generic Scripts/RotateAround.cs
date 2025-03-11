using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    float m_speed;
    [SerializeField]
    Transform m_target;

    void FixedUpdate()
    {

        transform.RotateAround(m_target.position, new Vector3(0, 0, 1), m_speed);
    }
}
