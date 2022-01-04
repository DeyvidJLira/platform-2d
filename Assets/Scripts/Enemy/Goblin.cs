using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Enemy {

    /*
    * @author Deyvid Jaguaribe
    * @website https://deyvidjlira.com/
    * 
    * @created_at 31/12/2021
    * @last_update 03/01/2021
    * @description classe responsável por controlar o globin
    * 
    */

    public class Goblin : EnemyBase {

        [SerializeField]
        private LayerMask _targetMask;
        [SerializeField]
        private Transform _attackDistance;
        [SerializeField]
        private float _attackTimeDelay = 2f;
        [SerializeField]
        private float _attackTimeElapsed = 0f;

        [SerializeField]
        private float _detectorDistance;

        [SerializeField]
        private bool _isToRight = true;
        private bool _followPlayer = false;
        private bool _canAttack = false;

        private void Update() {
            if (!IsAlive()) return;
            _attackTimeElapsed += Time.deltaTime;
            UpdateAnimations();
        }

        void FixedUpdate() {
            if (!IsAlive()) return;
            SearchPlayer();
            Movement();
            PlayerInAttackArea();
            AttackAnimation();
        }

        void UpdateAnimations() {
            _animator.SetBool("run", _rigidbody.velocity.x != 0);
        }

        void Movement() {
            if(_followPlayer && !_canAttack) {
                float direction = _isToRight ? 1f : -1f;
                _rigidbody.velocity = new Vector2(_speed * direction, _rigidbody.velocity.y);
            } else {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            }
        }

        void SearchPlayer() {
            bool playerDetected = false;
            RaycastHit2D rayRight = Physics2D.Raycast(transform.position, Vector2.right, _detectorDistance, _targetMask);
            if (rayRight.collider != null) {                
                if (rayRight.collider.tag == "Player") {
                    _followPlayer = true;
                    playerDetected = true;
                    FlipX(true);
                }
            }

            RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, Vector2.left, _detectorDistance, _targetMask);
            if (rayLeft.collider != null) {
                if (rayLeft.collider.tag == "Player") {
                    _followPlayer = true;
                    playerDetected = true;
                    FlipX(false);
                }
            }

            if(!playerDetected) {
                _followPlayer = false;
            }
        }

        void FlipX(bool directionToRight) {
            if(directionToRight != _isToRight) {
                _isToRight = directionToRight;
                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        void PlayerInAttackArea() {
            Vector2 direction = _isToRight ? Vector2.right : Vector2.left;
            RaycastHit2D rayAttack = Physics2D.Raycast(transform.position, direction, Vector2.Distance(transform.position, _attackDistance.position), _targetMask);
            if(rayAttack.collider != null) {
                if(rayAttack.collider.tag == "Player") {
                    _canAttack = true;
                }
            } else {
                _canAttack = false;
            }
        }

        void AttackAnimation() {
            _animator.SetBool("canAttack", _canAttack);
            _animator.SetBool("attacking", _attackTimeElapsed >= _attackTimeDelay);
        }

        void Attack() {
            _attackTimeElapsed = 0f;
            Vector2 direction = _isToRight ? Vector2.right : Vector2.left;
            RaycastHit2D rayAttack = Physics2D.Raycast(transform.position, direction, Vector2.Distance(transform.position, _attackDistance.position), _targetMask);
            if (rayAttack.collider != null) {
                if (rayAttack.collider.tag == "Player") {
                    rayAttack.collider.GetComponent<IDamageable>().Damaged(_damage);
                }
            } 
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector2.right * _detectorDistance);
            Gizmos.DrawRay(transform.position, Vector2.left * _detectorDistance);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag == "Player") {
                collision.GetComponent<IDamageable>().Damaged(_damage);
            }
        }
    }
}
