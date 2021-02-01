using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    public float moveSpeed;
    public float rotaSpeed;
    public float jumpForce;
    public Rigidbody PlayerRb;
    bool isOnGround;
    public GameObject Goal;
    public float gravityMod;
    public ParticleSystem Smoke;
    public ParticleSystem smiley;
    public ParticleSystem star;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-200, 200), 10f, Random.Range(-200, 200));
            Instantiate(Goal, randomPos, Quaternion.identity);
            Physics.gravity *= gravityMod;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotaSpeed, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            transform.Rotate(new Vector3(0, Time.deltaTime * rotaSpeed, 0));
        }
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            smiley.Play();
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
        if (isWalking)
        {
            if (!Smoke.isPlaying)
            {
                Smoke.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(collision.gameObject, 2);
            Vector3 randomPos = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
            Instantiate(Goal, randomPos, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            star.Play();
        }
    }


}
