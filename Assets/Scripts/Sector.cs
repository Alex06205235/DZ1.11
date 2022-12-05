using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool isGood = true;
    public Material badMaterial;
    public Material goodMaterial;

    private void Awake()
    {
        UpdateMaterial();
    }
    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = isGood ? goodMaterial : badMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;
        player.Bounce();
      
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
