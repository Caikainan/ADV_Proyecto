using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayWaveDestroy : MonoBehaviour
{
    public GameObject explotion;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != null)
        {
            GameObject exp = Instantiate(explotion, this.transform.position, Quaternion.identity);
            Destroy(exp, 2.5f);
            Destroy(this.gameObject);
        }
    }
}
