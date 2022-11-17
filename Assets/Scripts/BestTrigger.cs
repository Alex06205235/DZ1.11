using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoresText.Scores++;
        }
    }
}
