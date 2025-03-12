using UnityEngine;

public class AsteroidBehaviour : LifeSystem
{
    [SerializeField] GameObject m_DestroyVFX;

    private void Start()
    {
        m_Speed = new Vector3(0, m_BaseSpeed);
    }

    private void FixedUpdate()
    {
        transform.position += m_Speed;
    }

    public override void Death()
    {
        base.Death();
        Destroy(Instantiate(m_DestroyVFX, transform.position, Quaternion.identity), 1);
    }
}
