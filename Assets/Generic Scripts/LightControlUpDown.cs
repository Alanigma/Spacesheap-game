using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControlUpDown : MonoBehaviour
{
    [SerializeField] float m_MinValue;
    public float m_MaxValue;
    [SerializeField] float m_Speed;

    [SerializeField] Light2D m_Light;

    public float m_ActualScale;
    [SerializeField] private int m_Direction;
    [SerializeField] bool m_DisableInZero;
    [SerializeField] bool m_EnableFading;
    [SerializeField] bool m_PingPong;

    private void OnEnable()
    {
        if (!m_EnableFading) return;
        m_Light.intensity = m_MaxValue;
        m_ActualScale = 1;
        SetDirection(-1);
    }

    private void Update()
    {
        if (m_ActualScale >= 1 && m_Direction == 1)
        {
            if (m_PingPong) m_Direction = -1;
            else return;
        }
        if (m_ActualScale <= 0 && m_Direction == -1)
        {
            m_Light.enabled = !m_DisableInZero;
            return;
        }
        m_Light.enabled = true;
        m_ActualScale += Time.unscaledDeltaTime * m_Direction * m_Speed;
        m_Light.intensity = Mathf.Lerp(m_MinValue, m_MaxValue, m_ActualScale);
    }

    public void SetDirection(int _direction)
    {
        m_Direction = _direction;
    }
}
