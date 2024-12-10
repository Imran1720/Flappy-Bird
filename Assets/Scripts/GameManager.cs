using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    Database db;

    [SerializeField]
    Image Medal;

    [SerializeField]
    TextMeshProUGUI HighScore, Score, GameOverScore, GameOverHighScore;

    [SerializeField]
    GameObject Hud, StartPanel, GameOverPanel, MenuPanel;



    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        GameRestarted();
        SetHighScore();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        SetScore();
    }
    public void PlayGame()
    {

        Hud.SetActive(true);
        StartPanel.SetActive(false);
    }

    public void SetHighScore()
    {
        HighScore.text = db.MaxScore.ToString();
    }


    void SetScore()
    {
        Score.text = db.Score.ToString();
    }

    public void GamePause()
    {
        //db.IsPaused = true;
        Time.timeScale = 0f;
    }

    public void GameResume()
    {
        //db.IsPaused = false;
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        db.IsRestart = false;
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        db.IsStarted = false;
        SetMedal();
        GameOverHighScore.text = db.MaxScore.ToString();
        GameOverScore.text = db.Score.ToString();
        Hud.SetActive(false);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Restart()
    {
        db.IsRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameRestarted()
    {
        if (db.IsRestart)
        {
            db.IsRestart = false;
            db.ClickCounter = 1;
            StartPanel.SetActive(true);
            MenuPanel.SetActive(false);

        }

    }

    void SetMedal()
    {
        if (db.Score < db.MaxScore)
        {
            Medal.sprite = db.Silver;
        }

        else if (db.Score == db.MaxScore)
        {
            Medal.sprite = db.bronze;
        }
        else
        {
            Medal.sprite = db.Gold;

        }


    }

    void setMaxScore()
    {
        if (db.Score > db.MaxScore)
        {
            db.MaxScore = db.Score;
        }
    }
}
