using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public bool m_CanRestart;

    public void Restart(InputAction.CallbackContext _Value)
    {
        print(_Value.ReadValue<float>());
        if(m_CanRestart && _Value.ReadValue<float>() == 0)
            SceneManager.LoadScene(0);
    }


    public void SetCanRestart(bool _Value)
    {
        m_CanRestart = _Value;
    }
}
