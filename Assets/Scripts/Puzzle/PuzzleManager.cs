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
    * @description classe responsável por gerenciar o puzzle
    * 
    */

    public class PuzzleManager : MonoBehaviour {

        public static PuzzleManager Instance { 
            get {
                return _instance;
            }
            private set {
                _instance = value;
            }
        }

        private static PuzzleManager _instance;

        [SerializeField]
        private PuzzleBarrier levelBarrier;

        private void Awake() {
            _instance = this;
        }

        public void UnlockBarrier() {
            levelBarrier.Open();
        }

        public void LockBarrier() {
            levelBarrier.Close();
        }
    }
}
