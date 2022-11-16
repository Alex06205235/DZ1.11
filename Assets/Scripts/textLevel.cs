using TMPro;
using UnityEngine;

public class textLevel : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public Game Game;

    private void Start()
    {

        Text.text = "Level " + (Game.LevelIndex + 1).ToString();

    }
}
