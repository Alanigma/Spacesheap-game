using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] protected float m_BaseSpeed;
    [SerializeField] protected UnityEvent m_TakeDamageEvents;
    public float m_ScoreValue;
    protected Vector3 m_Speed;
    public float m_Life;

    public virtual void TakeDamage(float _Damage)
    {
        if (_Damage > 0)
            m_TakeDamageEvents?.Invoke();
        m_Life -= _Damage;
        if(m_Life <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
