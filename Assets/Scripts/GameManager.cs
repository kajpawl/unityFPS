using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    //instance
    public static GameManager instance;

    void Awake()
    {
        // set the instance to this script
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        // toggle the pause menu
        GameUI.instance.TogglePauseGame(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;

        // update the score text
        GameUI.instance.UpdateScoreText(curScore);

        // have we reached the score to win?
        if (curScore >= scoreToWin)
            WinGame();
    }

    void WinGame()
    {
        // set the end game screen
        GameUI.instance.SetEndGameScreen(true, curScore);
    }
}
