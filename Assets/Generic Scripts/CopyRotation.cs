using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    [SerializeField]
    Transform m_Target;

    private void FixedUpdate() {
        transform.eulerAngles = m_Target.eulerAngles;
    }
}
