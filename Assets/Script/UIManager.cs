using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Texto UI")]
    public Slider playerHealthBar;          // Barra de vida del jugador
    public TextMeshProUGUI xwingText;       // Texto fijo "Xwing"
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

  
        bossUIGroup.SetActive(false);       // Ocultar toda la UI del jefe al inicio
        if (xwingText != null)
        {
            xwingText.text = "X-wing";
        }
    }

    void Start()
    {
        killCount = 0;
        killCountText.text = "Kills: 0";

        if (playerHealthBar != null) //ARREGLAR BARRA NO LLENA ES AGRANDAR EL FILL Y MOVERLO.
        {

            playerHealthBar.maxValue = 100;
            playerHealthBar.value = playerHealthBar.maxValue;
        }

        if (bossHealthBar != null)
        {
            bossHealthBar.maxValue = 100;
            bossHealthBar.value = bossHealthBar.maxValue;
        }
    }

    public void UpdatePlayerHealth(int current, int max)
    {
        if (playerHealthBar != null)
        {
            playerHealthBar.maxValue = max;
            playerHealthBar.value = current;
        }
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
