using UnityEngine;

namespace Eclipse {
    public class CopyPosition : MonoBehaviour {
        [SerializeField]
        Transform m_character;
        [SerializeField]
        Vector3 m_offset;

        void Update() {
            if (m_character == null) return;
            transform.position = new Vector3(m_character.position.x, m_character.position.y, m_character.position.z);
            transform.Translate(m_offset);
        }
    }
}
