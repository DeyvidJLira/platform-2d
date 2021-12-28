using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2D.Core;

namespace Platform2D.Enemy {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 28/12/2021
     * @last_update 28/12/2021
     * @description classe responsável por controlar o slime
     * 
     */


    public class Slime : EnemyBase {

        [SerializeField]
        private Transform _patrolPoint;
        [SerializeField]
        private float _patrolRadius;
        [SerializeField]
        private LayerMask _wallLayerMask;
        [SerializeField]
        private int _direction;

        // Update is called once per frame
        void Update() {
            if (_health > 0) {
                VerifyDirection();
            }
        }

        private void FixedUpdate() {
            if(_health > 0) {
                _rigidbody.velocity = new Vector2(_speed * _direction, _rigidbody.velocity.y);
            }
        }

        private void VerifyDirection() {
            Collider2D hit = Physics2D.OverlapCircle(_patrolPoint.position, _patrolRadius, _wallLayerMask);
            if(hit != null) {
                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                _direction *= -1;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_patrolPoint.position, _patrolRadius);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.tag == "Player") {
                collision.GetComponent<IDamageable>().Damaged(_damage);
            }
        }
    }
}
