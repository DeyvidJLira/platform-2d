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
        private LayerMask _groundMask;
        private bool _onGround;

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
            _onGround = Physics2D.Linecast(transform.position, _groundDetector.position, _groundMask);
        }

        private void UpdateAnimations() {
            _animator.SetBool("onGround", _onGround);
            _animator.SetBool("velocityX", _velocity.x != 0);
        }

        private void FlipX(float direction) {
            if((direction < 0 && _isFaceToRight) || (direction > 0 && !_isFaceToRight)) {
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
    }
}
