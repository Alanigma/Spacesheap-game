using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControl : MonoBehaviour
{
    [SerializeField] Light2D m_Light;
    [SerializeField] float m_InitialIntensity;
    [SerializeField] float m_Duration;

    float m_Intensity;
    float m_t;
    bool m_Runing;

    private void OnEnable()
    {
        m_Runing = false;
        m_Intensity = m_InitialIntensity;
        m_Light.intensity = m_InitialIntensity;
    }

    void Update()
    {
        if (!m_Runing) return;
        m_Intensity = Mathf.Lerp(m_InitialIntensity, 0, m_t / m_Duration);
        m_Light.intensity = m_Intensity;
        m_t += Time.deltaTime;
    }

    public void Play()
    {
        m_Runing = true;
        m_t = 0;
    }
}
