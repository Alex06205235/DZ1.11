using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls controls;
    public AudioClip finish;
    public AudioClip loss;

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
        StartCoroutine (ReloadLevelAndPlayMusic(loss));
        CurrneState = State.Loss;
        Debug.Log("Game Over!");
        ScoresText.Scores = 0;
    }

    public void OnPlayerReacheFinish()
    {
        if (CurrneState != State.Playing) return;
        StartCoroutine (ReloadLevelAndPlayMusic(finish));
        CurrneState = State.Won;
        LevelIndex++;
        controls.enabled = false;
        Debug.Log("You won");
    }
    
    IEnumerator ReloadLevelAndPlayMusic(AudioClip clip)
    {
        AudioSource _audioSource = gameObject.GetComponentInChildren<AudioSource>();
        _audioSource.PlayOneShot(clip);
        while (_audioSource.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
