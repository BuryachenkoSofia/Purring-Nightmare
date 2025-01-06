using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public GameObject toggler;
  public GameObject pausePanel, pauseButton;
  public Sprite pauseSprite, playSprite;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Pause();
    }
  }

  public void setDifficultyLevel(int difficultyLevel)
  {
    PlayerPrefs.SetInt("difficultyLevel", difficultyLevel);
    PlayerPrefs.SetInt("DefaultDifficultyLevel", difficultyLevel);
  }

  public void Pause()
  {
    if (Time.timeScale == 1f)
    {
      Time.timeScale = 0f;
      pausePanel.SetActive(true);
      pauseButton.GetComponent<Image>().sprite = playSprite;
    }
    else
    {
      Time.timeScale = 1f;
      pausePanel.SetActive(false);
      pauseButton.GetComponent<Image>().sprite = pauseSprite;
    }
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