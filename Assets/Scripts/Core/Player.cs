using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Core {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 27/12/2021
     * @last_update 27/12/2021
     * @description classe responsável por controlar o player
     * 
     */

    public class Player : MonoBehaviour {

        [Header("Components")]
        private PlayerInput _input;
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private Animator _animator;

        [Header("Movement")]
        [SerializeField]
        private float _speed = 2f;
        [SerializeField]
        private bool _isFaceToRight = true;
        private Vector2 _velocity;

        [Header("Ground")]
        [SerializeField]
        private Transform _groundDetector;
        [SerializeField]
        private LayerMask _groundLayerMask;
        private bool _onGround;

        [Header("Jump")]
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private bool _enabledDoubleJump = true;
        private bool _canDoubleJump = false;
        private bool _onDoubleJump = false;

        [Header("Attack")]
        [SerializeField]
        private Transform _attackPoint;
        [SerializeField]
        private float _attackRadius;
        [SerializeField]
        private LayerMask _attackLayerMask;

        private void OnEnable() {
            _input.Enable();
        }

        private void OnDisable() {
            _input.Disable();
        }

        private void Awake() {
            _input = new PlayerInput();
            _input.Gameplay.Movement.performed += ctx => Movement(ctx.ReadValue<float>());
            _input.Gameplay.Movement.canceled += ctx => MovementCancelled();
            _input.Gameplay.Jump.performed += ctx => Jump();
            _input.Gameplay.Attack.performed += ctx => Attack();
        }

        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update() {
            OnGround();
            UpdateAnimations();
        }

        private void FixedUpdate() {
            _rigidbody.velocity = new Vector2(_velocity.x, _rigidbody.velocity.y);
        }

        private void OnGround() {
            _onGround = Physics2D.Linecast(transform.position, _groundDetector.position, _groundLayerMask);
            if (_onGround) {
                _onDoubleJump = false;
            }
        }

        private void UpdateAnimations() {
            _animator.SetBool("onGround", _onGround);
            _animator.SetBool("run", _rigidbody.velocity.x != 0f && _onGround);
            _animator.SetFloat("velocityY", _rigidbody.velocity.y);
            _animator.SetBool("onDoubleJump", _onDoubleJump);
        }

        private void FlipX(float direction) {
            if((direction < 0f && _isFaceToRight) || (direction > 0f && !_isFaceToRight)) {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                _isFaceToRight = !_isFaceToRight;
            }
        }

        private void Movement(float direction) {
            FlipX(direction);
            _velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
        }

        private void MovementCancelled() {
            _velocity = new Vector2(0f, _rigidbody.velocity.y);
        }

        private void Jump() {
            if(_canDoubleJump && !_onGround) {
                _onDoubleJump = true;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _canDoubleJump = false;
            }
            if(_onGround) {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                if(_enabledDoubleJump) {
                    _canDoubleJump = true;
                }
            }
        }

        private void Attack() {
            _animator.SetTrigger("attack");

            Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _attackLayerMask);

            if(hit != null) {
                Debug.Log(hit.name);
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
        }

    }

}
