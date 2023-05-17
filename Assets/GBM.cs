using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBM : MonoBehaviour
{
    [SerializeField] AudioSource RayWaveShotAudio;
    // Start is called before the first frame update
    void Start()
    {
        RayWaveShotAudio.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
