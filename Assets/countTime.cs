using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class countTime : MonoBehaviour
{
    static public float secondsPassed = 0.00f;



    void Update()
    {

        secondsPassed += Time.deltaTime;

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            this.enabled = false;
        }

    }


}