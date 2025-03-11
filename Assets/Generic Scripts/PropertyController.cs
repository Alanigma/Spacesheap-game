using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PropertyController : MonoBehaviour {

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
    //DissolveController
    [SerializeField]
    bool m_mantainEnable;
    [SerializeField]
    float m_Delay;
    [SerializeField]
    float m_Cooldown;
    [SerializeField]
    Renderer[] m_Mesh;
    [SerializeField]
    GameObject Particles;

    [SerializeField]
    bool m_DestroyObject = false;
    [SerializeField]
    float m_DestroyDelay = 0;

    Material[] mat;
    float m_ActivedTime;
    float initialAlpha;

    public TweenerCore<float, float, FloatOptions> tween { get; private set; }
    void Start() { if (m_PlayOnStart) Ready(); }

    private void OnEnable() { if (m_PlayOnEnable) Ready(); }

    private void Refresh() {

        if (m_Mesh == null || m_Mesh.Length == 0) {

            m_Mesh = new Renderer[1];
            if (!TryGetComponent(out m_Mesh[0])) {

                Debug.LogError($"[{gameObject.name}] Nenhum Renderer encontrado!");
                return;

            }

        }

        if(mat == null || mat.Length == 0) mat = new Material[m_Mesh.Length];

    }

    private void OnDisable() {

        tween?.Kill(true);

    }

    [ContextMenu("Ready")]
    public void Ready() {

        if (!gameObject.activeInHierarchy) return;

        if (m_ActivedTime != 0 && Time.time - m_ActivedTime < m_Cooldown) return;
        m_ActivedTime = Time.time;

        if (Particles != null) ActiveParticles();

        Refresh();

        if (m_Delay == 0) ChangeMaterial();
        else DOVirtual.DelayedCall(m_Delay, ChangeMaterial, false);

    }

    void ChangeMaterial() {

        if (m_Mesh == null || m_Mesh.Length == 0 || m_Mesh[0] == null) {

            Debug.LogError($"[{gameObject.name}] Renderer inválido no m_Mesh!");
            return;

        }

        if (m_Mesh[0].material == null) {

            Debug.LogError($"[{gameObject.name}] Material nulo no m_Mesh[0]. Verifique se o material foi atribuído.");
            return;

        }

        float dissolveAlpha = m_Mesh[0].material.GetFloat(m_AlphaReference);
        initialAlpha = (m_UseInitialAlpha) ? m_InitialAlpha : dissolveAlpha;
        m_OnStartDissolveEvent?.Invoke();

        for (int i = 0; i < m_Mesh.Length; i++) {

            if (m_Mesh[i] == null) {

                Debug.LogError($"[{gameObject.name}] Renderer nulo no índice {i}.");
                continue;

            }

            if (m_Mesh[i].material == null) {

                Debug.LogError($"[{gameObject.name}] Material nulo no Renderer do índice {i}.");
                continue;

            }

            m_Mesh[i].enabled = true;
            mat[i] = m_Mesh[i].material;
            mat[i].SetFloat(m_AlphaReference, initialAlpha);

        }

        tween?.Kill(true);
        tween = DOTween.To(getInitialAlpha, setter, m_AlphaTarget, m_DissolveTime)
                       .OnComplete(onComplete)
                       .SetTarget(transform);

        float getInitialAlpha() => initialAlpha;

        void setter(float x) {

            foreach (Material _mat in mat) {

                if (_mat != null)
                    _mat.SetFloat(m_AlphaReference, x);

            }

        }

        void onComplete() {

            m_OnDissolveEvent?.Invoke();
            foreach (var r in m_Mesh) {

                if (r != null)
                    r.enabled = m_mantainEnable;

            }

            if (m_DestroyObject) Destroy(gameObject, m_DestroyDelay);

        }

    }

    void ActiveParticles() {
        Particles.SetActive(true);
    }

}
