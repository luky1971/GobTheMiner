using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {
    public GameObject cube;
    public GameObject dcube;
    public static GameObject[,] cubes = new GameObject[31, 31];
    //private List<Vector2> IBlocks = new List<Vector2>();
    
	// Use this for initialization
	void Start () {
        //GenerateMap();
        GenerateBlocks();
	}
	
	// Update is called once per frame
	/*void GenerateMap () {
	for (int x = 0; x < 33; x++)
        {
            mapArray[x, 0] = 1;
            mapArray[x, 32] = 1;
            for (int z = 0; z < 33; z++)
            {
                mapArray[0, z] = 1;
                mapArray[32, z] = 1;
                if ( x>0 && x<32 && z>0 && z < 32)
                {
                    if (x % 2 == 0 && z % 2 == 0) mapArray[x, z] = 1;
                }

            }
        }
        mapArray[15, 16] = 1;
        mapArray[16, 16] = 1;
        mapArray[17, 16] = 1;
        mapArray[18, 16] = 1;

        mapArray[15, 15] = 1;
        mapArray[15, 17] = 1;
        mapArray[16, 15] = -1;
        mapArray[16, 17] = -1;
        mapArray[17, 15] = -1;
        mapArray[17, 17] = -1;
        mapArray[18, 15] = 1;
        mapArray[18, 17] = 1;

        mapArray[15, 14] = -1;
        mapArray[15, 18] = -1;
        mapArray[16, 14] = -1;
        mapArray[16, 18] = 2;
        mapArray[17, 14] = 2;
        mapArray[17, 18] = -1;
        mapArray[18, 14] = -1;
        mapArray[18, 18] = -1;
    }*/

    void GenerateBlocks()
    {
        for (int x = 0; x < 31; x++)
        {
            for (int z = 0; z > -31; z--)
            {
                if (!((x == 14f && z == -14f) || (x == 14f && z == -15f) || (x == 14f && z == -16f)
                    || (x == 15f && z == -14f)  || (x == 15f && z == -15f) || (x == 15f && z == -16f)
                    || (x == 16f && z == -14f) || (x == 16f && z == -15f) || (x == 16f && z == -16f)
                    || (x == 17f && z == -14f) || (x == 17f && z == -15f)|| (x == 17f && z == -16f)
                    || (x == 16f && z == -17f))
                    && (x % 2 == 0 || z % 2 ==0))
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        Quaternion rot = Quaternion.Euler(new Vector3(0, Random.Range(0, 4) * 90, 0));
                        cubes[x, -z] = (GameObject)Instantiate(dcube, new Vector3(x + .5f, 0, z + -.5f), rot);
                    }
                }                
            }
        }
    }
}
