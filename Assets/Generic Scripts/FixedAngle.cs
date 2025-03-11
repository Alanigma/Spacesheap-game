using UnityEngine;

public class FixedAngle : MonoBehaviour {

    [SerializeField] Vector3 m_Angle;

    private void Update() {

        transform.eulerAngles = m_Angle;

    }

}
