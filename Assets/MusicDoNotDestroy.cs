using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDoNotDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
