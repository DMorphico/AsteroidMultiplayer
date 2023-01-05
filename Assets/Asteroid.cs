using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int vida;
    public int pontos;
    public float force;
    public float forceVariance;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(-1 * transform.up * Random.Range(force - forceVariance, force + forceVariance));
        this.transform.Rotate(0f, 0f, Random.Range(0, 360), Space.World);
    }
}
