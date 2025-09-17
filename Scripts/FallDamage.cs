using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class FallDamage : MonoBehaviour
{
    private bool previousGrounded;
    private bool grounded;
    public ThirdPersonController thirdPersonController;
    public CharacterController characterController;
    private float velocity;
    private float damage;
    public Scrollbar healthbar;

    void Update()
    {
        previousGrounded = grounded;
        grounded = thirdPersonController.Grounded;
        velocity = characterController.velocity.y;
        
        if (-velocity >= 34)
        {
            damage = 1f;
        }
        else if (-velocity >= 30)
        {
            damage = 0.775f;
        }
        else if (-velocity >= 25)
        {
            damage = 0.55f;
        }
        else if (-velocity >= 20)
        {
            damage = 0.325f;
        }
        else if (-velocity >= 15)
        {
            damage = 0.1f;
        }

        if (!previousGrounded && grounded)
        {
            if (healthbar.size - damage < 0f)
            {
                healthbar.size = 0f;
                damage = 0f;
            }
            else
            {
                healthbar.size -= damage;
                damage = 0f;
            }
        }
    }
}
