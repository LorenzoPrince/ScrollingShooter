using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManagerScene2 : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI killCountFlootText;
    void Start()
    {
        killCountText.text = $"Kills X-Wing: {GameData.killCount}";
        killCountFlootText.text = $"Kills Fleet: {GameData.killCountFloot}";
    }
}