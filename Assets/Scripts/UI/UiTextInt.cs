using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTextInt : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI text;
    public string textInt;

    private void Update()
    {
        text.text = textInt + soInt.value;
    }
}