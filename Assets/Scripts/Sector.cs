using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material BadMaterial;
    public Material GoodMaterial;

    private void Awake()
    {
        UpdateMaterial();
    }
    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;
        if (IsGood)
            player.Bounce();
        else
           Debug.Log("Game over");
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
