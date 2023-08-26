using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtSetup : MonoBehaviour
{
    public GameObject artObj;

    public void EditArt(GameObject art)
    {
        var t = artObj.transform.localPosition;
        Destroy(artObj);
        artObj = Instantiate(art, transform);
        artObj.transform.localPosition = t;
    }
}