using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPlacesBaseSetup : ScriptableObject
{
    public TypeArt typeArt;
    public LevelPlacesBase[] placesStart, places, placesEnd;
    public int maxPlacesStart, maxPlaces, maxPlacesEnd;
}