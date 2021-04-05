using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour {
    // Parameters
    public string sortingLayer;
    public int sortingOrder;

    // Components
    Camera myCam;
    MeshFilter myMF;
    MeshRenderer myMR;

    // Internal
    List<Vector2> listUVs = new List<Vector2>(4);
    Vector2 imageScale;
    float lastCameraZoom;

	void LateUpdate() {
        // Recalculate if camera zoom chances
        float size = myCam.orthographicSize;
        if (size != lastCameraZoom) {
            lastCameraZoom = size;

            imageScale = new Vector2(size * myCam.aspect * 3f, size * 3f);
            transform.localScale = imageScale;
        }

        // Update UVs to simulate horizontal movement
        float sx = imageScale.x;
        float sy = imageScale.y;
        float x = transform.position.x - imageScale.x / 2f;
        float y = transform.position.y - imageScale.y / 2f;

        listUVs[0] = new Vector2(0f + x, 0f + y);
        listUVs[3] = new Vector2(sx + x, sy + y);
        listUVs[1] = new Vector2(sx + x, 0f + y);
        listUVs[2] = new Vector2(0f + x, sy + y);
        myMF.mesh.SetUVs(0, listUVs);
    }

    void Awake() {
        // Components
        myCam = GetComponentInParent<Camera>();
        myMF = GetComponent<MeshFilter>();
        myMR = GetComponent<MeshRenderer>();

        // Set sorting layer
        if (!string.IsNullOrWhiteSpace(sortingLayer)) {
            myMR.sortingLayerName = sortingLayer;
            myMR.sortingOrder = sortingOrder;
        }

        // Initial UVs
        listUVs.Add(new Vector2(0f, 0f));
        listUVs.Add(new Vector2(1f, 1f));
        listUVs.Add(new Vector2(1f, 0f));
        listUVs.Add(new Vector2(0f, 1f));
    }
}