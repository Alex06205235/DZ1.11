using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls controls;
    public AudioSource finish;
    public AudioSource loss;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrneState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrneState != State.Playing) return;
        CurrneState = State.Loss;
        controls.enabled = false;
        Debug.Log("Game Over!");
        ScoresText.Scores = 0;
        loss.Play();
        ReloadLevel();
    }

    public void OnPlayerReacheFinish()
    {
        if (CurrneState != State.Playing) return;
        CurrneState = State.Won;
        LevelIndex++;
        controls.enabled = false;
        finish.Play();
        Debug.Log("You won");
        
        ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
    public void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
