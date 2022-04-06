using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrapsActivator : MonoBehaviour
{
    public float speed = 0f;
    void Update()
    {

        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }
}
