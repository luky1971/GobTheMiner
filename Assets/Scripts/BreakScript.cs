using UnityEngine;
using System.Collections;

public class BreakScript : MonoBehaviour {

    float disappearDelay = 2.0f;
    float destroyDelay = 2.8f;
    float disSpeed = 2f;

    bool disappearing = false;

	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {
        float delta = Time.deltaTime;
        if (disappearing)
        {
            
            GetComponent<Transform>().position = Vector3.Lerp(GetComponent<Transform>().position,
            new Vector3(GetComponent<Transform>().position.x, -1f, GetComponent<Transform>().position.z),
            delta * disSpeed);
        }
    }

    public void Break()
    {
        Invoke("Disappear", disappearDelay);
        Invoke("DestroyMe", destroyDelay);
    }

    void Disappear()
    {
        disappearing = true;
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
