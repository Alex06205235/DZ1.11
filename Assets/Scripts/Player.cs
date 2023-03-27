using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

enum PlayerState
{
    Die,
    Alive,
}

public class Player : MonoBehaviour
{
    public float bounceSpeed;
    public Rigidbody rigidbody;
    public Platform currentPlatform;
    public Game game;
    public int perfectPass;
    public bool isSupperSpeedActive;
    public float impulsForce = 5f;
    public AudioSource plop;
    public AudioClip finish;
    public Controls controls;
    bool _ignoreNextCollision;
    Material _playerMaterial;
    Material _tailMaterial;
    PlayerState _state;
    public GameObject deathPlayer;
    ParticleSystem _part;
    ParticleSystem _partS;
    public GameObject deathSector;
    

    void Awake()
    {
        _playerMaterial = GetComponent<MeshRenderer>().material;
        _tailMaterial = GetComponent<TrailRenderer>().material;
        _state = PlayerState.Alive;
        _part = deathPlayer.GetComponent<ParticleSystem>();
        _partS = deathSector.GetComponent<ParticleSystem>();
    }

    public void ReachFinish()
    {
        
        game.OnPlayerReacheFinish();
        rigidbody.velocity = Vector3.zero;
        
    }
    public void Bounce()
    {
        if (_state != PlayerState.Alive)
            return;
        rigidbody.velocity = new Vector3(0, bounceSpeed, 0);
        plop.Play();
    }

    public void Die()
    {
        rigidbody.velocity = Vector3.zero;
        _state = PlayerState.Die;
        controls.enabled = false;
        StartCoroutine(BurnDownPlayer(-0.2f, 1.06f, game.OnPlayerDied));
        _part.Play();
        // game.OnPlayerDied();

    }

    IEnumerator BurnDownPlayer(float start, float end, Action action)
    {
        while (start < end)
        {
            _playerMaterial.SetFloat("Death01", start);
            _tailMaterial.SetFloat("Death01", start);
            start += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        action();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ignoreNextCollision) return;

        if (isSupperSpeedActive)
        {
            if (!collision.gameObject.CompareTag("Platform"))
            {
                Destroy(collision.gameObject);
                _partS.Play();
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
