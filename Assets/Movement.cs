using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Shoot EggPrefab;
    public Transform LaunchOffset;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] public float fireRate = 0.5F;
    public Animator anim;
    private float nextFire = 0.0F;


    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (rigid.velocity.x != 0 || Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("isRunning", true);
        }
        if (horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }


        if (Input.GetButtonDown("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(EggPrefab, LaunchOffset.position, LaunchOffset.transform.rotation);
        }

    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(vertical * speed, rigid.velocity.y);
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.x);
        if (horizontal < 0 && isFacingRight || horizontal > 0 && !isFacingRight)
            Flip();

    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}