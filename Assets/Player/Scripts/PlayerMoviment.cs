using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : LifeSystem
{
    Vector2 m_Direction;
    [SerializeField] TMPro.TMP_Text m_LifeText;

    private void FixedUpdate()
    {
        transform.position += new Vector3(m_Direction.x, m_Direction.y) * m_BaseSpeed;
    }

    public void SetInputMoviment(InputAction.CallbackContext value)
    {
        m_Direction = value.ReadValue<Vector2>();
    }

    public override void TakeDamage(float _Damage)
    {
        base.TakeDamage(_Damage);
        m_LifeText.text = m_Life.ToString();
    }
}
