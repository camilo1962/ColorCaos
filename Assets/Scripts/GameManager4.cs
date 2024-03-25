using UnityEngine;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string highScoreKey4 = "HighScore4";

    public int HighScore4
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey4, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey4, value);
        }
    }

    public int CurrentScore4 { get; set; }

    public bool IsInitialized4 { get; set; }

    private void Init()
    {
        CurrentScore4 = 0;
        IsInitialized4 = false;
    }

    public const string MainMenu4 = "MainMenu4";
    public const string Gameplay4 = "Gameplay4";

    public void GoToMainMenu4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu4);
    }

    public void GoToGameplay4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay4);
    }
}
