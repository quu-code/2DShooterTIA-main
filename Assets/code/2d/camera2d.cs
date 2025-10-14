using UnityEngine;

public class camera2d : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x;

        transform.position = pos;
    }
}
