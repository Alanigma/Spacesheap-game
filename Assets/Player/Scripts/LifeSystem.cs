using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] protected float m_BaseSpeed;
    public float m_ScoreValue;
    protected Vector3 m_Speed;
    public float m_Life;

    public virtual void TakeDamage(float _Damage)
    {
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
