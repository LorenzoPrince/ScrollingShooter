using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Texto UI")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI killCountText;

    [Header("Boss UI")]
    public GameObject bossUIGroup;              // Contenedor que agrupa barra + texto
    public Slider bossHealthBar;
    public TextMeshProUGUI bossNameText;

    private int killCount = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Ocultar toda la UI del jefe al inicio
        bossUIGroup.SetActive(false);
    }

    void Start()
    {
        killCount = 0;
        killCountText.text = "Kills: 0";
    }

    public void UpdatePlayerHealth(int current, int max)
    {
        playerHealthText.text = $"Jugador: {current}/{max} HP";
    }

    public void ShowBossUI(int current, int max)
    {
        bossUIGroup.SetActive(true);
        bossNameText.text = "Darth Vader";
        bossHealthBar.maxValue = max;
        bossHealthBar.value = current;
    }

    public void UpdateBossHealth(int current)
    {
        if (!bossUIGroup.activeSelf)
            bossUIGroup.SetActive(true);

        bossHealthBar.value = current;
    }

    public void HideBossUI()
    {
        bossUIGroup.SetActive(false);
    }

    public void AddKill()
    {
        killCount++;
        killCountText.text = $"Kills: {killCount}";
    }
}
