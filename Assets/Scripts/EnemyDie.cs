using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ray" || col.gameObject.tag == "Player")
        {
            animator.Play("Die");
            StartCoroutine(Waiter());
        }
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
