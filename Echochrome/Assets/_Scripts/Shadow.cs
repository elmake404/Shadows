using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField]
    private Transform _shodow;
    [SerializeField]
    private MeshFilter _mesh;
    private void Start()
    {
        //Vector3[] Vertex = _mesh.mesh.vertices;
        ////for (int i = 0; i < Vertex.Length; i++)
        ////{
        ////    Vertex[i].z = 0;
        ////}
        //_mesh.mesh.vertices = Vertex;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetRotaionShpdow(Vector3 Position)
    {
        _shodow.LookAt(Position);
    }
    public Vector3[] GetMeshVerticesGlobal()
    {
        Vector3[] vertices = _mesh.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.TransformPoint(vertices[i]);
        }
        return vertices;
    }
    public void SetMeshVertices(Vector3[] vertices)
    {
        _mesh.mesh.vertices = vertices;
    }
}
