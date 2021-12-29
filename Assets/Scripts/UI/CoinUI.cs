using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platform2D.Core;

namespace Platform2D.UI {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 29/12/2021
     * @last_update 29/12/2021
     * @description classe responsável por controlar a representação de contador de moedas
     * 
     */

    public class CoinUI : MonoBehaviour {

        [SerializeField]
        private Text _coinText;

        // Update is called once per frame
        void Update() {
            UpdateCoin();
        }

        private void UpdateCoin() {
            _coinText.text = " " + FormatCoin(GameManager.Instance.GetCoin());
        }

        private string FormatCoin(int value) {
            int counterDecimal = 0;
            int aux = value;
            while(aux >= 10) {
                aux /= 10;
                counterDecimal++;
            }

            string coinString = value.ToString().PadLeft(6-counterDecimal, '0');
            return coinString;
        }

    }
}
