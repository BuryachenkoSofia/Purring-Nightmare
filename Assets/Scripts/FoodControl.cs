using UnityEngine;

public class FoodControl : MonoBehaviour
{
    private float distance, HP, speed = 2;
    private Transform player;
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
        if (this.tag == "GreenFood")
        {
            speed = 2f;
            GreenFood();
        }
        else if (this.tag == "RedFood")
        {
            speed = 2.5f;
            RedFood();
        }
        else if (this.tag == "BlueFood")
        {
            speed = 3f;
            BlueFood();
        }
    }
    void GreenFood()
    {
        if (distance <= 15f) MoveToPlayer();
        else if (distance > 15f && distance < 20f && HP <= 20) MoveToPlayer();
        else if (distance > 20f && HP <= 5) MoveToPlayer();
        else if (distance > 15f && HP > 20) MoveToSpawn();
    }
    void RedFood()
    {
        if (distance <= 15f) MoveToPlayer();
        else if (distance > 15f && distance < 20f && HP <= 25) MoveToPlayer();
        else if (distance > 20f && HP <= 10) MoveToPlayer();
        else if (distance > 15f && HP > 25) MoveToSpawn();
    }
    void BlueFood()
    {
        if (distance <= 15f) MoveToPlayer();
        else if (distance > 15f && distance < 20f && HP <= 25) MoveToPlayer();
        else if (distance > 20f && HP <= 10) MoveToPlayer();
        else if (distance > 15f && HP > 25) MoveToSpawn();
    }
    void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void MoveToSpawn()
    {
        transform.position = Vector2.MoveTowards(transform.position, firstPosition, speed * Time.deltaTime);
    }
}