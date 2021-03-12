using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField]
    private Transform _shadow;
    [SerializeField]
    private MeshFilter _mesh;
    [SerializeField]
    private EdgeCollider2D _edgeCollider;
    [SerializeField]
    private PhysicsMaterial2D _bounceMaterial;


    [SerializeField]
    private bool _isBounce;

    private void Start()
    {
        if (_isBounce)
        {
            _edgeCollider.sharedMaterial = _bounceMaterial;
        }

    }
    private void FixedUpdate()
    {

    }
    public Vector3 InverseShodow(Vector3 position)
    {
       return  _shadow.InverseTransformPoint(position);
    }
    public Vector3[] GetMeshVerticesGlobal()    {
        
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
    public void SetPointCollider(Vector3[] point)
    {
        Vector2[] pointVector2 = new Vector2[point.Length];
        for (int i = 0; i < point.Length; i++)
        {
            pointVector2[i] = point[i];
        }
        _edgeCollider.points = pointVector2;
    }
}
