using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player)) return;
        player.ReachFinish();
    }
}
