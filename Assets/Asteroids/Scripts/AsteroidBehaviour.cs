using UnityEngine;

public class AsteroidBehaviour : LifeSystem
{
    private void Start()
    {
        m_Speed = new Vector3(0, m_BaseSpeed);
    }

    private void FixedUpdate()
    {
        transform.position += m_Speed;
    }
}
