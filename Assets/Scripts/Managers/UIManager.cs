using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text healthText;    // Referensi ke teks Health
    public Text pointsText;    // Referensi ke teks Points
    public Text waveText;      // Referensi ke teks Wave
    public Text enemiesText;   // Referensi ke teks Enemies

    public void UpdateHealth(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void UpdatePoints(int points)
    {
        pointsText.text = "Points: " + points.ToString();
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave.ToString();
    }

    public void UpdateEnemies(int enemies)
    {
        enemiesText.text = "Enemies: " + enemies.ToString();
    }
}

