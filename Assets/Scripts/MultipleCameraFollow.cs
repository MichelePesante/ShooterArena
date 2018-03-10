using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Camera))]
public class MultipleCameraFollow : MonoBehaviour {

    public List<PlayerInput> targets;


    public Vector3 offset;
    public float smoothTime = 0.5f;
    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;


    private Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
        targets = FindObjectsOfType<PlayerInput>().ToList();
    }


    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }


    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].gameObject.transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].gameObject.transform.position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].gameObject.transform.position;
        }

        var bounds = new Bounds(targets[0].gameObject.transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].gameObject.transform.position);
        }

        return bounds.center;
    }
}
