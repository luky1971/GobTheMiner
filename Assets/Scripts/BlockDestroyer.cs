using UnityEngine;
using System.Collections;

public class BlockDestroyer : MonoBehaviour {

    Vector3 pos;
    public GameObject bear;
    public GameObject Player;
    private float startTime;

    private AudioSource explode;

    public GameObject explosion;

    void Start () 
    {
        explode = GetComponent<AudioSource>();
        startTime = Time.time;

    }

    void Update()
    {
        if (Time.time - startTime >= 3) {
            DestroyMe();
            Destroy(gameObject);
        }

        
    }
	// Use this for initialization
	void DestroyMe () {
        Instantiate(explosion, new Vector3(GetComponent<Transform>().position.x, 0f, GetComponent<Transform>().position.z), Quaternion.identity);
        Invoke("Blow", 2.8f);
        bool left = false, up = false, right = false, down = false;
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = GetComponent<Transform>().position;
            if(!left){
                int xPoint = (int)pos.x - i;
                int zPoint =  -(int)pos.z;
                bool permaBlock = IsPermaBlock(xPoint, zPoint);

                if (!permaBlock)
                {
                    Instantiate(explosion, new Vector3(xPoint, 0f, -zPoint), Quaternion.identity);
                }

                checkHitPlayer(xPoint, zPoint);

                if (MapGenerator.cubes[xPoint, zPoint] != null)
                {
                    Destroy(MapGenerator.cubes[xPoint, zPoint]);
                    left = true;
                }
                if (!permaBlock)
                {
                    left = true;
                }
            }
            if (!right)
            {
                int xPoint = (int)pos.x + i;
                int zPoint = -(int)pos.z;
                bool permaBlock = IsPermaBlock(xPoint, zPoint);

                if (!permaBlock)
                {
                    Instantiate(explosion, new Vector3(xPoint, 0f, -zPoint), Quaternion.identity);
                }

                checkHitPlayer(xPoint, zPoint);

                if (MapGenerator.cubes[xPoint, zPoint] != null)
                {
                    Destroy(MapGenerator.cubes[xPoint, zPoint]);
                    right = true;
                }
                if (!permaBlock)
                {
                    right = true;
                }
            }
            if (!up)
            {
                int xPoint = (int)pos.x;
                int zPoint = -(int)pos.z - i;
                bool permaBlock = IsPermaBlock(xPoint, zPoint);

                if (!permaBlock)
                {
                    Instantiate(explosion, new Vector3(xPoint, 0f, -zPoint), Quaternion.identity);
                }

                checkHitPlayer(xPoint, zPoint);

                if (MapGenerator.cubes[xPoint, zPoint] != null)
                {
                    Destroy(MapGenerator.cubes[xPoint, zPoint]);
                    up = true;
                }
                if (!permaBlock)
                {
                    up = true;
                }
            }
            if (!down)
            {
                int xPoint = (int)pos.x;
                int zPoint = -(int)pos.z + 1;
                bool permaBlock = IsPermaBlock(xPoint, zPoint);

                if (!permaBlock)
                {
                    Instantiate(explosion, new Vector3(xPoint, 0f, -zPoint), Quaternion.identity);
                }

                checkHitPlayer(xPoint, zPoint);

                if (MapGenerator.cubes[xPoint, zPoint] != null)
                {
                    Destroy(MapGenerator.cubes[xPoint, zPoint]);
                    down = true;
                }
                if (!permaBlock)
                {
                    down = true;
                }
            }

        }
        /*pos = GetComponent<Transform>().position;
        Debug.Log((int)pos.x);
        Debug.Log((int)pos.z);
        //Destroy(MapGenerator.destrcube[(int)pos.x, (int)pos.z]);
        for (int x = 1; x <=3; x++)
        {
            
            if (MapGenerator.cubes[((int)pos.x + x), ((int)pos.z*-1)] != null)
            {
                Destroy(MapGenerator.cubes[((int)pos.x + x), ((int)pos.z * -1)]);
                //Instantiate(block, new Vector3((int)pos.x + x, .5f, ((int)pos.z)), Quaternion.identity);
                break;
            }
            
        }
        for (int x = -1; x >= -3; x--)
        {
            if (MapGenerator.cubes[((int)pos.x + x), ((int)pos.z * -1)] != null)
            {
                Destroy(MapGenerator.cubes[((int)pos.x + x), ((int)pos.z * -1)]);
                //Instantiate(block, new Vector3((int)pos.x + x, .5f, ((int)pos.z)), Quaternion.identity);

                break;
            }

        }
        for (int z = 1; z <= 3; z++)
        {
            if (MapGenerator.cubes[(int)pos.x, ((int)pos.z * -1) + z] != null)
            {
                Destroy(MapGenerator.cubes[(int)pos.x, ((int)pos.z * -1) + z]);
                //Instantiate(block, new Vector3((int)pos.x, .5f, ((int)pos.z) + z), Quaternion.identity);

                break;
            }

        }
        for (int z = -1; z >= -3; z--)
        {
            if (MapGenerator.cubes[(int)pos.x, ((int)pos.z * -1) + z] != null)
            {
                Destroy(MapGenerator.cubes[(int)pos.x, ((int)pos.z*-1) + z]);
                //Instantiate(block, new Vector3((int)pos.x, .5f, ((int)pos.z) + z), Quaternion.identity);

                break;
            }

        }
        */




        /*if ((int)ppos.position.x >= (int)pos.x -3 && (int)ppos.position.x <= (int)pos.x + 3 && (int)ppos.position.z >= (int)pos.z - 3 && (int)ppos.position.z <= (int)pos.z + 3)
        {
            Destroy(Player);
        }*/
    }

    bool IsPermaBlock(int x, int z)
    {
        return !((x == 14f && z == -14f) || (x == 14f && z == -15f) || (x == 14f && z == -16f)
                    || (x == 15f && z == -14f)  || (x == 15f && z == -15f) || (x == 15f && z == -16f)
                    || (x == 16f && z == -14f) || (x == 16f && z == -15f) || (x == 16f && z == -16f)
                    || (x == 17f && z == -14f) || (x == 17f && z == -15f)|| (x == 17f && z == -16f)
                    || (x == 16f && z == -17f))
                    && (x % 2 == 0 || z % 2 ==0);
    }

    void checkHitPlayer(int x, int z)
    {
        if ((int)Player.GetComponent<Transform>().position.x == x && (int)(-Player.GetComponent<Transform>().position.z) == z)
        {
            Player.GetComponent<PlayerController>().Die();
        }

        if ((int)bear.GetComponent<Transform>().position.x == x && (int)-bear.GetComponent<Transform>().position.z == z)
        {
            bear.GetComponent<ManBearSwineController>().Die();
        }
    }

    void Blow()
    {
        explode.Play();
    }
}
