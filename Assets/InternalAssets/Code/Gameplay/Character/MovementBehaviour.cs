using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementBehaviour : MonoBehaviour
{
    public event Action onCharacterJumped;
    public event Action onCharacterFall;

    public UnityEvent OnJump;
    public UnityEvent OnFall;

    private const int powerLossScale = 10;

    [SerializeField, HideInInspector] private Rigidbody2D rigidbody2D;
    [SerializeField] private Collider2D _groundCollider;

    private float _gravity = 10f;
    private float _gravityFixed => _gravity * Time.deltaTime;
    private Vector2 _gravityVector => _gravityFixed * Vector2.up;


    public bool canJump { get; private set; } = true;
    public bool isFlying { get; private set; } = false;
    public float remainPower { get; private set; }

    [Header("Configurable parameters")]
    [SerializeField] private int _jumpPowerScale;
    [SerializeField] private float _maxJumpPower = 1f;

    private void OnValidate()
    {
        rigidbody2D ??= GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        remainPower = _maxJumpPower;
    }

    private void Update()
    {
        
        if (Settings.GameIsPaused)
        {
            if (!rigidbody2D.IsSleeping()) rigidbody2D.Sleep();
            return;
        }
        else
        {
            if (rigidbody2D.IsSleeping()) { rigidbody2D.WakeUp(); }
        }

        if ((Input.GetMouseButton(0) && canJump) && remainPower > 0)
        {
            if (!isFlying) 
            { 
                onCharacterJumped?.Invoke();
                OnJump?.Invoke();
            }

            isFlying = true;
            rigidbody2D.AddForce(_gravityVector * _jumpPowerScale, ForceMode2D.Force);
            remainPower -= Time.deltaTime * powerLossScale;
        }
        else if (Input.GetMouseButtonUp(0) || remainPower < 0)
        {
            canJump = false;
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == _groundCollider)
        {
            onCharacterFall?.Invoke();
            OnFall?.Invoke();
            isFlying = false;
            canJump = true;
            remainPower = _maxJumpPower;
        }
    }

    public void DisableMovement()
    {
        this.enabled = false;
    }
    public void EnableMovement()
    {
        this.enabled = true;
    }
}
