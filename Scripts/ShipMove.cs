using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public float speed = 4f;
 
    void Update()
    {
        transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x >= 1080)
        {
            transform.position = new Vector3(-110f, 478.31f, -58.9f);
        }
    }
}
