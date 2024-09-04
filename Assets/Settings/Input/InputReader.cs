using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;


[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 Movement { get; private set; }

    public Controls _controls;

    public event Action OnAttackKeyEvent;
    public event Action OnKickKeyEvent;
    public event Action OnJumpKeyEvent;
    public event Action OnKnifeKeyEvent;

    public event Action OnRunKeyHoldEvent;
    public event Action OnRunKeyReleasedEvent;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
        
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) OnJumpKeyEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttackKeyEvent?.Invoke();
        }
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (context.performed) OnKickKeyEvent?.Invoke();
    }

    public void OnKnife(InputAction.CallbackContext context)
    {
        if (context.performed) OnKnifeKeyEvent?.Invoke();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.performed) OnRunKeyHoldEvent?.Invoke();
        if(context.canceled) OnRunKeyReleasedEvent?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }
}
