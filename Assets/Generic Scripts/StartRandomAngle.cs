using UnityEngine;

public class StartRandomAngle : MonoBehaviour
{
    void Start()
    {
        transform.eulerAngles = Random.Range(0, 360) * Vector3.forward;
    }
}
