using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PropertyControllerImage : MonoBehaviour {

    public UnityEvent m_OnStartDissolveEvent;
    public UnityEvent m_OnDissolveEvent;

    [SerializeField]
    bool m_PlayOnStart = true;
    [SerializeField]
    bool m_PlayOnEnable;
    [SerializeField]
    string m_AlphaReference = "_Alpha";
    [SerializeField]
    bool m_UseInitialAlpha = true;
    [SerializeField]
    float m_InitialAlpha;
    public float m_DissolveTime;
    [SerializeField]
    float m_AlphaTarget = 1;
    [SerializeField]
    float m_Delay;
    [SerializeField]
    float m_Cooldown;
    [SerializeField]
    Image[] m_Mesh;
    [SerializeField]
    GameObject Particles;

    [SerializeField]
    bool m_DestroyObject = false;
    [SerializeField]
    float m_DestroyDelay = 0;

    Material[] mat;
    float m_ActivedTime;

    public TweenerCore<float, float, FloatOptions> tween { get; private set; }

    void Awake() {

        if (m_Mesh == null || m_Mesh.Length == 0) {

            m_Mesh = new Image[1];
            if (!TryGetComponent<Image>(out m_Mesh[0])) {

                Debug.LogError($"[{gameObject.name}] Nenhuma Image encontrada!");
                return;

            }

        }

        mat = new Material[m_Mesh.Length];

        if (m_PlayOnStart) Ready();

    }


    private void OnEnable() {

        if (mat == null) mat = new Material[m_Mesh.Length];
        if (m_PlayOnEnable) Ready();

    }

    public void Ready() {

        if (!gameObject.activeInHierarchy) return;

        if (m_ActivedTime != 0 && Time.time - m_ActivedTime < m_Cooldown) return;
        m_ActivedTime = Time.time;

        if (Particles != null) ActiveParticles();

        if (m_Delay == 0) ChangeMaterial();
        else DOVirtual.DelayedCall(m_Delay, ChangeMaterial);

    }

    void ChangeMaterial() {

        if (m_Mesh == null || m_Mesh.Length == 0 || m_Mesh[0] == null) {

            Debug.LogError($"[{gameObject.name}] Nenhuma Image válida encontrada no m_Mesh!");
            return;

        }

        if (m_Mesh[0].material == null) {

            Debug.LogError($"[{gameObject.name}] Material está nulo em m_Mesh[0]. Certifique-se de atribuir um material.");
            return;

        }

        float dissolveAlpha = m_Mesh[0].material.GetFloat(m_AlphaReference);
        float initialAlpha = (m_UseInitialAlpha) ? m_InitialAlpha : dissolveAlpha;

        m_OnStartDissolveEvent?.Invoke();

        for (int i = 0; i < m_Mesh.Length; i++) {

            if (m_Mesh[i] == null || m_Mesh[i].material == null) {

                Debug.LogError($"[{gameObject.name}] Material está nulo no índice {i}");
                continue;

            }

            m_Mesh[i].enabled = true;
            mat[i] = m_Mesh[i].material;
            mat[i].SetFloat(m_AlphaReference, initialAlpha);

        }

        tween?.Kill(true);
        tween = DOTween.To(getInitialAlpha, setter, m_AlphaTarget, m_DissolveTime)
                       .OnComplete(onComplete)
                       .SetTarget(transform)
                       .SetUpdate(true);

        float getInitialAlpha() => initialAlpha;

        void setter(float x) {

            foreach (Material _mat in mat) {

                if (_mat != null)
                    _mat.SetFloat(m_AlphaReference, x);

            }

        }

        void onComplete() {

            m_OnDissolveEvent?.Invoke();
            if (m_DestroyObject) Destroy(gameObject, m_DestroyDelay);

        }

    }

    void ActiveParticles() {

        Particles.SetActive(true);

    }

}
