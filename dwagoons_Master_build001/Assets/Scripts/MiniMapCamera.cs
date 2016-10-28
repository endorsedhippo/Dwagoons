using UnityEngine;
using System.Collections;

public class MiniMapCamera : MonoBehaviour {

    public float size = 0.3f;
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        SetCameraScale();
	}

    void SetCameraScale()
    {
        //cam.ViewportToScreenPoint(new Vector3(Screen.width / 2, width / 2, 1));
        float pixels = Screen.height * size;
        float width = pixels / Screen.width;

        cam.rect = new Rect(0.5f - (width / 2), 0, width, size);
    }
}
