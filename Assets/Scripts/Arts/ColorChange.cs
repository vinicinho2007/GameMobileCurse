using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class ColorMaterial
{
    public Color colorContininet;
}

public class ColorChange : MonoBehaviour
{
    public Material[] materials;
    public List<ColorMaterial> colorMaterials;
    public Color startColor;
    public float delayStart,durationAnim;

    private void Start()
    {
        foreach(Material mat in materials)
        {
            ColorMaterial colorsMaterials = new ColorMaterial();
            Color color = mat.GetColor("_Color");
            colorsMaterials.colorContininet = color;
            colorMaterials.Add(colorsMaterials);
        }
    }

    public void LerpColor()
    {
        foreach (Material mat in materials)
        {
            mat.SetColor("_Color", startColor);
        }

        for(int i = 0; i < colorMaterials.Count; i++)
        {
            materials[i].DOColor(colorMaterials[i].colorContininet, durationAnim).SetDelay(delayStart);
        }
    }
}