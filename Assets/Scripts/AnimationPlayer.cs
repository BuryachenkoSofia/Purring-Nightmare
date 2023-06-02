using UnityEngine;
using System.Collections;

public class AnimationPlayer : MonoBehaviour
{
  public GameObject player1, player2;

  private void Start()
  {
    StartCoroutine(AnimationCoroutine());
  }

  IEnumerator AnimationCoroutine()
  {
    while (true)
    {
      player1.gameObject.SetActive(true);
      player2.gameObject.SetActive(false);

      yield return new WaitForSeconds(0.5f);

      player1.gameObject.SetActive(false);
      player2.gameObject.SetActive(true);

      yield return new WaitForSeconds(0.5f);
    }
  }
}