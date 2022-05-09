using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputField playerNameInput;
    public countTime counter = new countTime();

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("level1");
        PersistentData.Instance.SetScore(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Leaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public void Quit()
    {
        Application.Quit();


    }


}

