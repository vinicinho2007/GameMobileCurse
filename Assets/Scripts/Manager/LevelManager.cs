using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ArtManager artManager;
    public Transform target;
    public LevelPlacesBaseSetup[] baseSetupsLevels;
    private List<LevelPlacesBase> _spawnPlaces;
    private int _index;

    private void Start()
    {
        _spawnPlaces = new List<LevelPlacesBase>();
        NextLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        CleanPlaces();
        CreateLevel(baseSetupsLevels[_index]);
        _index++;
        if (_index >= baseSetupsLevels.Length) { _index = 0; }
    }

    private void CleanPlaces()
    {
        for(int i = _spawnPlaces.Count-1; i > -1; i--)
        {
            Destroy(_spawnPlaces[i].gameObject);
        }
        _spawnPlaces = new List<LevelPlacesBase>();
    }

    private void CreateLevel(LevelPlacesBaseSetup baseSetup)
    {
        for(int i = 0; i < baseSetup.maxPlacesStart; i++)
        {
            CreatePlaces(baseSetup.placesStart, baseSetup);
        }
        for(int i = 0; i < baseSetup.maxPlaces; i++)
        {
            CreatePlaces(baseSetup.places, baseSetup);
        }
        for(int i = 0; i < baseSetup.maxPlacesEnd; i++)
        {
            CreatePlaces(baseSetup.placesEnd, baseSetup);
        }

        GameObject.FindObjectOfType<ColorManager>().EditColors(baseSetup.typeArt);
    }

    private void CreatePlaces(LevelPlacesBase[] placesBases, LevelPlacesBaseSetup setup)
    {
        var place = placesBases[Random.Range(0, placesBases.Length)];
        var spawnPlace = Instantiate(place, target);

        if (_spawnPlaces.Count > 0)
        {
            var placeEnd = _spawnPlaces[_spawnPlaces.Count - 1];
            spawnPlace.transform.position = placeEnd.endPlace.position;
        }
        EditArt(setup,spawnPlace);
        _spawnPlaces.Add(spawnPlace);
    }

    private void EditArt(LevelPlacesBaseSetup setup, LevelPlacesBase place)
    {
        var art = gameObject;
        foreach (TypeArtObj typeArt in artManager.typeArtObjs)
        {
            if (typeArt.typeArt == setup.typeArt)
            {
                art = typeArt.art;
                break;
            }
        }
        foreach (ArtSetup artSetup in place.GetComponentsInChildren<ArtSetup>())
        {
            artSetup.EditArt(art);
        }
    }
}