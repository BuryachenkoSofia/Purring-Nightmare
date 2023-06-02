using UnityEngine;

public class purinaOne : MonoBehaviour
{
  public float distance, HP;
  private Transform player;

  public float purinaOneSpeed = 3;
  private Vector3 firstPosition;

  void Start()
  {
    firstPosition = gameObject.transform.position;

    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    distance = Vector3.Distance(gameObject.transform.position, player.position);
  }

  void FixedUpdate()
  {
    HP = PlayerPrefs.GetFloat("HP");
    distance = Vector3.Distance(gameObject.transform.position, player.position);

    if (distance <= 15f)
    // если дистанция < 15 то kiteket идет за игроком
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, purinaOneSpeed * Time.deltaTime);
    }

    else if (distance > 15f && distance < 20f && HP <= 25)
    // если дистанция > 15 и дистанция < 25 и НР <= 20 то kiteket идет за игроком
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, purinaOneSpeed * Time.deltaTime);
    }

    else if (distance > 20f && HP <= 10)
    // если дистанция > 25 и НР <= 5 то kiteket идет за игроком
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, purinaOneSpeed * Time.deltaTime);
    }

    else if (distance > 15f && HP > 25)
    // если дистанция > 15 и НР > 20 то kiteket идет на спавн 
    {
      transform.position = Vector2.MoveTowards(transform.position, firstPosition, purinaOneSpeed * Time.deltaTime);
    }
  }
}