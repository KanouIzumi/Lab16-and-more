using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int healthCount;
    public int coinCount;

    bool onAir;

    private Rigidbody2D rb;
    private Animator animator;

    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, -1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }
        else
        {
            animator.SetFloat("xVelocity", 0);
        }

        PlayerJump();

        Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);

        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onAir = false;
            //audioSource.PlayOneShot(AudioClipBGMArr[0]);
        }
    }


    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onAir == false)
        {
            animator.SetTrigger("JumpTrigger");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onAir = true;
        }
    }
}
