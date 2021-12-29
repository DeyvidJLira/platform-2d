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
    * @description classe responsável por controlar o botão do puzzle
    * 
    */

    public class PuzzleButton : MonoBehaviour {

        private Animator _animator;

        // Start is called before the first frame update
        void Start() {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnCollisionStay2D(Collision2D collision) {
            if(collision.gameObject.tag == "Stone") {
                if(collision.gameObject.GetComponent<PuzzleStone>().IsAboveButton()) {
                    _animator.SetBool("isPressed", true);
                    PuzzleManager.Instance.UnlockBarrier();
                } else {
                    _animator.SetBool("isPressed", false);
                    PuzzleManager.Instance.LockBarrier();
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            if ( collision.gameObject.tag == "Stone") {
                _animator.SetBool("isPressed", false);
                PuzzleManager.Instance.LockBarrier();
            }
        }
    }

}
