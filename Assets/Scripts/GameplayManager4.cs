using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameplayManager4 : MonoBehaviour
{
    #region START4

    private bool hasGameFinished4;
    public GameObject panelGameOver4;
    public static GameplayManager4 Instance;

    public List<Color> Colors4;

    private void Awake()
    {
        Instance = this;

        hasGameFinished4 = false;
        GameManager4.Instance.IsInitialized4 = true;

        score4 = 0;
        _scoreText4.text = ((int)score4).ToString();
        StartCoroutine(SpawnScore4());
    }

    public void Start()
    {
        panelGameOver4.SetActive(false);
    }

    #endregion

    #region GAME_LOGIC4

    [SerializeField] private ScoreEffect4 _scoreEffect4;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasGameFinished4)
        {
            if(CurrentScore4 == null)
            {
                GameEnded4();
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit4 = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(!hit4.collider || !hit4.collider.gameObject.CompareTag("Block"))
            {
                GameEnded4();
                return;
            }

            int currentScoreId4 = CurrentScore4.ColorId4;
            int clickedScoreId4 = hit4.collider.gameObject.GetComponent<Player4>().ColorId4;


            if(currentScoreId4 != clickedScoreId4)
            {
                GameEnded4();
                return;
            }

            var t = Instantiate(_scoreEffect4, CurrentScore4.gameObject.transform.position, Quaternion.identity);
            t.Init4(Colors4[currentScoreId4]);

            var tempScore4 = CurrentScore4;
            if(CurrentScore4.NextScore4 != null)
            {
                CurrentScore4 = CurrentScore4.NextScore4;
            }
            Destroy(tempScore4.gameObject);

            UpdateScore4();
            
        }
    }

    #endregion

    #region SCORE4

    private float score4;
    [SerializeField] private TMP_Text _scoreText4;
    [SerializeField] private AudioClip _pointClip4;

    private void UpdateScore4()
    {
        score4++;
        SoundManager4.Instance.PlaySound4(_pointClip4);
        _scoreText4.text = ((int)score4).ToString();
    }

    [SerializeField] private float _spawnTime4;
    [SerializeField] private Score4 _scorePrefab4;
    private Score4 CurrentScore4;

    private IEnumerator SpawnScore4()
    {
        Score4 prevScore4 = null;

        while(!hasGameFinished4)
        {
            var tempScore = Instantiate(_scorePrefab4);

            if(prevScore4 == null)
            {
                prevScore4 = tempScore;
                CurrentScore4 = prevScore4;
            }
            else
            {
                prevScore4.NextScore4 = tempScore;
                prevScore4 = tempScore;
            }

            yield return new WaitForSeconds(_spawnTime4);
        }
    }

    #endregion

    #region GAME_OVER4

    [SerializeField] private AudioClip _loseClip4;
    public UnityAction GameEnd4;

    public void GameEnded4()
    {
        panelGameOver4.SetActive(true);
        hasGameFinished4 = true;
        GameEnd4?.Invoke();
        SoundManager4.Instance.PlaySound4(_loseClip4);
        GameManager4.Instance.CurrentScore4 = (int)score4;
        StartCoroutine(GameOver4());
    }

    private IEnumerator GameOver4()
    {
        yield return new WaitForSeconds(2f);
        GameManager4.Instance.GoToMainMenu4();
    }

    #endregion
}
