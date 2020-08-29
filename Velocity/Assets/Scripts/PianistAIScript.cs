using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianistAIScript : MonoBehaviour
{
    [SerializeField] Transform FollowTransform;
    SpriteRenderer spriteRenderer;
    PlayerMoveController controller;
    Animator animator;
    Animator PlayerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = FollowTransform.gameObject.GetComponent<PlayerMoveController>();
        animator = GetComponent<Animator>();
        PlayerAnimator = FollowTransform.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isPlayed)
        {
            if (FollowTransform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            if (FollowTransform.gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                transform.position = new Vector3(FollowTransform.position.x + 0.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(FollowTransform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (FollowTransform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            if (FollowTransform.gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                transform.position = new Vector3(FollowTransform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(FollowTransform.position.x + 0.5f, transform.position.y, transform.position.z);
            }
        }
        animator.SetBool("isWalking", PlayerAnimator.GetBool("isWalking"));
    }
}
