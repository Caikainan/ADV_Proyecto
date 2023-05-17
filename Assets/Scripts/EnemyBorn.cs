using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    public GameObject enemy;
    public float bornTime;

    void creatEnemy()
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
    }

    void Start()
    {
        StartCoroutine(Waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Waiter()
    {
        for (int i = 0; i < 100; i++)
        {
            creatEnemy();
            yield return new WaitForSeconds(bornTime);
        }
    }
}
