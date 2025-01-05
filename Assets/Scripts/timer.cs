using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{
  public GameObject deadPanel;
  public Text timetext;
  private float startTime;
  private float timeLeft;
  public AudioSource deadAudio;
  public int difficultyLevel;

  void Start()
  {
    difficultyLevel = PlayerPrefs.GetInt("difficultyLevel");
    startTime = 60f*(6f-difficultyLevel);
    timeLeft = startTime;
  }

  void Update()
  {
    timetext.text = "" + Mathf.Round(timeLeft);
    if (timeLeft > 0)
    {
      timeLeft -= Time.deltaTime;
    }
    else
    {
      timetext.text = "TIME IS OVER";
      deadAudio.Play();
      deadPanel.gameObject.SetActive(true);
      Time.timeScale = 0f;
    }
  }
}