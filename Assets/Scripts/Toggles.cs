using UnityEngine.UI;
using UnityEngine;

public class Toggles : MonoBehaviour
{
  public int defaultDifficultyLevel;
  public Toggle toggler1, toggler2, toggler3;
  void Update()
  {
    defaultDifficultyLevel = PlayerPrefs.GetInt("DefaultDifficultyLevel");
    switch (defaultDifficultyLevel)
    {
      case 1:
        toggler1.isOn = true;
        break;
      case 2:
        toggler2.isOn = true;
        break;
      case 3:
        toggler3.isOn = true;
        break;
    }
  }
}
