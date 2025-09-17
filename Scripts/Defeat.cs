using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.AI;

public class Defeat : MonoBehaviour
{
    public Scrollbar healthBar;
    public GameObject defeatCanvas;
    public RegenerateHealth regenerateHealthScript;
    public ThirdPersonController thirdPersonController;
    public StarterAssetsInputs starterAssetsInputs;
    public Animator animator;
    public Pause pauseScript;
    public Transform arissasTransform;
    public Attack attack;
    public GameObject arissasLightning;

    public Animator mutantAnimator;
    public NavMeshAgent mutantNavMeshAgent;


    void Update()
    {
        if (healthBar.size == 0f)
        {
            defeatCanvas.SetActive(true);
            regenerateHealthScript.enabled = false;
            thirdPersonController.enabled = false;
            animator.SetBool("Dead", true);
            Cursor.visible = true;
            starterAssetsInputs.cursorInputForLook = false;
            starterAssetsInputs.cursorLocked = false;
            pauseScript.enabled = false;
            attack.enabled = false;
            arissasLightning.SetActive(false);
            animator.SetBool("doesArissaAttack", false);
        }
    }
    public void Respawn()
    {
        arissasTransform.position = new Vector3(208.34f, 500.27f, 755.98f);
        healthBar.size = 1f;
        defeatCanvas.SetActive(false);
        regenerateHealthScript.enabled = true;
        thirdPersonController.enabled = true;
        animator.SetBool("Dead", false);
        Cursor.visible = false;
        starterAssetsInputs.cursorInputForLook = true;
        starterAssetsInputs.cursorLocked = true;
        pauseScript.enabled = true;
        attack.enabled = true;

        mutantAnimator.SetBool("isArissaDead", false);
        mutantAnimator.SetBool("isArissaClose", false);
        mutantNavMeshAgent.isStopped = false;
    }
}
