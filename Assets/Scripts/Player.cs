using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bounceSpeed;
    public Rigidbody rigidbody;
    public Platform currentPlatform;
    public Game game;
    public int perfectPass;
    public bool isSupperSpeedActive;
    private bool _ignoreNextCollision;
    public float impulsForce = 5f;
    public AudioSource plop;
    public AudioClip finish;
    

    public void ReachFinish()
    {
        
        game.OnPlayerReacheFinish();
        rigidbody.velocity = Vector3.zero;
        
    }
    public void Bounce()
    {
        rigidbody.velocity = new Vector3(0, bounceSpeed, 0);
        plop.Play();
        
    }

    public void Die()
    {
        
        game.OnPlayerDied();
        rigidbody.velocity = Vector3.zero;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ignoreNextCollision) return;

        if (isSupperSpeedActive)
        {
            if (!collision.gameObject.CompareTag("Platform"))
            {
                Destroy(collision.gameObject);
                ScoresText.Scores++;
            }
             
                
        } 
        else if (collision.gameObject.TryGetComponent(out Sector sector))
        {
            if (!sector.isGood) Die();
            
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * impulsForce, ForceMode.Impulse);
        
        _ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);
        
        perfectPass = 0;
        isSupperSpeedActive = false;
        
    }

    private void Update()
    {
        if (perfectPass < 3 || isSupperSpeedActive)
            return;
        isSupperSpeedActive = true;
        rigidbody.AddForce(Vector3.down * 10, ForceMode.Impulse);
    }

    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }
}
