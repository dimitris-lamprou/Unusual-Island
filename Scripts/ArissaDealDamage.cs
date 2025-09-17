using UnityEngine;
using UnityEngine.UI;

public class ArissaDealDamage : MonoBehaviour
{
    private float oldTime = 0f;
    public Scrollbar mutantHealthBar;
    public float damage = 0.02f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mutant"))
        {
            if (Time.fixedTime - oldTime > 0.5)
            {
                if (mutantHealthBar.size - damage < 0f)
                {
                    mutantHealthBar.size = 0;
                }
                else
                {
                    mutantHealthBar.size -= damage;
                }
                oldTime = Time.fixedTime;
            }
        }
    }
}
