using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;


[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, ILeftPlayerActions, IRightPlayerActions
{
    public Vector2 Movement { get; private set; }

    public Controls _controls;

    public event Action OnAttackKeyEvent;
    public event Action OnKickKeyEvent;
    public event Action OnJumpKeyEvent;
    public event Action OnSkillEvent;


    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.LeftPlayer.SetCallbacks(this);
        _controls.LeftPlayer.Enable();
        
        _controls.RightPlayer.SetCallbacks(this);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) OnJumpKeyEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) OnAttackKeyEvent?.Invoke();
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (context.performed) OnKickKeyEvent?.Invoke();
    }

    public void OnKnife(InputAction.CallbackContext context)
    {
        if (context.performed) OnSkillEvent?.Invoke();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }
}
