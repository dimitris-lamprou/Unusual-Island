using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject lightning;
    public Animator arissaAnimator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lightning.SetActive(true);
            arissaAnimator.SetBool("doesArissaAttack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lightning.SetActive(false);
            arissaAnimator.SetBool("doesArissaAttack", false);
        }
    }
}
