using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] protected int m_TargetLayer;
    [SerializeField] protected float m_Damage;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_TargetLayer == collision.gameObject.layer)
        {
            if (collision.gameObject.TryGetComponent(out LifeSystem _LifeSystem)) {
                _LifeSystem.TakeDamage(m_Damage);
            }
        }
    }
}
