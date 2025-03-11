using UnityEngine;

public class Rotate : MonoBehaviour {

    public float m_speed;

    void Update() {

        transform.Rotate(new Vector3(0, 0, m_speed * Time.deltaTime));

    }

}
