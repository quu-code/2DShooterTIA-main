using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float speed = 0.02f;

  [SerializeField]
  GameObject boltPrefab;

  float timeSinceLastShot = 0;
  [SerializeField]
  float timeBetweenShots = 0.5f;

  float currentHP = 0;
  [SerializeField]
  float maxHP = 3;

  [SerializeField]
  Slider hpSlider;

  void Start()
  {
    currentHP = maxHP;
    hpSlider.maxValue = maxHP;
    hpSlider.value = currentHP;
  }

  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    Vector2 movement = Vector2.right * inputX
                     + Vector2.up * inputY;

    transform.Translate(movement * speed * Time.deltaTime);

    // =========================================================================
    // Skjuta
    // -------------------------------------------------------------------------

    timeSinceLastShot += Time.deltaTime;

    if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
    {
      AudioSource speaker = GetComponent<AudioSource>();

      speaker.Play();

      // GetComponent<AudioSource>().Play();

      Instantiate(boltPrefab, transform.position, Quaternion.identity);
      timeSinceLastShot = 0;
    }
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "enemy")
    {
      currentHP--;
      print("ouch " + currentHP);
      hpSlider.value = currentHP;
    }

    if(currentHP <= 0)
    {
    print("game over");
    SceneManager.LoadScene("game over");
    }
  }
}