using UnityEngine;

public class playercontroler2d : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    GameObject gCheck;

    [SerializeField]
    GameObject bCheck;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    LayerMask buttonLayer;

    [SerializeField]
    float speed = 0.02f;

    float timeSinceLastJump = 0;
    [SerializeField]
    float timeBetweenJumps = 0.5f;
    
    
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
        bool isgravpress = Physics2D.OverlapCircle(
            bCheck.transform.position,
            .3f,
            buttonLayer
        );

        if (isgravpress == true)
        {
            print (timeSinceLastJump);
        }
    }
}
