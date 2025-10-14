using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField]
  float speed;

  [SerializeField]
  GameObject boomPrefab;

  void Start()
  {
    Vector2 newPos = new();
    newPos.x = Random.Range(-7f, 7f);
    newPos.y = Camera.main.orthographicSize + 1;

    transform.position = newPos;
  }

  void Update()
  {
    Vector2 movement = Vector2.down * speed;
    transform.Translate(movement * Time.deltaTime);

    if (transform.position.y < -Camera.main.orthographicSize - 1)
    {
      Destroy(this.gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    Instantiate(boomPrefab, transform.position, Quaternion.identity);
    Destroy(this.gameObject);
  }
}
