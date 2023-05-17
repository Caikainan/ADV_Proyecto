using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActiveTrgger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject active;
    public GameObject EnemyBornPoint1;
    public GameObject EnemyBornPoint2;
    public GameObject EnemyBornPoint3;
    public AudioSource RayWaveShotAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Door")
        {
            active.SetActive(true);
            EnemyBornPoint1.SetActive(true);
            EnemyBornPoint2.SetActive(true);
            EnemyBornPoint3.SetActive(true);
            RayWaveShotAudio.Play(0);
        }
    }
}
