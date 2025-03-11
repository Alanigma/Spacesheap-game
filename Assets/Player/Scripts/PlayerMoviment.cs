using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMoviment : LifeSystem
{
    Vector2 m_Direction;
    [SerializeField] Image m_LifeIcon;
    [SerializeField] float m_BackgroundSpeed;
    float m_BackgroundMoviment;

    private void FixedUpdate()
    {
        transform.position += new Vector3(m_Direction.x, m_Direction.y) * m_BaseSpeed;
        m_BackgroundMoviment += m_BackgroundSpeed;
        ObserverPlayer.m_OnPlayerMove(Vector2.one * m_BackgroundMoviment);
    }

    public void SetInputMoviment(InputAction.CallbackContext value)
    {
        m_Direction = value.ReadValue<Vector2>();
    }

    public override void TakeDamage(float _Damage)
    {
        base.TakeDamage(_Damage);
        m_LifeIcon.material.SetFloat("_AlphaY", (3 - m_Life) / 3);
    }

}
