using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platform2D.UI {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 31/12/2021
     * @description classe responsável por controlar a janela de menu
     * 
     */

    public class MenuUI : MonoBehaviour {

        public void PlayGame() {
            GameManager.Instance.NewGame();
            SceneManager.LoadScene(1);
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}
