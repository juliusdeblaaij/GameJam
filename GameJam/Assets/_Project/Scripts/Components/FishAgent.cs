using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class FishAgent : MonoBehaviour
{
    [SerializeField] protected float speed = 1;

    protected Transform target;
    protected Transform planet;
    protected new Rigidbody2D rigidbody2D;

    protected void Awake()
    {
        GameObject tar = GameObject.FindGameObjectWithTag("Player");
        if (tar) target = tar.transform;

        GameObject plan = GameObject.FindGameObjectWithTag("Planet");
        if (plan) planet = plan.transform;

        /*
        target = GameObject.FindGameObjectWithTag("Player").transform;
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        */

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Move()
    {
        Vector2 movement = transform.up * speed * Time.deltaTime;

        rigidbody2D.position += movement;
    }
}
