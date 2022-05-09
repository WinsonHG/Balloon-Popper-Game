using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] public static int score;
    const int DEFAULT_POINTS = 100;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] Text nameTxt;
    [SerializeField] public static int level = 0;
    const int SCORE_THRESHOLD_PER_LEVEL = 1;
    [SerializeField] public static int scoreThresholdForThisLevel;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        if (level == 1)
            scoreThresholdForThisLevel = 100;
        if (level == 2)
            scoreThresholdForThisLevel = 300;
        if (level == 3)
            scoreThresholdForThisLevel = 600;

        //display score
        DisplayScore();
        DisplayLevel();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int addend)
    {
        score += addend;
        DisplayScore();
        PersistentData.Instance.SetScore(score);

        Invoke("DelayedAction", 0.5f);
    }

    public void UpdateScore()
    {
        UpdateScore(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level " + levelToDisplay;
    }

    public void DisplayName()
    {
        nameTxt.text = "Player: " + PersistentData.Instance.GetName();
    }
    public void DelayedAction()
    {
        if (score >= scoreThresholdForThisLevel)
        {
            //move on to next level
            SceneManager.LoadScene(level + 1);

        }

    }
}
