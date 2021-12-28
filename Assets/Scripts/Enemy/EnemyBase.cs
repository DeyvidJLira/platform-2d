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
    * @description classe que estabelece a base de um inimigo
    * 
    */

    public abstract class EnemyBase : MonoBehaviour, IDamageable {

        protected Rigidbody2D _rigidbody;
        protected Animator _animator;

        [SerializeField]
        protected int _health;
        [SerializeField]
        protected int _damage;
        [SerializeField]
        protected float _speed;

        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        protected void Die() {
            _animator.SetTrigger("die");
        }

        protected void AfterDie() {
            Destroy(gameObject);
        }

        public virtual void Damaged(int damage) {
            _animator.SetTrigger("hit");
            _health -= damage;
            if(_health <= 0) {
                Die();
            }
        }
    }
}
