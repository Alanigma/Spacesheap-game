using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Level
{
    public class LightInstableIntensity : MonoBehaviour
    {
        [SerializeField]
        float m_Duration;
        [SerializeField]
        float m_MinIntensity;
        [SerializeField]
        float m_MaxIntensity;
        [SerializeField]
        Light2D m_Light;

        void Update()
        {
            float t = Mathf.PingPong(Time.time, m_Duration) / m_Duration;
            m_Light.intensity = Mathf.Lerp(m_MinIntensity, m_MaxIntensity, t);
        }
    }
}
