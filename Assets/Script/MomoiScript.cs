using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class MomoiScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public LogicScript logic;
    public Animator animator;

    [SerializeField] private Rigidbody2D momoiRigidbody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        PlayRandomAnimation();
    }

    private void FixedUpdate() {
        momoiRigidbody.velocity = new Vector2(horizontal * speed, momoiRigidbody.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void PlayRandomAnimation() {
        int randomAnim = Random.Range(0, 2);
        animator.SetInteger("Trigger", randomAnim);
        animator.SetTrigger("Trigger");
    }

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    /*private void OnCollisionEnter2D() {
        FindObjectOfType<Manager>().Endgame();
    }*/
    private void OnCollisionEnter2D(Collision2D collision) {
        audioManager.PlaySFX(audioManager.death);
        logic.gameOver();
    }


}

