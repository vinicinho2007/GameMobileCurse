using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpImgsTaypes
{
    PowerUpCoin,
    PowerUpSpeed,
    PowerUpInvencible,
}

[System.Serializable]
public class GameObjectsImgsPowerUps
{
    public PowerUpImgsTaypes type;
    public GameObject obj;
}

public class PowerUpImgs : MonoBehaviour
{
    public GameObjectsImgsPowerUps[] powerUpObjs;
}