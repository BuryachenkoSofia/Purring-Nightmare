using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public GameObject toggler; // объект toggle

  private void Update()
  {
    if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.LeftControl))
    {
      Application.Quit();
    }
  }

  public void setDifficultyLevel(int difficultyLevel)
  {
    PlayerPrefs.SetInt("difficultyLevel", difficultyLevel);
    PlayerPrefs.SetInt("DefaultDifficultyLevel", difficultyLevel);
  }

  public void ToMenu()
  {
    PlayerPrefs.SetInt("difficultyLevel", 1);
    SceneManager.LoadScene(0);
  }
  public void StartGame()
  {
    PlayerPrefs.SetInt("difficultyLevel", PlayerPrefs.GetInt("DefaultDifficultyLevel"));
    SceneManager.LoadScene(1);
  }
  public void Level1()
  {
    PlayerPrefs.SetInt("difficultyLevel", 1);
    SceneManager.LoadScene(1);
  }
  public void Level2()
  {
    PlayerPrefs.SetInt("difficultyLevel", 2);
    SceneManager.LoadScene(1);
  }
  public void Level3()
  {
    PlayerPrefs.SetInt("difficultyLevel", 3);
    SceneManager.LoadScene(1);
  }
  public void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
  public void ExitGame()
  {
    Application.Quit();
  }
  public void userToggle()
  {
    if (toggler.GetComponent<Toggle>().isOn)
    {
      PlayerPrefs.SetInt("isPC", 1);
    }
    else if (!toggler.GetComponent<Toggle>().isOn)
    {
      PlayerPrefs.SetInt("isPC", 0);
    }
  }
}
