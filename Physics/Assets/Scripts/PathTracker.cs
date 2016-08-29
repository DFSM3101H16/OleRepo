using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathTracker : MonoBehaviour {

    LineRenderer lineRenderer;
    List<Vector3> path = new List<Vector3>();

    [SerializeField]
    private int pathSegments = 10;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();


        lineRenderer.SetVertexCount(pathSegments + 1);
        for (int i = 0; i < pathSegments + 1; i++) {
            lineRenderer.SetPosition(i, transform.position);
        }

        StartCoroutine(TracePath());
    }

    IEnumerator TracePath() {
        for (;;) {
            path.Add(transform.position);
            int startVal = path.Count;
            if (startVal < 0) {
                startVal = 0;
            }
            for (int i = path.Count - 1; i >= path.Count - pathSegments - 1 && i >= 0; i--) {
                lineRenderer.SetPosition(path.Count - i - 1, path[i]);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
