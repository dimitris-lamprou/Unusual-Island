using UnityEngine;

public class NPCRoute : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) 
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
