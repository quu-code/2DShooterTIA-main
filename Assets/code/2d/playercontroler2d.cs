using UnityEngine;
using UnityEngine.SceneManagement;
public class playercontroler2d : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    GameObject gCheck;

    [SerializeField]
    GameObject bCheck;

    float currentHP = 0;
    [SerializeField]
    float maxHP = 1;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    LayerMask buttonLayer;

    [SerializeField]
    float speed = 0.02f;

    float timeSinceLastJump = 0;
    [SerializeField]
    float timeBetweenJumps = 0.5f;
    void Start()
    {
    currentHP = maxHP;
    }
    
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        Vector2 movement = Vector2.right * inputX;
        transform.Translate(movement * speed * Time.deltaTime);



        bool isGrounded = Physics2D.OverlapCircle(
            gCheck.transform.position,
            .5f,
            groundLayer
        );

        timeSinceLastJump += Time.deltaTime;

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true && timeSinceLastJump > timeBetweenJumps)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            timeSinceLastJump = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "flip")
        {
        transform.Rotate(90, 0, 0);
        transform.Rotate(new Vector3(90, 0, 0));
        jumpForce *= -1;
        GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    if (collision.gameObject.tag == "kill")
    {   
      currentHP--;
      print("ouch " + currentHP);
    }

    if(currentHP <= 0)
    {
    print("game over");
    SceneManager.LoadScene("2d game over");
    }
    }
  
}
