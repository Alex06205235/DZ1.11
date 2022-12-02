
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.ReachFinish();
        };
    }
}
