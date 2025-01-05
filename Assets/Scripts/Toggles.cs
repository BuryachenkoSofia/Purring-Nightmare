using UnityEngine.UI;
using UnityEngine;

public class Toggles : MonoBehaviour
{
  public int defaultDifficultyLevel;
  public Toggle[] toggler = new Toggle[3];
  void Start()
  {
    if (!PlayerPrefs.HasKey("DefaultDifficultyLevel"))
    {
      PlayerPrefs.SetInt("DefaultDifficultyLevel", 1);
    }
  }
  void Update()
  {
    defaultDifficultyLevel = PlayerPrefs.GetInt("DefaultDifficultyLevel");
    for (int i = 0; i < 3; i++)
    {
      if (defaultDifficultyLevel == i + 1)
      {
        toggler[i].isOn = true;
      }
    }
  }
}