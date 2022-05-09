using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] float horizontal;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] public static float BalloonSize = 0.025f;
    float GrowSpeed = 0.005f;
    public static float yup;
    Vector2 temp;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {

        rigid.transform.localScale += new Vector3(GrowSpeed, GrowSpeed);
        yup += GrowSpeed;

    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(1 * speed, rigid.velocity.x);
        if (rigid.velocity.x < 0 && isFacingRight || rigid.velocity.x > 0 && !isFacingRight)
            Flip();
        if (transform.position.x > 20)
        {
            TeleportBalloon();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void TeleportBalloon()
    {
        transform.position = new Vector2(-18f, Random.Range(-7f, 7f));

    }
    public float getBalloonSize()
    {
        return BalloonSize;
    }

}
