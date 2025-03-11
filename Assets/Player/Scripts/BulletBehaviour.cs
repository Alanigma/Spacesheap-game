using UnityEngine;

public class BulletBehaviour : LifeSystem
{
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, m_BaseSpeed));
    }
}
