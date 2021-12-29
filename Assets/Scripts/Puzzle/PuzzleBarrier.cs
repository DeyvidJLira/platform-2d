using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Puzzle {

    /*
    * @author Deyvid Jaguaribe
    * @website https://deyvidjlira.com/
    * 
    * @created_at 29/12/2021
    * @last_update 29/12/2021
    * @description classe responsável por controlar a barreira do puzzle
    * 
    */

    public class PuzzleBarrier : MonoBehaviour {

        private Animator _animator;
        private Collider2D _collider;

        // Start is called before the first frame update
        void Start() {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        public void Open() {
            _animator.SetBool("isOpened", true);
            _collider.enabled = false;
        }

        public void Close() {
            _animator.SetBool("isOpened", false);
            _collider.enabled = true;
        }
    }
}
