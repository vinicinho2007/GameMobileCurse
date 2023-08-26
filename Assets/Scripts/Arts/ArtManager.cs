using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeArt
{
    TYPE01,
    TYPE02,
    TYPE03,
}

[System.Serializable]
public class TypeArtObj
{
    public TypeArt typeArt;
    public GameObject art;
}

public class ArtManager : MonoBehaviour
{
    public TypeArtObj[] typeArtObjs;
}