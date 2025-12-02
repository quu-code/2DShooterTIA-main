using UnityEngine;

public class doorbutton : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    

    void Start()
    {
        //Instantiate(door, transform.position, Quaternion.identity);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        {
            door.GetComponent<door>().Open();
            //transform.position.door(2, -1);
        }
    }
}
