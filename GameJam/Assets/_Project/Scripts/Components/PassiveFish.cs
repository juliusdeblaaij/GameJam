using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveFish : FishAgent
{
    private void Start()
    {
        Turn();
    }

    private void Update()
    {
        Move();
        Turn();
    }

    private void Turn()
    {
        Vector2 dir = planet.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
