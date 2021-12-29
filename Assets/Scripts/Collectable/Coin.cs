using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Items {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 29/12/2021
     * @description classe responsável por controlar a moeda
     * 
     */

    public class Coin : CollectableBase {

        [SerializeField]
        private int _coins;

        protected override void Collect() {
            GameManager.Instance.IncreaseCoin(_coins);
        }

    }
}
