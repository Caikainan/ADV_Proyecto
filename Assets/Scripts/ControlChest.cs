using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChest : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            bool state = animator.GetBool("Open");
            animator.SetBool("Open",!state);
        }
    }
}
