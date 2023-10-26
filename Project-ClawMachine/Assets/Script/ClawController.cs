using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public Transform clawTransform; 
    public Transform itemdrop; 

    public float moveSpeed = 5.0f;
    public float downPosition = 0.0f; 
    public float dropPosition = 2.0f; 
    public float upPosition = 5.0f;   

    private Animator clawAnimator;

    private void Start()
    {
        clawAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ClawMovement.instance.isMoving)
        {
            StartCoroutine(MoveClaw());
        }
    }

    private IEnumerator MoveClaw()
    {
        ClawMovement.instance.isMoving = false;

        while (transform.position.y > downPosition)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            yield return null;
        }

        clawAnimator.SetTrigger("CloseClaw");

        while (transform.position.y < dropPosition)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            yield return null;
        }

        while (transform.position.y < upPosition)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(clawTransform.position, itemdrop.position) > 0.01f)
        {
            clawTransform.position = Vector3.MoveTowards(clawTransform.position, itemdrop.position, 0.25f * Time.deltaTime);
            yield return null;
        }

        clawAnimator.SetTrigger("OpenClaw");

        ClawMovement.instance.isMoving = true;
    }
}
