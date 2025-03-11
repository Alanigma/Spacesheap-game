using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text m_ScoreText;
    float m_Score;

    void Update()
    {
        m_Score += Time.deltaTime;
        m_ScoreText.text = ((int)m_Score).ToString();
    }

    public void AddPoint(float _Value)
    {
        m_Score += _Value;
    }
}
