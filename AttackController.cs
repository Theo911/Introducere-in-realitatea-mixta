using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AttackController : MonoBehaviour
{
    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public float maxDistance = 0.15f;

    private bool attackTriggerActivated = false;

    private void Update()
    {
        float distance = Vector3.Distance(imageTarget1.transform.position, imageTarget2.transform.position);
        var imageTarget1Animator = imageTarget1.GetComponentInChildren<Animator>();
        var imageTarget2Animator = imageTarget2.GetComponentInChildren<Animator>();

        if (!attackTriggerActivated && distance < maxDistance)
        {
            if (imageTarget1Animator != null && imageTarget2Animator != null)
            {
                imageTarget1Animator.SetTrigger("StopAttackTrigger");
                imageTarget2Animator.SetTrigger("StopAttackTrigger");
                imageTarget1Animator.SetTrigger("AttackTrigger");
                imageTarget2Animator.SetTrigger("AttackTrigger");
                attackTriggerActivated = true;
            }
        }
        else if (attackTriggerActivated && distance >= maxDistance)
        {
            if (imageTarget1Animator != null && imageTarget2Animator != null)
            {
                imageTarget1Animator.SetTrigger("StopAttackTrigger");
                imageTarget2Animator.SetTrigger("StopAttackTrigger");
                attackTriggerActivated = false;
            }
        }
    }
}