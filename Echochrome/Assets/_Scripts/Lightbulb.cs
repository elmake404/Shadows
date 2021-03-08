using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    private Vector3 _startMosePos, _currentMosePos, _lightbulbPos;
    [SerializeField]
    private float _speedMove,_limmitY ,_limmitX;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lightbulbPos = transform.position;
            _startMosePos = Input.mousePosition/10;
        }
        else if (Input.GetMouseButton(0))
        {
            _currentMosePos = Input.mousePosition/10;
            Vector3 pos = _lightbulbPos + (_currentMosePos - _startMosePos);
            transform.position = Vector3.Lerp(transform.position,pos,_speedMove*Time.deltaTime);
        }
    }
}
