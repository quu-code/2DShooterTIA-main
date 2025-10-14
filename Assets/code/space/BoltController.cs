using UnityEngine;

public class BoltController : MonoBehaviour
{
  [SerializeField]
  float boltSpeed = 4;

  void Start()
  {
    // Destroy(this.gameObject, 3);
  }

  void Update()
  {
    Vector2 movement = Vector2.up * boltSpeed;
    transform.Translate(movement * Time.deltaTime);

    if (transform.position.y > Camera.main.orthographicSize + 1)
    {
      Destroy(this.gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "enemy")
    {
      Destroy(this.gameObject);
    }
  }
}
