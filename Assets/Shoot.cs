using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] AudioSource audio;
    [SerializeField] float horizontal;


    public float speed = 15f;

    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (audio == null)
            audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame

    void Update()
    {

    }
    void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * speed;

        if (transform.position.x > 20 || transform.position.x < -20)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Balloon")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        }
    }


}





