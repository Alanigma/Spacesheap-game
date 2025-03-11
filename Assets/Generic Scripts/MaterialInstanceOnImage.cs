using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialInstanceOnImage : MonoBehaviour
{
    [SerializeField]
    Material m_referenceMaterial;
    [SerializeField]
    protected Image m_image;

    Material m_instanciedMaterial;

    protected virtual void OnEnable()
    {

        m_instanciedMaterial = new(m_referenceMaterial);
        m_image.material = m_instanciedMaterial;
    }
}
