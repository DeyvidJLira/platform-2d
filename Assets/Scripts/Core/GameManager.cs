using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Core {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 29/12/2021
     * @description classe responsável por gerenciar elementos persistentes no jogo
     * 
     */

    public class GameManager : MonoBehaviour {

        public static GameManager Instance {
            get {
                return _instance;
            }
            private set {
                _instance = value;
            }
        }

        private static GameManager _instance;

        private int _coin = 0;

        private void Awake() {
            if(_instance == null) {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            if(_instance != this) {
                Destroy(gameObject);
            }
        }

        public int GetCoin() {
            return _coin;
        }

        public void IncreaseCoin(int points) {
            _coin += points;
        }
    }
}
