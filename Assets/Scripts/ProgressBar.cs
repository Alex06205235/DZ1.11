using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player player;
    public Transform finishPlatform;
    public Slider slider;

    private float _startY;
    private float _minimumReachedY;
    public float asseptableFinishPlayerDistance;
    private void Start()
    {
        _startY = player.transform.position.y;
    }


    private void Update()
    {
        _startY = Mathf.Min(_minimumReachedY, player.transform.position.y);
        float finishY = player.transform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + asseptableFinishPlayerDistance, _minimumReachedY);
        slider.value = t;
    }
}
