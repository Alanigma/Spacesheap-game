using UnityEngine;

public class DamagerScoreble : Damager
{
    public ScoreCount m_ScoreManager;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_TargetLayer == collision.gameObject.layer)
        {
            if (collision.gameObject.TryGetComponent(out LifeSystem _LifeSystem))
            {
                _LifeSystem.TakeDamage(m_Damage);
                if (_LifeSystem.m_Life <= 0)
                    m_ScoreManager.AddPoint(_LifeSystem.m_ScoreValue);
            }
        }
    }
}
