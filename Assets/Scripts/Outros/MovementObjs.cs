using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObjs : MonoBehaviour
{
    public Transform target;
    public List<Transform> positions;
    public float delay;
    private List<Transform> _positions;

    private void Start()
    {
        _positions = new List<Transform>();
        foreach(Transform t in positions) { _positions.Add(t); }
        target.position = NextPosition().position;
        StartCoroutine(NextPositionCoroutine());
    }

    IEnumerator NextPositionCoroutine()
    {
        float time = 0;
        while (true)
        {
            if (target == null) { Destroy(gameObject); }
            var pos = target.position;
            Transform t = NextPosition();

            while (time < delay)
            {
                if (target == null) { Destroy(gameObject); }
                else
                {
                    target.position = Vector3.Lerp(pos, t.position, (time / delay));
                }
                time += Time.deltaTime;
                yield return null;
            }
            time = 0;
            yield return null;
        }
    }

    private Transform NextPosition()
    {
        Transform t = _positions[Random.Range(0, _positions.Count)];
        _positions.Remove(t);
        if (_positions.Count <= 0) { foreach (Transform p in positions) { _positions.Add(p); } }
        return t;
    }
}