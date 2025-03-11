using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StopWhenDontMoveGeneric : MonoBehaviour
{
    [SerializeField]
    VisualEffect m_vfx;

    Vector3 m_lastPosition;

    private void Start()
    {
        if (gameObject.activeSelf)
            StartCoroutine(nameof(CheckMovement));
    }

    IEnumerator CheckMovement()
    {
        while (true)
        {
            if (m_lastPosition == transform.position)
            {
                if(m_vfx.isActiveAndEnabled)
                    m_vfx.Stop();
            }
            else
            {
                if(!m_vfx.isActiveAndEnabled)
                    m_vfx.Play();
                m_lastPosition = transform.position;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
