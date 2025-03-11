using System.Collections;
using UnityEngine;

public class ReturnToParent : MonoBehaviour
{
    [SerializeField] Transform m_Parent;
    [SerializeField] bool m_NullParent;

    public void Active(float TimeToReturn)
    {

        transform.position = m_Parent.position;
        if (m_NullParent)
            transform.SetParent(null);
        if(gameObject.activeSelf)
            StartCoroutine(ActivePostDelay(TimeToReturn));

    }

    IEnumerator ActivePostDelay(float TimeToReturn)
    {

        yield return new WaitForSeconds(TimeToReturn);
        transform.position = m_Parent.position;
        transform.SetParent(m_Parent);

    }
}
