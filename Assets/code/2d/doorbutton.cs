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
            
            transform.position = new Vector3(2, 1, 1);
            transform.position = new Vector3(7, 0, 1);
            print (door);
            door.GetComponent<door>().Open();
        }
    }
}
