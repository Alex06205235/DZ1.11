using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;

    private float _startY;
    private float _minimumReachedY;
    public float AsseptableFinishPlayerDistance;
    private void Start()
    {
        _startY = Player.transform.position.y;
    }


    private void Update()
    {
        _startY = Mathf.Min(_minimumReachedY, Player.transform.position.y);
        float finishY = Player.transform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + AsseptableFinishPlayerDistance, _minimumReachedY);
        Slider.value = t;
    }
}
