using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] GameObject m_BulletSpeedPrefab;
    [SerializeField] Transform m_FirePoint;
    [SerializeField] float m_AttackSpeed;
    [SerializeField] ScoreCount m_ScoreManager;
    [SerializeField] float m_AttackSpeedMultiplier;
    [SerializeField] bool m_TripleShot;

    private void Start()
    {
        m_AttackSpeedMultiplier = 1;
        StartCoroutine(nameof(ShotCicle));
    }

    IEnumerator ShotCicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / (m_AttackSpeed * m_AttackSpeedMultiplier));
            Shot();
        }
    }

    public void Shot()
    {
        Instantiate(m_AttackSpeedMultiplier > 1 ? m_BulletSpeedPrefab : m_BulletPrefab, m_FirePoint.position, Quaternion.identity).GetComponent<DamagerScoreble>().m_ScoreManager = m_ScoreManager;
        if (!m_TripleShot) return;
        Instantiate(m_AttackSpeedMultiplier > 1 ? m_BulletSpeedPrefab : m_BulletPrefab, m_FirePoint.position, Quaternion.Euler(Vector3.forward * 25)).GetComponent<DamagerScoreble>().m_ScoreManager = m_ScoreManager;
        Instantiate(m_AttackSpeedMultiplier > 1 ? m_BulletSpeedPrefab : m_BulletPrefab, m_FirePoint.position, Quaternion.Euler(Vector3.forward * -25)).GetComponent<DamagerScoreble>().m_ScoreManager = m_ScoreManager;

    }

    public void GetAttackSpeedPowerUp(float _Multiplier, float _Duration)
    {
        StopCoroutine(nameof(AttackSpeedPowerUp));
        StartCoroutine(AttackSpeedPowerUp(_Multiplier, _Duration));
    }

    IEnumerator AttackSpeedPowerUp(float _Multiplier, float _Duration)
    {
        m_AttackSpeedMultiplier = _Multiplier;
        yield return new WaitForSeconds(_Duration);
        m_AttackSpeedMultiplier = 1;
    }

    public void GetTripleShotPowerUp(float _Duration)
    {
        StopCoroutine(nameof(TripleShotPowerUp));
        StartCoroutine(TripleShotPowerUp(_Duration));
    }

    IEnumerator TripleShotPowerUp(float _Duration)
    {
        m_TripleShot = true;
        yield return new WaitForSeconds(_Duration);
        m_TripleShot = false;
    }
}
