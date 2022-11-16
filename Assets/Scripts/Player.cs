using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody rigidbody;
    public Platform CurrentPlatform;
    public Game Game;
    

    public void ReachFinish()
    {
        Game.OnPlayerReacheFinish();
        rigidbody.velocity = Vector3.zero;
    }
    public void Bounce()
    {
        rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void Die()
    {
        Game.OnPlayerDied();
        rigidbody.velocity = Vector3.zero;
    }
}
