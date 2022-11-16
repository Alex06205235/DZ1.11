using Assets.Scripts;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Controls controls;
    public enum State
    {
        Plaing,
        Won,
        Loss,
    }
    public State CurrneState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrneState != State.Plaing) return;
        CurrneState = State.Loss;
        controls.enabled = false;
        Debug.Log("Game Over!");
    }
    public void OnPlayerReachFinish()
    {
        if(CurrneState != State.Plaing) return;
        CurrneState = State.Won;
        controls.enabled = false;
        Debug.Log("You Won!");
    }
}
