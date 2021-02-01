using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager_Controller : MonoBehaviour
{
    public static Gamemanager_Controller instance;
    public GameObject Wall;
    int numberOfSpawn = 200;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
            Instantiate(Wall, randomPos, Quaternion.identity);
        }
        if (instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
