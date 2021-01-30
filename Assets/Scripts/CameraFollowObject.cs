using System;
using UnityEngine;

/// <summary>
/// This script allows the camera to follow the x-value of
/// an object's transform.
/// It respects the initial offset.
/// </summary>
public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] private Transform mTargetTransform;
    private float mOffset;
    private void Start()
    {
        mOffset = transform.position.x - mTargetTransform.position.x;
    }

    private void Update()
    {
        var position = transform.position;
        position.x = mTargetTransform.position.x + mOffset;
        transform.position = position;
    }
}