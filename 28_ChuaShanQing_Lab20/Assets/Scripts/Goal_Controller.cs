using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Controller : MonoBehaviour
{
    public ParticleSystem fireWork;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            meshRenderer.enabled = false;
            fireWork.Play();
        }
    }
}
