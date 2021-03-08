using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingAShadow : MonoBehaviour
{
    [SerializeField]
    private Lightbulb _lightbulb;
    [SerializeField]
    private MeshFilter _mesh;
    [SerializeField]
    private Shadow _shadow;

    private float _leg 
    { get { return _shadow.transform.position.z - _lightbulb.transform.position.z;} }

    void Start()
    {
        Shading();
        if (_lightbulb == null)
            _lightbulb = FindObjectOfType<Lightbulb>();

    }

    void FixedUpdate()
    {
        Shading();
    }
    private void Shading()
    {
        Vector3[] vertices = GetMeshVerticesGlobal();
        Vector3[] newVertices = new Vector3[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 direction = (vertices[i] - _lightbulb.transform.position);
            if(_lightbulb.IsRays)
            Debug.DrawRay(_lightbulb.transform.position, direction*10,Color.yellow);

            newVertices[i] = _lightbulb.transform.position + ((direction) *
                            ((_leg) / direction.z));
            newVertices[i] = _shadow.InverseShodow(newVertices[i]);
        }
        _shadow.SetMeshVertices(newVertices);
        _shadow.SetPointCollider(newVertices);
    }
    private Vector3[] GetMeshVerticesGlobal()
    {
        Vector3[] vertices = _mesh.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.TransformPoint(vertices[i]);
        }
        return vertices;
    }

}
