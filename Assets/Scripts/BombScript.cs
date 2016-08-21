using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Explode", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Explode()
    {
        //
    }
}
