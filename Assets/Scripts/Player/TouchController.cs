using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x-pastPosition.x);
        }
        pastPosition = Input.mousePosition;
    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed*velocity;
    }
}