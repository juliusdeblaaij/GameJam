using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 currentPosition;

    public GameObject tongueObject;

    bool isLicking;

    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            targetPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
            startPosition = transform.position;

            isLicking = true;

            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(startPosition, targetPosition);
        }

        if (isLicking)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            tongueObject.transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney);
        }

        if(tongueObject.transform.position == targetPosition)
        {
            isLicking = false;
        }
    }
}
