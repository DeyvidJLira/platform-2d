using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Items {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 29/12/2021
     * @description classe responsável por definir a base de um elemento coletável
     * 
     */

    public abstract class CollectableBase : MonoBehaviour {

        private Animator _animator;

        [SerializeField]
        private AudioClip _collectedSE;

        // Start is called before the first frame update
        void Start() {
            _animator = GetComponent<Animator>();
        }

        protected abstract void Collect();

        protected void AnimationFinished() {
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision) {
            if(collision.tag == "Player") {
                AudioManager.Instance.PlaySE(_collectedSE);
                _animator.SetTrigger("collect");
                Collect();
            }
        }
       
    }
}