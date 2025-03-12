using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public bool m_CanRestart;

    public void Restart()
    {
        if(m_CanRestart)
            SceneManager.LoadScene(0);
    }

    public void SetCanRestart(bool _Value)
    {
        m_CanRestart = _Value;
    }
}
