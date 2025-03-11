using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Vector2 m_SpawnTickness;
    [SerializeField] GameObject m_Prefab;
    [SerializeField] ScoreCount m_ScoreManager;

    private void Start()
    {
        StartCoroutine(nameof(SpawnCicle));
    }

    IEnumerator SpawnCicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(m_SpawnTickness.x, m_SpawnTickness.y));
            if (Instantiate(m_Prefab, new Vector3(Random.Range(-8, 8), 7), Quaternion.identity).TryGetComponent(out PowerUp _PowerUp))
                _PowerUp.m_ScoreManager = m_ScoreManager;
        }

    }
}
