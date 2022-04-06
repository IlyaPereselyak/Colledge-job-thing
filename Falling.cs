using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Animation FallAnim;
    private void Start()
    {
        FallAnim = GetComponent<Animation>();
    }
    void AnimationPlaying()
    {
        FallAnim.Play("FalingPlatform");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AnimationPlaying();
        }
    }
}
