using Platform2D.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platform2D.Core {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 31/12/2021
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

        private int _level = 1;
        private int _lifePoints = 3;
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

        public int GetLifePoints() {
            return _lifePoints;
        }

        public int GetCoin() {
            return _coin;
        }

        public void IncreaseCoin(int points) {
            _coin += points;
        }

        public void DecreaseLife(int points) {
            _lifePoints -= points;
            LifeUI.Instance.DrawLife();
        }

        public void GameOver() {
            Time.timeScale = 0;
            GameOverUI.Instance.ShowGameOver();
        }

        public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void NewGame() {
            _level = 1;
            _lifePoints = 3;
            _coin = 0;
        }

        public void NextLevel() {
            _level++;
            SceneManager.LoadScene(_level);
        }
    }
}
