using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player player;
    public Transform finishPlatform;
    public Slider slider;

    private float _startY;
    private float _minimumReachedY;
    
    private void Start()
    {
        _startY = player.transform.position.y;
    }


    private void Update()
    {
        _startY = Mathf.Min(_minimumReachedY, Mathf.Abs(player.transform.position.y));
        var currentPlayerPosition = player.transform.position.y;
        var t = Mathf.InverseLerp(_startY, finishPlatform.position.y, currentPlayerPosition);
        slider.value = t;
    }
}
