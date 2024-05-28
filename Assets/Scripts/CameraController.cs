using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velociry = Vector3.zero;

    [Range(0,1)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Camera Limits")]
    public Vector2 xLitmit;
    public Vector2 yLitmit;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position+positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLitmit.x, xLitmit.y), Mathf.Clamp(targetPosition.y, yLitmit.x, yLitmit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velociry, smoothTime);
    }
}
