using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{

    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    [SerializeField] float TimeToRestart = 25f / Scorekeeper.level;

    // Start is called before the first frame update

    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (audio == null)
            audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Balloon.yup > TimeToRestart)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Scorekeeper.level);
            if (Scorekeeper.level == 2 && Scorekeeper.score >= 200)
                PersistentData.Instance.SetScore(Scorekeeper.score - 100);
            if (Scorekeeper.level == 3 && Scorekeeper.score > 300)
                PersistentData.Instance.SetScore(Scorekeeper.score - 100);
            if (Scorekeeper.level == 3 && Scorekeeper.score > 400)
                PersistentData.Instance.SetScore(Scorekeeper.score - 200);
            Balloon.yup = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Egg")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<Scorekeeper>().UpdateScore();
            Destroy(gameObject);

        }


    }
}

