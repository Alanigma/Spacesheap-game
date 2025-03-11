using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeToEvent : MonoBehaviour
{
    [SerializeField] UnityEvent m_Events;
    [SerializeField] float m_Delay;

    void OnEnable()
    {
        StopAllCoroutines();
        if(gameObject.activeSelf)
            StartCoroutine(nameof(Active));
    }

    private IEnumerator Active()
    {
        yield return new WaitForSecondsRealtime(m_Delay);
        m_Events?.Invoke();
    }
}
