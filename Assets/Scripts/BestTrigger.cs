using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BestTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        // if (collision.CompareTag("Player"))
        // {
        //     ScoresText.Scores++;
        // }
        if (collision.GetComponent<Collider>().TryGetComponent(out Player player))
        {
            player.perfectPass++;
        };
    }
}
