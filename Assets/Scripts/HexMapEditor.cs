using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputHandler))]
public class HexMapEditor : MonoBehaviour
{
    private InputHandler _inputHandler;
    [SerializeField] private HexGrid hexGrid;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color[] colors;

    private Color _activeColor;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
    }

    void Start()
    {
        _inputHandler.OnMousePress += HandleMousePress;
    }

    private void HandleMousePress(InputTypes obj)
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        var inputRay = mainCamera.ScreenPointToRay(_inputHandler.GetMousePosition());
        if (Physics.Raycast(inputRay, out var hit))
        {
            hexGrid.ColorCell(hit.point, _activeColor);
        }
    }

    public void SelectColor (int index) {
        _activeColor = colors[index];
    }
}