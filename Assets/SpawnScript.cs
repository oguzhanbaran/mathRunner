using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private float positionCharacter;
    private float spawnTime;
    private float[] positionX = {-2.99f,0f,2,99f};
    public GameObject gemsPre;
    public GameObject targetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time + 5f; 
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gemsArrays = GameObject.FindGameObjectsWithTag("Gem");
        if (Time.time>spawnTime)
        {
            spawnTime += 5f;
            Vector3 spawnPosition = new Vector3(positionX[Random.Range(0,3)], 2, targetPlayer.transform.position.z+60);
            Instantiate(gemsPre, spawnPosition, Quaternion.identity);
            
        }
        for (int i = 0; i < gemsArrays.Length; i++)
        {
            if (targetPlayer.transform.position.z-3f>gemsArrays[i].transform.position.z)
            {
                Destroy(gemsArrays[i]);
            }
        }
    }
}
