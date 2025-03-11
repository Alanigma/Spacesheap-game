using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text m_ScoreText;
    [SerializeField] TMPro.TMP_Text m_FinalScoreText;
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

    public void EndGame()
    {
        m_FinalScoreText.text = ((int)m_Score).ToString();
        Time.timeScale = 0;
    }
}
