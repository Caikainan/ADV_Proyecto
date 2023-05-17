using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject goal;
    private Animator animator;
    Vector3 direction;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = goal.transform.position - this.transform.position;
        this.transform.LookAt(goal.transform.position);
        if (direction.magnitude > 10)
        {
            animator.Play("Run");
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}
