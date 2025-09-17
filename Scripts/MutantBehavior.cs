using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class MutantBehavior : MonoBehaviour
{
    public NavMeshAgent mutantNavMeshAgent;
    public Transform arissasTransform;
    public Animator mutantAnimator;
    public Scrollbar healthBar;
    public Animator arissaAnimator;
    public RegenerateHealth regenerateHealthScript;
    public GameObject mutantHealthBarCanvas;
    public Scrollbar mutantHealthBarScrollBar;
    public MutantBehavior mutantBehaviorScript;
    public CapsuleCollider mutantCapsuleCollider;
    public CapsuleCollider mutantCapsuleColliderNonTrigger;
    public SphereCollider heatherSphereCollider;
    public TextMeshProUGUI objective;
    public GameObject actionMusic;
    public GameObject mainMusic;
    public GameObject mutantFootStepsSoundEffect;
    public GameObject mutantPunchSoundEffect;
    public GameObject mutantRoarSoundEffect;
    public AudioSource mutantRoar;
    public float dmg = 0.1f;
    public TextMeshProUGUI musicOnOff;
    private bool isArissaClose;

    void Update()
    {
        if (mutantHealthBarScrollBar.size == 0f)
        {
            mutantNavMeshAgent.isStopped = true;
            mutantAnimator.SetBool("isMutantDead", true);
            mutantNavMeshAgent.enabled = false;
            mutantCapsuleCollider.enabled = false;
            mutantCapsuleColliderNonTrigger.enabled = false;
            mutantHealthBarCanvas.SetActive(false);
            heatherSphereCollider.enabled = true;
            objective.text = "Objective\n   Collect the Heather of Eternity";
            actionMusic.SetActive(false);
            if (musicOnOff.text.Equals("Off"))
            {
                mainMusic.SetActive(true);
            }
            mutantFootStepsSoundEffect.SetActive(false);

            mutantBehaviorScript.enabled = false;
        }
        else
        {
            if (arissasTransform.position.x < 755 || arissasTransform.position.z < 840)
            {
                mutantAnimator.SetBool("isArissaOutOfSight", true);
                mutantNavMeshAgent.isStopped = true;
                mutantHealthBarCanvas.SetActive(false);
                actionMusic.SetActive(false);
                if (musicOnOff.text.Equals("Off"))
                {
                    mainMusic.SetActive(true);
                }
                mutantFootStepsSoundEffect.SetActive(false);
            }
            else
            {
                if (mutantHealthBarScrollBar.size == 0f)
                {
                    mutantHealthBarCanvas.SetActive(false);
                    actionMusic.SetActive(false);
                    if (musicOnOff.text.Equals("Off"))
                    {
                        mainMusic.SetActive(true);
                    }
                    mutantFootStepsSoundEffect.SetActive(false);
                }
                else
                {
                    objective.text = "Objective\n   Eliminate the Mutant";
                    mutantAnimator.SetBool("isArissaOutOfSight", false);
                    mutantNavMeshAgent.isStopped = false;
                    mutantHealthBarCanvas.SetActive(true);
                    if (musicOnOff.text.Equals("Off"))
                    {
                        actionMusic.SetActive(true);
                    }
                    mainMusic.SetActive(false);
                    if (!isArissaClose)
                    {
                        mutantFootStepsSoundEffect.SetActive(true);
                    }
                    else
                    {
                        mutantFootStepsSoundEffect.SetActive(false);
                    }
                }
            }
            if (!isArissaClose)
            {
                mutantNavMeshAgent.SetDestination(arissasTransform.position);
            }
            if (healthBar.size == 0)
            {
                mutantNavMeshAgent.isStopped = true;
                mutantFootStepsSoundEffect.SetActive(false);
                CallDeathOfArissa();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthBar.size == 0)
            {
                mutantFootStepsSoundEffect.SetActive(false);
                CallDeathOfArissa();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isArissaClose = true;
            mutantAnimator.SetBool("isArissaClose", true);
            mutantNavMeshAgent.isStopped = true;
            transform.LookAt(arissasTransform.position);
            mutantFootStepsSoundEffect.SetActive(false);

            if (healthBar.size == 0)
            {
                CallDeathOfArissa();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isArissaClose = false;
            mutantAnimator.SetBool("isArissaClose", false);
            mutantNavMeshAgent.isStopped = false;
            mutantFootStepsSoundEffect.SetActive(true);

            if (healthBar.size == 0)
            {
                CallDeathOfArissa();
                mutantFootStepsSoundEffect.SetActive(false);
            }
        }
    }
    public void DealDamage()
    {
        mutantPunchSoundEffect.SetActive(true);
        if (healthBar.size - dmg < 0f)
        {
            healthBar.size = 0f;
            CallDeathOfArissa();
        }
        else
        {
            healthBar.size -= dmg;
        }
        arissaAnimator.SetTrigger("gotHit");
        
        if (healthBar.size == 0)
        {
            CallDeathOfArissa();
        }
    }
    public void ResetPunchSoundEffect()
    {
        mutantPunchSoundEffect.SetActive(false);
    }
    public void Roar()
    {
        mutantRoarSoundEffect.SetActive(true);
    }
    public void ResetRoar()
    {
        mutantRoarSoundEffect.SetActive(false);
    }
    private void CallDeathOfArissa()
    {
        mutantNavMeshAgent.isStopped = true;
        regenerateHealthScript.enabled = false;
        isArissaClose = true;
        mutantAnimator.SetBool("isArissaDead", true);
        mutantAnimator.SetBool("isArissaClose", true);
    }
    public void OnPlayButton()
    {
        if (mutantHealthBarScrollBar.size == 0)
        {
            mutantBehaviorScript.enabled = false;
        }
        else
        {
            mutantBehaviorScript.enabled = true;
        }
    }
}
