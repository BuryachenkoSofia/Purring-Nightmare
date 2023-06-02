using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
//   public PlayerControl player;
  private Image healthBar;
  public float maxHealth = 100f;
  public float HP = 100f;
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
