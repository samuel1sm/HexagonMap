using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;

public class HexGrid : MonoBehaviour
{
    [SerializeField] private int width = 6;
    [SerializeField] private int height = 6;
    [SerializeField] private HexCell cellPrefab;
    [SerializeField] private TextMeshProUGUI cellLabelPrefab;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color touchedColor = Color.magenta;
    private Canvas _gridCanvas;

    private HexCell[] _cells;
    private HexMesh _hexMesh;

    private void Awake()
    {
        _gridCanvas = GetComponentInChildren<Canvas>();
        _hexMesh = GetComponentInChildren<HexMesh>();

        _cells = new HexCell[width * height];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    private void Start()
    {
        _hexMesh.TriangulateCells(_cells);
    }


    public void ColorCell(Vector3 position, Color color)
    {
        position = transform.InverseTransformPoint(position);
        var coordinates = HexCoordinates.FromPosition(position);
        var index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        var cell = _cells[index];
        cell.color = color;
        _hexMesh.TriangulateCells(_cells);
    }

    private void CreateCell(int x, int z, int i)
    {
        var xPosition = (x + z * 0.5f - z / 2) * HexMetrics.innerRadius * 2f;
        var yPosition = z * HexMetrics.outerRadius * 1.5f;

        var position = new Vector3(xPosition, 0, yPosition);
        var cell = _cells[i] = Instantiate(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        cell.color = defaultColor;

        if (x > 0)
        {
            cell.SetNeighbor(HexDirection.W, _cells[i - 1]);
        }

        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                cell.SetNeighbor(HexDirection.SE, _cells[i - width]);
                if (x > 0)
                {
                    cell.SetNeighbor(HexDirection.SW, _cells[i - width - 1]);
                }
            }else 
            {
                cell.SetNeighbor(HexDirection.SW, _cells[i - width]);
                if (x < width - 1) {
                    cell.SetNeighbor(HexDirection.SE, _cells[i - width + 1]);
                }
            }
        }

        var label = Instantiate(cellLabelPrefab, _gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }

    // Update is called once per frame
    void Update()
    {
    }
}