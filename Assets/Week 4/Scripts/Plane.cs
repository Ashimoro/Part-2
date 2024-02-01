using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPositionThreshhold = 0.2f;
    public float speed = 1;
    Vector2 lastPosition;
    Vector2 currentPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigibody;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigibody = GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigibody.rotation = -angle;
        }
        rigibody.MovePosition(rigibody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPositionThreshhold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }
    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPositionThreshhold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition) ;
            lastPosition = newPosition;

        }

    }
}
