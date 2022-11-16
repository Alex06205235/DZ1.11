using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls controls;
    public Player Player;
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
    }

    public void OnPlayerReacheFinish()
    {
        if (CurrneState != State.Playing) return;
        CurrneState = State.Won;
        LevelIndex++;
        controls.enabled = false;
        Debug.Log("You won");
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
    private void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
