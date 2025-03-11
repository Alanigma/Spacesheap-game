using System;
using UnityEngine;
using UnityEngine.UI;

public static class ObserverPlayer {

    public static Action<Vector2> m_OnPlayerMove;

    public static void CallPlayerMove(Vector2 m_Dislocation) => m_OnPlayerMove.Invoke(m_Dislocation);

}

public class ParallaxScript : MonoBehaviour {

    public Image m_Image;
    public Vector2 m_OffsetSpeed;

    private void OnEnable() {

        ObserverPlayer.m_OnPlayerMove += SetUpdateParallax;

    }

    private void OnDisable() {

        ObserverPlayer.m_OnPlayerMove -= SetUpdateParallax;

    }

    // Update is called once per frame
    void SetUpdateParallax(Vector2 _Dislocation) {

        m_Image.material.mainTextureOffset = _Dislocation * (m_OffsetSpeed/1000);

    }

}
