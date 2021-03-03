using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField]
    private Transform _shodow;
    // Update is called once per frame
    void Update()
    {

    }
    public void SetRotaionShpdow(Vector3 Position)
    {
        _shodow.LookAt(Position);
    }
}
