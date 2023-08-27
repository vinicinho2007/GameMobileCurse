using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererMove : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform[] positionsLineRenderer;

    private void Start()
    {
        lineRenderer.positionCount = positionsLineRenderer.Length;
    }

    private void Update()
    {
        MoveLineRenderer();
    }

    public void MoveLineRenderer()
    {
        for (int i = 0; i < positionsLineRenderer.Length; i++)
        {
            lineRenderer.SetPosition(i, positionsLineRenderer[i].position);
        }
        for (int i = 0; i < positionsLineRenderer.Length; i++)
        {
            if (i + 1 < positionsLineRenderer.Length)
            {
                RaycastHit hit;
                if (Physics.Linecast(positionsLineRenderer[i].position, positionsLineRenderer[i + 1].position,out hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        PlayerController player = hit.transform.GetComponent<PlayerController>();
                        player.StopGameColidiu(player.death);
                    }
                }
            }
        }
    }
}