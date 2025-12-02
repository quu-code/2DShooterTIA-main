using UnityEngine;

public class door : MonoBehaviour
{

    int dooropen = 0;

    float timeSinceLastJump = 0;
    
    float timeBetweenJumps = 10;

    void Start()
    {
        transform.position = new Vector3(2, 1, 1);
    }

    
    void Update()
    {
         if (dooropen == 1)
        {
            timeSinceLastJump += Time.deltaTime;
            
        }
        if (timeSinceLastJump > timeBetweenJumps)
        {
            timeSinceLastJump= 0;
            dooropen = 0;
            print (timeSinceLastJump);
        }
        if (dooropen == 0)
        {
            transform.position = new Vector3(2, 1, 1);
            
        }
        
            if (dooropen == 1)
        {
            transform.position = new Vector3(2, -1, 1);
            
        }
    }
    
    public void Open() {
        dooropen = 1;
        
    }
}
