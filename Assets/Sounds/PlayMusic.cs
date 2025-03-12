using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] List<AudioClip> m_Musics;
    [SerializeField] AudioSource m_Source;

    void Awake()
    {
        m_Source.clip = m_Musics[(Random.Range(0, 2) == 0) ? 1 : 0];
        m_Source.Play();
    }

}
