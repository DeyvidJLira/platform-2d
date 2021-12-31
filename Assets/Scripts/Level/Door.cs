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
     * @description classe responsável controlar a portas que levam para outro level
     * 
     */


    public class Door : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D collision) {
            GameManager.Instance.NextLevel();
        }

    }
}
