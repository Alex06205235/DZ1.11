using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Vector3 platformToCameraOffset;
    public float speed;
    

    public void Update()
    {
        if (player.currentPlatform == null) return;
        Vector3 targetPosition = player.currentPlatform.transform.position + platformToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
