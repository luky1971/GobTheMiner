using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float speed = 0.9f;
    private float rot;

    Vector3 oldPos;
    Vector3 pos;

    public GameObject bomb;
    float bombCooldown = 3f;
    float lastBomb = -3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        pos = GetComponent<Transform>().position;
        if (CanMove())
        {
            oldPos = GetComponent<Transform>().position;
            Move();
        }
        else
        {
            GetComponent<Transform>().position = oldPos;
        }
        Bomb();
	}

    void Move()
    {
        float delta = Time.deltaTime;
        pos = GetComponent<Transform>().position;
        /*Vector3 oldPos = GetComponent<Transform>().position;
        newpos.x = oldPos.x + hor * delta * speed;
        newpos.z = oldPos.z + ver * delta * speed;
        Debug.Log(Mathf.Atan2(oldPos.y - newpos.y, oldPos.x - newpos.x));
        GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0.0f, Mathf.Rad2Deg * Mathf.Atan2(newpos.y - oldPos.y, newpos.x - oldPos.x), 0.0f));*/
        pos.x += Input.GetAxisRaw("Horizontal") * delta * speed;
        pos.z += Input.GetAxisRaw("Vertical") * delta * speed;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            rot = 45f;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            rot = -45f;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            rot = -135f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            rot = 135f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rot = 0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rot = -90f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rot = 90f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rot = -180f;
        }

        GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0.0f, rot, 0.0f));
        GetComponent<Transform>().position = pos;  
    }

    bool CanMove()
    {
        return MapGenerator.cubes[(int)pos.x, -(int)pos.z] == null;
    }

    void Bomb()
    {
        if (Input.GetKey(KeyCode.Space) && (Time.time - lastBomb > bombCooldown))
        {
            pos = GetComponent<Transform>().position;
            Instantiate(bomb, new Vector3((int)pos.x + 0.5f, 0.2f, (int)pos.z - 0.5f), Quaternion.identity);
            lastBomb = Time.time;
        }
    }

    public void Die()
    {
        //GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        Application.LoadLevel(0);
        Destroy(gameObject);
        
    }

}
