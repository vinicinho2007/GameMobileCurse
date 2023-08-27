using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorSetup
{
    public TypeArt typeArt;
    public Color[] colors;
}

public class ColorManager : MonoBehaviour
{
    public Material[] materials;
    public List<ColorSetup> colorSetups;

    public void EditColors(TypeArt type)
    {
        var setup = colorSetups.Find(i => i.typeArt == type);
        
        for(int i =0; i < materials.Length; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }
}