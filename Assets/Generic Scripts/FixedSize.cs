using UnityEngine;

public class FixedSize : MonoBehaviour {
    [SerializeField]
    Vector3 m_desiredScale;

    void Update() {
        if (transform.parent == null) return;
        transform.localScale = new Vector3(m_desiredScale.x / transform.parent.localScale.x, m_desiredScale.y / transform.parent.localScale.y, m_desiredScale.z / transform.parent.localScale.z);
    }
}
