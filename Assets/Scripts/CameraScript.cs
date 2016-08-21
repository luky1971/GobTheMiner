using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform target;
    private float lerpFactor = 0.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().position = Vector3.Lerp(GetComponent<Transform>().position,
            new Vector3(target.position.x, target.position.y + 4.0f, target.position.z - 4.0f),
            Time.deltaTime * lerpFactor);
	}
}
