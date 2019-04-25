using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 currentPosition;

    public GameObject tongueObject;

    [SerializeField]bool isLicking;

    public float speed = 1.0F;
    public float moveSpeed = 1;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    Rigidbody2D tongueRb;

    private void Awake()
    {
        tongueRb = tongueObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
            Vector3 lerp = Vector3.Lerp(startPosition, targetPosition, fracJourney);
            tongueRb.MovePosition(new Vector2(lerp.x, lerp.y) * moveSpeed);

            tongueObject.GetComponent<LineRenderer>().SetPositions(new Vector3[2] { transform.position, tongueObject.transform.position });

        }

        if (tongueObject.transform.position == targetPosition)
        {
            //isLicking = false;
            targetPosition = transform.position;
            startPosition = tongueObject.transform.position;

            isLicking = true;

            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(startPosition, targetPosition);
        }
    }
}
