using UnityEngine;

public class Rotate : MonoBehaviour {

    public Vector2 m_SpeedRange;
    float m_Speed;

    private void Start()
    {
        m_Speed = Random.Range(m_SpeedRange.x, m_SpeedRange.y);
    }

    void Update() {

        transform.Rotate(new Vector3(0, 0, m_Speed * Time.deltaTime));

    }

}
