using UnityEngine;

public class MaterialInstanceOnImageMantain : MaterialInstanceOnImage
{
    protected override void OnEnable()
    {
        m_image.material = new(m_image.material);
    }
}
