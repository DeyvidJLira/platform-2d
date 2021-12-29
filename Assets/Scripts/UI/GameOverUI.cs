using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.UI {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 29/12/2021
     * @description classe responsável por controlar a janela de gameover
     * 
     */

    public class GameOverUI : MonoBehaviour {

        public static GameOverUI Instance {
            get {
                return _instance;
            }
            private set {
                _instance = value;
            }
        }
        private static GameOverUI _instance;

        [SerializeField]
        private GameObject _window;

        private void Awake() {
            _instance = this;
        }

        public void ShowGameOver() {
            _window.SetActive(true);
        }

        public void ClickRestartGame() {
            GameManager.Instance.RestartGame();
        }
    }
}
