using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PlayerControl : MonoBehaviour
{
  private Rigidbody2D _rb;
  public GameObject Dver, deadPanel;
  public float speed = 6f, HP = 100f, h;
  private bool fasing = true, dverOpen = false;
  public AudioSource eatAudio, teleportAudio, deadAudio, runAudio;
  public GameObject player1, player2;


  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    HP = 100f;
    PlayerPrefs.SetFloat("HP", HP);
    deadPanel.gameObject.SetActive(false);
    Time.timeScale = 1f;
  }
  private void Update()
  {
    if (dverOpen)
    {
      Dver.gameObject.SetActive(false);
    }
    if (!dverOpen)
    {
      Dver.gameObject.SetActive(true);
    }
  }
  private void FixedUpdate()
  {
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
    transform.position += (Vector3)moveAmount;

    float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

    if (Input.GetKeyDown(KeyCode.E) && HP > 10)
    {
      HP = HP - 10;
      speed += 2;
      PlayerPrefs.SetFloat("HP", HP);
    }

    if (h < 0 && fasing) { Flip(); } // поворт в нужное направление 
    else if (h > 0 && !fasing) { Flip(); } // поворт в нужное направление 
  }

  private void Flip() // поворот в противополошную сторону 
  {
    fasing = !fasing; // изменяем переменную (из true в false, из false в true)
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "kitekat")
    {
      Destroy(other.gameObject);
      player1.gameObject.SetActive(false);
      player2.gameObject.SetActive(true);
      enemyAttaсk(15, 20);
    }
    if (other.gameObject.tag == "whiskas")
    {
      Destroy(other.gameObject);
      player1.gameObject.SetActive(false);
      player2.gameObject.SetActive(true);
      enemyAttaсk(15, 25);
    }
    if (other.gameObject.tag == "purinaOne")
    {
      Destroy(other.gameObject);
      player1.gameObject.SetActive(false);
      player2.gameObject.SetActive(true);
      enemyAttaсk(15, 25);
    }
    if (other.gameObject.tag == "key")
    {
      dverOpen = true;
      Destroy(other.gameObject);
    }
    if (other.gameObject.name == "Teleport")
    {
      teleportAudio.Play();
      if (PlayerPrefs.GetInt("difficultyLevel") + 1 == 4)
      {
        SceneManager.LoadScene(0);
      }
      else
      {
        PlayerPrefs.SetInt("difficultyLevel", PlayerPrefs.GetInt("difficultyLevel") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }

    }
  }
  public void enemyAttaсk(int a, int b)
  {
    eatAudio.Play();

    Random rnd = new Random();
    HP = PlayerPrefs.GetFloat("HP");
    HP = HP - rnd.Next(a, b + 1);
    PlayerPrefs.SetFloat("HP", HP);

    if (HP <= 0)
    {
      deadAudio.Play();
      deadPanel.gameObject.SetActive(true);
      Time.timeScale = 0f;
    }
  }
}