
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform level;
    private Vector3 _previousMousePosition;
    private float sensitivity;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            level.Rotate(0, delta.x + sensitivity, 0);
        }

        _previousMousePosition = Input.mousePosition;
    }
}
