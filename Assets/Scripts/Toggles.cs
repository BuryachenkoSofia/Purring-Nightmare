using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class Toggles : MonoBehaviour
{
  private PostProcessVolume _PostProcessVolume;
  private Bloom _Bloom;
  private Grain _Grain;
  [Header("Toggles")]
  public Toggle[] levelToggles = new Toggle[3];
  public Toggle bloom, grain;
  [Header("Sliders")]
  public Slider musicSlider;
  public Slider soundsSlider;
  public Slider allSlider;

  void Start()
  {
    if (!PlayerPrefs.HasKey("DefaultDifficultyLevel"))
    {
      PlayerPrefs.SetInt("DefaultDifficultyLevel", 1);
    }
    if (!PlayerPrefs.HasKey("isBloom"))
    {
      PlayerPrefs.SetInt("isBloom", 1);
    }
    if (!PlayerPrefs.HasKey("isGrain"))
    {
      PlayerPrefs.SetInt("isGrain", 1);
    }
    _PostProcessVolume = GetComponent<PostProcessVolume>();
    _PostProcessVolume.profile.TryGetSettings(out _Grain);
    _PostProcessVolume.profile.TryGetSettings(out _Bloom);

    if (!PlayerPrefs.HasKey("MusicVolume"))
    {
      PlayerPrefs.SetFloat("MusicVolume", 1f);
    }
    if (!PlayerPrefs.HasKey("SoundsVolume"))
    {
      PlayerPrefs.SetFloat("SoundsVolume", 1f);
    }
    if (!PlayerPrefs.HasKey("AllVolume"))
    {
      PlayerPrefs.SetFloat("AllVolume", 1f);
    }
    if (SceneManager.GetActiveScene().buildIndex == 0)
    {
      for (int i = 0; i < 3; i++)
      {
        levelToggles[i].isOn = false;
      }
      for (int i = 0; i < 3; i++)
      {
        if (PlayerPrefs.GetInt("DefaultDifficultyLevel") == i + 1)
        {
          levelToggles[i].isOn = true;
        }
      }
      musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
      soundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
      allSlider.value = PlayerPrefs.GetFloat("AllVolume");
    }
  }
  void Update()
  {
    if (SceneManager.GetActiveScene().buildIndex == 0)
    {
      PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
      PlayerPrefs.SetFloat("SoundsVolume", soundsSlider.value);
      PlayerPrefs.SetFloat("AllVolume", allSlider.value);
      if (PlayerPrefs.GetInt("isBloom") == 1)
      {
        bloom.GetComponent<Toggle>().isOn = true;
        _Bloom.active = true;
      }
      else if (PlayerPrefs.GetInt("isBloom") == 0)
      {
        bloom.GetComponent<Toggle>().isOn = false;
        _Bloom.active = false;
      }
      if (PlayerPrefs.GetInt("isGrain") == 1)
      {
        grain.GetComponent<Toggle>().isOn = true;
        _Grain.active = true;
      }
      else if (PlayerPrefs.GetInt("isGrain") == 0)
      {
        grain.GetComponent<Toggle>().isOn = false;
        _Grain.active = false;
      }
    }
    else if (SceneManager.GetActiveScene().buildIndex != 0)
    {
      if (PlayerPrefs.GetInt("isGrain") == 1) _Grain.active = true;
      else if (PlayerPrefs.GetInt("isGrain") == 0) _Grain.active = false;

      if (PlayerPrefs.GetInt("isBloom") == 1) _Bloom.active = true;
      else if (PlayerPrefs.GetInt("isBloom") == 0) _Bloom.active = false;
    }
  }
  public void BloomToggle()
  {
    if (bloom.GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("isBloom", 1);
    else if (!bloom.GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("isBloom", 0);
  }
  public void GrainToggle()
  {
    if (grain.GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("isGrain", 1);
    else if (!grain.GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("isGrain", 0);
  }

  public void Toggler(int i)
  {
    if (levelToggles[i].GetComponent<Toggle>().isOn)
    {
      PlayerPrefs.SetInt("DefaultDifficultyLevel", i + 1);
    }
  }
}