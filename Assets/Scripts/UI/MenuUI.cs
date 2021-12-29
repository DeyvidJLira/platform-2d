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
     * @last_update 29/12/2021
     * @description classe responsável por controlar a janela de menu
     * 
     */

    public class MenuUI : MonoBehaviour {

        public void PlayGame() {
            SceneManager.LoadScene(1);
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}
