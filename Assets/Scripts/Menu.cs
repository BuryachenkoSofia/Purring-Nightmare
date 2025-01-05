using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public GameObject toggler;
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

  public void Level(int level)
  {
    PlayerPrefs.SetInt("difficultyLevel", level);
    SceneManager.LoadScene(1);
  }

  public void NextLevel()
  {
    if (PlayerPrefs.GetInt("difficultyLevel") == 3)
    {
      SceneManager.LoadScene(0);
    }
    else
    {
      PlayerPrefs.SetInt("difficultyLevel", PlayerPrefs.GetInt("difficultyLevel") + 1);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }

  public void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}