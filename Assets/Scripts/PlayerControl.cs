using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
  private Rigidbody2D _rb;
  public GameObject door, deadPanel, winPanel;
  public Image keyImage;
  private float speed = 6f, HP = 100f, h;
  private bool fasing = true, doorOpen = false, isMove = false;
  public AudioSource eatAudio, deadAudio;
  private Animator animator;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    HP = 100f;
    PlayerPrefs.SetFloat("HP", HP);
    deadPanel.gameObject.SetActive(false);
    winPanel.gameObject.SetActive(false);
    Time.timeScale = 1f;
  }
  private void Update()
  {
    animator.SetBool("IsMove", isMove);
    door.gameObject.SetActive(!doorOpen);

    if (doorOpen) keyImage.color = new Color(1, 1, 1, 1);
    else keyImage.color = new Color(1, 1, 1, 0.2f);

    if (Input.GetKeyDown(KeyCode.E) && HP > 10)
    {
      HP -= 10;
      speed += 2;
      PlayerPrefs.SetFloat("HP", HP);
    }
  }
  private void FixedUpdate()
  {
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
    transform.position += (Vector3)moveAmount;

    float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

    if ((h < 0 && fasing) || (h > 0 && !fasing)) Flip();

    isMove = (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f);
  }

  private void Flip()
  {
    fasing = !fasing;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "GreenFood") enemyAttaсk(15, 20);
    if (other.gameObject.tag == "RedFood" || other.gameObject.tag == "BlueFood") enemyAttaсk(15, 25);
    if (other.gameObject.tag == "key") doorOpen = true;

    if (other.gameObject.tag == "heart")
    {
      HP = PlayerPrefs.GetFloat("HP");
      if (HP < 90) HP = HP + 10;
      else HP = 100;
      PlayerPrefs.SetFloat("HP", HP);
    }

    if (other.gameObject.tag == "GreenFood" || other.gameObject.tag == "RedFood" || other.gameObject.tag == "BlueFood" || other.gameObject.tag == "key" || other.gameObject.tag == "heart") Destroy(other.gameObject);

    if (other.gameObject.name == "Teleport")
    {
      winPanel.gameObject.SetActive(true);
      Time.timeScale = 0f;
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
      Destroy(this.gameObject);
      Time.timeScale = 0f;
    }
  }
}