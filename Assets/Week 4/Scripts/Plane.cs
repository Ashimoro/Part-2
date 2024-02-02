using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPositionThreshhold = 0.2f;
    public float speed;
    public AnimationCurve landing;
    public float landingTimer;
    Vector2 lastPosition;
    Vector2 currentPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigibody;

    private void Start()
    {
        transform.position = new Vector3 (Random.Range(-5f,5f), Random.Range(-5f,5f), 0);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        speed = Random.Range(1f, 3f);

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

        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
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
