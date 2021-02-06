using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject PlayerGO;
    Vector3 posOffset = new Vector3(0, 20f, -35f);

    Vector3 posOffset2 = new Vector3(0, 100, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posOffset, 0.1f);
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posOffset2, 1f);
            transform.rotation = Quaternion.Euler(100, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posOffset, 0.1f);
            transform.rotation = Quaternion.Euler(14f, 0, 0);
        }
    }
}
