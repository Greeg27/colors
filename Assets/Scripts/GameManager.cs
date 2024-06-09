using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Parameters")]
    [SerializeField, Range(3, 24)] int columns;
    [SerializeField] int rows;
    [SerializeField] int seconds;
    [SerializeField] float playerSpeed;
    [SerializeField] float roomAngle;
    [SerializeField] float roomAngleBoost;

    [Header("UI objects")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject manualPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pauseButton;

    [Header("Scripts")]
    [SerializeField] LevelRoomParamScript levelRoomParamScript;
    [SerializeField] LavelRoomRotateScript lavelRoomRotateScript;
    [SerializeField] SeriesCreationScript seriesCreationScript;
    [SerializeField] TimerScript timerScript;

    private bool pause;
    private bool gameOver;

    private void Awake()
    {
        GlobalVars.PlayerSpeed = playerSpeed;

        levelRoomParamScript.SetParametrs(columns, rows);
        lavelRoomRotateScript.SetParametrs(roomAngle, roomAngleBoost);
        seriesCreationScript.SetParametrs(columns, rows);
        timerScript.SetParametrs(seconds);
    }

    public void Pause()
    {
        if (!gameOver)
        {
            pause = !pause;

            menuPanel.SetActive(pause);
            pauseButton.SetActive(!pause);
            manualPanel.SetActive(false);

            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        pauseButton.SetActive(false);
        gameOverPanel.SetActive(true);

        gameOver = true;
    }
    
}
