using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            BestText.best++;
            
        }


    }
}
