using TMPro;
using UnityEngine;

public class TextLevel : MonoBehaviour
{

    public TextMeshProUGUI text;
    public Game game;

    private void Start()
    {

        text.text = "Level " + (game.LevelIndex + 1).ToString();

    }
}
