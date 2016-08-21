using UnityEngine;
using System.Collections;

public class ManBearSwineController : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform target;

    float soundTime = 0f;

    private AudioSource pig;
    private AudioSource bear;
    private AudioSource breakRock;

    Vector3 cubePos;
    Vector3 pos;
    Vector3 oldPos;

    private float stopTime = 3.0f;

	// Use this for initialization
	void Start () {
        pig = GetComponent<AudioSource>();
        bear = GetComponent<Transform>().GetChild(2).GetComponent<AudioSource>();
        breakRock = GetComponent<Transform>().GetChild(3).GetComponent<AudioSource>();

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<MeshRenderer>().enabled = CanRender();

        pos = GetComponent<Transform>().position;
        if (CanMove())
        {
            oldPos = pos;
            agent.enabled = true;
            agent.SetDestination(target.position);
        }
        else
        {
            MapGenerator.cubes[(int)pos.x, -(int)pos.z].GetComponent<BreakScript>().Break();
            breakRock.Play();
            agent.enabled = false;
            GetComponent<Transform>().position = oldPos;
            Invoke("ActivateAgent", stopTime);
        }

        if ((Time.time - soundTime) >= 5)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                pig.Play();
            }
            else
            {
                bear.Play();
            }
            soundTime = Time.time;
        }

        if (Vector3.Distance(GetComponent<Transform>().position, target.position) < 1)
        {
            target.gameObject.GetComponent<PlayerController>().Die();
        }
	}

    bool CanMove()
    {
        return MapGenerator.cubes[(int)pos.x, -(int)pos.z] == null;
    }

    void ActivateAgent()
    {
        Debug.Log("Activate!");
        agent.enabled = true;
        agent.SetDestination(target.position);
    }

    bool CanRender()
    {
        Vector3 p = GetComponent<Transform>().position;
        float dist = Vector3.Distance(p, target.position);
        Vector3 n = Vector3.Normalize(p - target.position);
        for (int i = 0; i < dist; i++)
        {
            n.Normalize();
            n.Scale(new Vector3(i,i,i));
            if (IsPermaBlock((int)n.x, (int)n.z))
            {
                return false;
            }
        }
        return true;
    }

    public void Die()
    {
        Destroy(gameObject);
        Application.LoadLevel(0);
    }

    bool IsPermaBlock(int x, int z)
    {
        return !((x == 14f && z == -14f) || (x == 14f && z == -15f) || (x == 14f && z == -16f)
                    || (x == 15f && z == -14f) || (x == 15f && z == -15f) || (x == 15f && z == -16f)
                    || (x == 16f && z == -14f) || (x == 16f && z == -15f) || (x == 16f && z == -16f)
                    || (x == 17f && z == -14f) || (x == 17f && z == -15f) || (x == 17f && z == -16f)
                    || (x == 16f && z == -17f))
                    && (x % 2 == 0 || z % 2 == 0);
    }
}
