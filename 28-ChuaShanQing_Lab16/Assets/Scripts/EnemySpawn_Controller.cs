using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_Controller : MonoBehaviour
{
    public GameObject EnemyPrefab; // EnemyPrefab
    public float spwanInterval; //Interval between each spwan

    // Spawn area //
    public float minX;
    public float manX;
    public float minZ;
    public float manZ;


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(WaitAndSpawn(spwanInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndSpawn (float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPosition = new Vector3(Random.Range(minX, manX), 0.5f, Random.Range(minZ, manZ));
            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
