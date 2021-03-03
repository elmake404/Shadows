using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingAShadow : MonoBehaviour
{
    [SerializeField]
    private Transform _lightbulb;
    [SerializeField]
    private Shadow _shadow;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Ray ray = new Ray(_lightbulb.position, transform.position) ;

        Vector3 direction = (transform.position - _lightbulb.position);

        _shadow.transform.position = _lightbulb.position + ((direction) *
                        ((5.68f) / direction.z));
        _shadow.SetRotaionShpdow(_lightbulb.position);
    }
}
