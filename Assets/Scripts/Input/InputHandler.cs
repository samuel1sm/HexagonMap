using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputTypes
{
    Started, Canceled, Performed
}
public class InputHandler : MonoBehaviour
{

    private PlayerInput _playerInput;
    
    public event Action<InputTypes> OnMousePress = delegate(InputTypes types) {  };

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    void Start()
    {
        _playerInput.Terrain.MouseDown.started += _ => OnMousePress(InputTypes.Started);
    }

    public Vector2 GetMousePosition()
    {
        return _playerInput.Terrain.MousePosition.ReadValue<Vector2>();
    }
}
