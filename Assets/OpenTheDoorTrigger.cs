using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoorTrigger : MonoBehaviour
{
    public GameObject door;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        if (c.tag == "Door"){
            door.SetActive(true);
            door.transform.position += Vector3.up * speed * Time.deltaTime * 100;
        }
    }
}
