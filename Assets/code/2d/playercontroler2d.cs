using UnityEngine;

public class playercontroler2d : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    GameObject gCheck;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float speed = 0.02f;

    float timeSinceLastShot = 0;
    [SerializeField]
    float timeBetweenShots = 0.5f;
    
    
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        Vector2 movement = Vector2.right * inputX;
        transform.Translate(movement * speed * Time.deltaTime);



        bool isGrounded = Physics2D.OverlapCircle(
            gCheck.transform.position,
            .1f,
            groundLayer
        );

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true && timeSinceLastShot > timeBetweenShots)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            timeSinceLastShot = 0;
        }
        print(timeSinceLastShot);
    }
}
