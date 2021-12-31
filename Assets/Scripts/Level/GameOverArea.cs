using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Level {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 31/12/2021
     * @last_update 31/12/2021
     * @description classe responsável controlar a área de GameOver
     * 
     */

    public class GameOverArea : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.tag == "Player") {
                GameManager.Instance.GameOver();
            }
        }
    }
}
