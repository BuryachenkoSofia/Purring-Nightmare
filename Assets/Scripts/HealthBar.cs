using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  private Image healthBar;
  private float maxHealth = 100f, HP = 100f;
  void Start()
  {
    healthBar = GetComponent<Image>();
  }
  void Update()
  {
    HP = PlayerPrefs.GetFloat("HP");
    healthBar.fillAmount = HP / maxHealth;
  }
}
