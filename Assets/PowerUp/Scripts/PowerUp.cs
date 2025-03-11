using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] protected float m_BaseSpeed;
    [SerializeField] protected float m_Duration;
    [SerializeField] protected int m_PlayerLayer;
    [SerializeField] protected bool m_AttackSpeed;
    [SerializeField] protected bool m_TripleShot;
    [SerializeField] protected float m_ScoreValue;
    public ScoreCount m_ScoreManager;

    private void FixedUpdate()
    {
        transform.position += m_BaseSpeed * Vector3.down;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_PlayerLayer == collision.gameObject.layer)
        {
            if (collision.gameObject.TryGetComponent(out PlayerWeapon _Weapon))
            {
                m_ScoreManager.AddPoint(m_ScoreValue);
                if (m_AttackSpeed)
                    _Weapon.GetAttackSpeedPowerUp(2, m_Duration);
                if(m_TripleShot)
                    _Weapon.GetTripleShotPowerUp(m_Duration);

                Destroy(gameObject);
            }
        }
    }
}
