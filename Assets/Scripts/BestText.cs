using TMPro;
using UnityEngine;

public class BestText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public static int best;

    private void Update()
    {
        Text.text = "Best:" + best ;
    }

}
