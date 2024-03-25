using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager4 : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText4;
    [SerializeField] private TMP_Text _newBestText4;
    [SerializeField] private TMP_Text _highScoreText4;

    private void Awake()
    {
        _highScoreText4.text = GameManager4.Instance.HighScore4.ToString();

        if(!GameManager4.Instance.IsInitialized4)
        {
            _scoreText4.gameObject.SetActive(false);
            _newBestText4.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore4());
        }
    }

    [SerializeField] private float _animationTime4;
    [SerializeField] private AnimationCurve _speedCurve4;

    private IEnumerator ShowScore4()
    {
        int tempScore4 = 0;
        _scoreText4.text = tempScore4.ToString();

        int currentScore4 = GameManager4.Instance.CurrentScore4;
        int highScore4 = GameManager4.Instance.HighScore4;

        if(highScore4 < currentScore4)
        {
            _newBestText4.gameObject.SetActive(true);
            GameManager4.Instance.HighScore4 = currentScore4;

        }
        else
        {
            _newBestText4.gameObject.SetActive(false);
        }

        _highScoreText4.text = GameManager4.Instance.HighScore4.ToString();

        float speed = 1 / _animationTime4;
        float timeElapsed4 = 0f;
        while(timeElapsed4 < 1f)
        {
            timeElapsed4 += speed * Time.deltaTime;

            tempScore4 = (int)(_speedCurve4.Evaluate(timeElapsed4) * currentScore4);
            _scoreText4.text = tempScore4.ToString();

            yield return null;
        }

        tempScore4 = currentScore4;
        _scoreText4.text = tempScore4.ToString();

    }

    [SerializeField] private AudioClip _clickSound;

    public void ClickedPlay4()
    {
        SoundManager4.Instance.PlaySound4(_clickSound);
        GameManager4.Instance.GoToGameplay4();
    }

}
