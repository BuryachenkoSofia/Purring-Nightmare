using UnityEngine.UI;
using UnityEngine;


public class timer : MonoBehaviour
{
  //   public float myTime;
  //   public Text timeText;
  //   private void Update()
  //   {
  //     myTime = myTime + Time.deltaTime;
  //     timeText.text = Math.Floor(myTime) + "";
  //      if (myTime >= 10)
  //      {
  //        Debug.Log("fnhg");
  //      }
  //   }
  // }
  public GameObject deadPanel;
  public Text timetext;
  private float startTime;
  private float timeLeft;
  public AudioSource deadAudio;
  public int difficultyLevel;

  void Start()
  {
    difficultyLevel = PlayerPrefs.GetInt("difficultyLevel");
    switch (difficultyLevel)
    {
      case 1:
        startTime = 300f;
        break;

      case 2:
        startTime = 240f;
        break;

      case 3:
        startTime = 180f;
        break;
    }
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