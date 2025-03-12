using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] List<Image> m_OutlinesUp;
    [SerializeField] List<Image> m_OutlinesUpSprite;
    [SerializeField] List<Image> m_OutlinesDown;
    [SerializeField] List<Image> m_OutlinesDownSprite;
    [SerializeField] bool m_LineUp;
    [SerializeField] int m_Collumn;
    [SerializeField] SpriteRenderer m_PlayerSprite;
    [SerializeField] Image m_LifeImage;
    bool m_Confirmed;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void GetInputUpDown(InputAction.CallbackContext _Value)
    {
        ChangeSelectionLine();
    }
    public void GetInputLeft(InputAction.CallbackContext _Value)
    {
        if (!_Value.ReadValueAsButton()) return;
        ChangeSelectionCollumn(1);
    }
    public void GetInputRight(InputAction.CallbackContext _Value)
    {
        if (!_Value.ReadValueAsButton()) return;
        ChangeSelectionCollumn(-1);
    }

    void ChangeSelectionLine()
    {
        m_LineUp = !m_LineUp;
        UpdateSelected();
    }
    void ChangeSelectionCollumn(int _Direction)
    {
        m_Collumn += _Direction;
        if (m_Collumn < 0) m_Collumn = 2;
        else if (m_Collumn > 2) m_Collumn = 0;
        UpdateSelected();
    }

    void UpdateSelected()
    {
        m_OutlinesUp.ForEach((x) => x.enabled = false);
        m_OutlinesDown.ForEach((x) => x.enabled = false);
        if (m_LineUp)
            m_OutlinesUp[m_Collumn].enabled = true;
        else
            m_OutlinesDown[m_Collumn].enabled = true;
    }

    public void MouseSelectionX(float _Index)
    {
        m_Collumn = (int)_Index;
        UpdateSelected();
    }

    public void MouseSelectionY(bool _Value)
    {
        m_LineUp = _Value;
        UpdateSelected();
    }

    public void ConfirmSelection(InputAction.CallbackContext _Value)
    {
        if (m_Confirmed) return;
        m_PlayerSprite.sprite = m_LineUp ? m_OutlinesUpSprite[m_Collumn].sprite : m_OutlinesDownSprite[m_Collumn].sprite;
        m_LifeImage.sprite = m_LineUp ? m_OutlinesUpSprite[m_Collumn].sprite : m_OutlinesDownSprite[m_Collumn].sprite;
        m_Confirmed = true;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
