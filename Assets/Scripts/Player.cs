using UnityEngine;

public class Player : MonoBehaviour
{
    public float bounceSpeed;
    public Rigidbody rigidbody;
    public Platform currentPlatform;
    public Game game;


    public void ReachFinish()
    {
        game.OnPlayerReacheFinish();
        rigidbody.velocity = Vector3.zero;
    }
    public void Bounce()
    {
        rigidbody.velocity = new Vector3(0, bounceSpeed, 0);
    }

    public void Die()
    {
        game.OnPlayerDied();
        rigidbody.velocity = Vector3.zero;
    }
}
