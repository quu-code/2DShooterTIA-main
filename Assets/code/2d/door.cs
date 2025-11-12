using UnityEngine;

public class door : MonoBehaviour
{
    float timeSinceLastJump = 0;
    [SerializeField]
    float timeBetweenJumps = 0.5f;

    void Start()
    {
        //transform.position = new Vector3(2, 1, 1);
    }

    
    void Update()
    {
        timeSinceLastJump += Time.deltaTime;
        if (timeSinceLastJump > timeBetweenJumps)
        {
            //transform.position = new Vector3(2, 1, 1);
            timeSinceLastJump=0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "door" )
        {
            transform.position = new Vector3(2, 10, 1);
            print (timeSinceLastJump);
        }
    }

    public void Open() {
        
    }
}
