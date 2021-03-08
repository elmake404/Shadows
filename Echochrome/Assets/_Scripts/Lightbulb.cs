using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    private Vector3 _startMosePos, _currentMosePos, _startLightbulbPos, _currentLightbulbPos;
    [SerializeField]
    private float _speedMove, _decreaseInSensitivity, _limitY, _limitX;

    public bool IsRays;


    private void Start()
    {
        _startLightbulbPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentLightbulbPos = transform.position;
            _startMosePos = Input.mousePosition / _decreaseInSensitivity;
        }
        else if (Input.GetMouseButton(0))
        {
            _currentMosePos = Input.mousePosition / _decreaseInSensitivity;
            Vector3 pos = LimitCheck(_currentLightbulbPos + (_currentMosePos - _startMosePos));

            transform.position = Vector3.Lerp(transform.position, pos, _speedMove * Time.deltaTime);
        }
    }

    private Vector3 LimitCheck(Vector3 posLightbulb)
    {
        if (posLightbulb.x > _startLightbulbPos.x + _limitX) posLightbulb.x = _startLightbulbPos.x + _limitX;

        else if (posLightbulb.x < _startLightbulbPos.x - _limitX) posLightbulb.x = _startLightbulbPos.x - _limitX;


        if (posLightbulb.y > _startLightbulbPos.y + _limitY) posLightbulb.y = _startLightbulbPos.y + _limitY;

        else if (posLightbulb.y < _startLightbulbPos.y - _limitY) posLightbulb.y = _startLightbulbPos.y - _limitY;


        return posLightbulb;
    }
}
