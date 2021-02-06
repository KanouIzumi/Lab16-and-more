using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Controller : MonoBehaviour
{
    public static GameManager_Controller instance;
    public GameObject Wall;
    int numberOfSpawn = 200;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-200, 200), 2.5f, Random.Range(-200, 200));
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
