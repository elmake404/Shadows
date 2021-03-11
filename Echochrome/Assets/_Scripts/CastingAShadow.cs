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
    private Shadow _shadow, _shadowCorridor;

    private float _leg 
    { get { return _lightbulb.Wall.position.z - _lightbulb.transform.position.z - _lightbulb.Wall.localScale.z/1.9f; } }

    void Start()
    {
        if (_lightbulb == null)
            _lightbulb = FindObjectOfType<Lightbulb>();

        Shading();
        //ShadowCorridor();
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

            if (_lightbulb.IsRays)
                Debug.DrawRay(_lightbulb.transform.position, direction * 10, Color.yellow);

            newVertices[i] = _lightbulb.transform.position + ((direction) *
                            ((_leg) / direction.z));
            newVertices[i] = _shadow.InverseShodow(newVertices[i]);
        }
        _shadow.SetMeshVertices(newVertices);
        _shadow.SetPointCollider(newVertices);
    }
    //private void ShadowCorridor()
    //{
    //    Vector3[] vertices = GetMeshVerticesGlobal();
    //    Vector3[] newVertices = new Vector3[vertices.Length];

    //    List<Vector3> shadowCorridorVertices = new List<Vector3>();

    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        shadowCorridorVertices.Add(_shadowCorridor.InverseShodow(vertices[i]));

    //        Vector3 direction = (vertices[i] - _lightbulb.transform.position);

    //        newVertices[i] = _lightbulb.transform.position + ((direction) *
    //                        ((_leg) / direction.z));
    //        if ()
    //        {

    //        }
    //        shadowCorridorVertices.Add(_shadowCorridor.InverseShodow(newVertices[i]));
    //    }
    //    _shadowCorridor.SetMeshVertices(shadowCorridorVertices.ToArray());

    //}
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
