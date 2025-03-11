using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnscalledTimeShader : MonoBehaviour
{
    [SerializeField]
    Image m_image;

    float time;

    void Update()
    {

        m_image.material.SetFloat("_UnscaledTime", time);
        time += Time.unscaledDeltaTime;
    }
}
