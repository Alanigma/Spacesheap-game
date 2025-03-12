using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
