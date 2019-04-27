using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileManager : MonoBehaviour
{

    public GameObject[] preFabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLenght = 10f;
    private float safeZone = 15.0f;
    private int tilesOnScreen = 7;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i=0; i<tilesOnScreen;i++)
        {
            if (i < 3)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z  -safeZone> (spawnZ - tilesOnScreen * tileLenght))
        {
            SpawnTile();
            DeleteTile();
        }
        
    }  

    void SpawnTile(int preFabIndex = -1)
    {
        GameObject go;
        if (preFabIndex == -1)
        {
            go = Instantiate(preFabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(preFabs[preFabIndex]) as GameObject;
        }
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLenght;
            activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    int RandomPrefabIndex()
    {
        if(preFabs.Length<=1)
        {
            return 0;

        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, preFabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex; 
    }
}
