using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Lightbulb _lightbulb;
    private Vector3 _startPosCamera;

    [SerializeField]
    private float _travelMultiplier;
    void Start()
    {
        _startPosCamera = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _startPosCamera - _lightbulb.GetPositionDifference() * _travelMultiplier;
    }
}
