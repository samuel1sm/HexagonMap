using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    private Mesh _hexMesh;
    private List<Vector3> vertices;
    private List<int> triangles;
    private MeshCollider meshCollider;
    List<Color> colors;
    

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
        meshCollider = gameObject.AddComponent<MeshCollider>();

        _hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
        colors = new List<Color>();
    }

    public void TriangulateCells(HexCell[] cells)
    {
        _hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        colors.Clear();

        foreach (var t in cells)
        {
            Triangulate(t);
        }

        _hexMesh.vertices = vertices.ToArray();
        _hexMesh.triangles = triangles.ToArray();
        _hexMesh.RecalculateNormals();
        meshCollider.sharedMesh = _hexMesh;
        _hexMesh.colors = colors.ToArray();
    }

    private void Triangulate(HexCell cell)
    {
        for (var d = HexDirection.NE; d <= HexDirection.NW; d++)
        {
            CreateMeshes(d, cell);
        }
    }

    private void CreateMeshes(HexDirection direction, HexCell cell)
    {
        var center = cell.transform.localPosition;
        Vector3 v1 = center + HexMetrics.GetFirstSolidCorner(direction);
        Vector3 v2 = center + HexMetrics.GetSecondSolidCorner(direction);

        AddTriangle(center, v1, v2);
        AddTriangleColor(cell.color);
        
        Vector3 bridge = HexMetrics.GetBridge(direction);
        Vector3 v3 = v1 + bridge;
        Vector3 v4 = v2 + bridge;

        AddQuad(v1, v2, v3, v4);
        var prevNeighbor = cell.GetNeighbor(direction.Previous()) ?? cell;
        var neighbor = cell.GetNeighbor(direction) ?? cell;
        var nextNeighbor = cell.GetNeighbor(direction.Next()) ?? cell;
		
        var bridgeColor = (cell.color + neighbor.color) * 0.5f;
        AddQuadColor(cell.color, bridgeColor);

        AddTriangle(v1, center + HexMetrics.GetFirstCorner(direction), v3);
        AddTriangleColor(
            cell.color,
            (cell.color + prevNeighbor.color + neighbor.color) / 3f,
            bridgeColor
        );
        
        AddTriangle(v2,v4, center + HexMetrics.GetSecondCorner(direction));
        AddTriangleColor(
            cell.color,
            bridgeColor,
            (cell.color + neighbor.color + nextNeighbor.color) / 3f
        );
    }
    
    void AddQuad (Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4) {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        vertices.Add(v4);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 3);
    }

    private void AddQuadColor (Color c1, Color c2, Color c3, Color c4) {
        colors.Add(c1);
        colors.Add(c2);
        colors.Add(c3);
        colors.Add(c4);
    }

    private void AddQuadColor (Color c1, Color c2) {
        colors.Add(c1);
        colors.Add(c1);
        colors.Add(c2);
        colors.Add(c2);
    }

    void AddTriangleColor(Color c1)
    {
        colors.Add(c1);
        colors.Add(c1);
        colors.Add(c1);
    }

    
    void AddTriangleColor(Color c1, Color c2, Color c3)
    {
        colors.Add(c1);
        colors.Add(c2);
        colors.Add(c3);
    }

    private void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        var vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }
    

}