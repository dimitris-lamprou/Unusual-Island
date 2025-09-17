using UnityEngine;
using UnityEngine.UI;

public class RegenerateHealth : MonoBehaviour
{
    public Scrollbar healthBar;
    public float healingSpeed = 0.03f;

    void Update()
    {
        if (healthBar.size < 1)
        {
            healthBar.size += healingSpeed * Time.deltaTime;
        }
    }
}
