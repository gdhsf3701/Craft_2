using System.Collections;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform _groundCheckerTrm;

    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 7f;
    public float extraGravity = 30f;
    public float gravityDelay = 0.15f;
    public float knockbackTime = 0.2f;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _groundCheckerSize;

    public NotifyValue<bool> isGround = new NotifyValue<bool>();
    public Rigidbody2D rbCompo { get; private set; }
    public float _xMove;
    private float _timeInAir;
    
    protected bool _canMove = true;
    protected Coroutine _kbCoroutine;


    private Agent _owner;
    public void Initialize(Agent agent)
    {
        _owner = agent;
        rbCompo = GetComponent<Rigidbody2D>();
    }

    public void JumpTo(Vector2 force)
    {
        SetMoveMent(force.x);
        rbCompo.AddForce(force, ForceMode2D.Impulse);
    }
    public void SetMoveMent(float xMove)
    {
        _xMove = xMove;
    }

    public void StopImmediately(bool isYStop = false)
    {
        _xMove = 0;
        if (isYStop)
        {
            rbCompo.velocity = Vector2.zero;
        }
        else
        {
            rbCompo.velocity = new Vector2(_xMove, rbCompo.velocity.y);
        }
    }

    public void Jump(float multiplier = 1f)
    {
        _timeInAir = 0;
        rbCompo.velocity = Vector2.zero;
        rbCompo.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (!isGround.Value)
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir = 0;
        }
    }
    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyXMovement();
        ApllyExtraGravity();
    }
    public void CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckerTrm.position, _groundCheckerSize, 0, _whatIsGround);
        isGround.Value = collider != null;
    }
    private void ApplyXMovement()
    {
        if (!_canMove) return;
        rbCompo.velocity = new Vector2(_xMove * moveSpeed, rbCompo.velocity.y);
    }

    private void ApllyExtraGravity()
    {
        if (_timeInAir > gravityDelay)
        {
            rbCompo.AddForce(new Vector2(0, -extraGravity));
        }
    }
    
    #region Knockback regeion
    public void GetKnockback(Vector3 direction, float power)
    {
        Vector3 difference = direction * power * rbCompo.mass;
        rbCompo.AddForce(difference, ForceMode2D.Impulse);

        if(_kbCoroutine != null)
            StopCoroutine(_kbCoroutine);

        _kbCoroutine = StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        _canMove = false;
        yield return new WaitForSeconds(knockbackTime);
        rbCompo.velocity = Vector2.zero;
        _canMove = true;
    }

    public void ClearKnockback()
    {
        rbCompo.velocity = Vector2.zero;
        _canMove = true;
    }
    #endregion


}
