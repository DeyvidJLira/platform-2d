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
     * @description classe responsável por controlar a pedra do puzzle
     * 
     */

    public class PuzzleStone : MonoBehaviour {

        [SerializeField]
        private Transform _buttonDetector;
        [SerializeField]
        private LayerMask _buttonLayerMask;

        public bool IsAboveButton() {
            var hit = Physics2D.Linecast(transform.position, _buttonDetector.position, _buttonLayerMask);
            return hit && transform.rotation.z <= 0.56f ?  true : false;
        }
    }
}
