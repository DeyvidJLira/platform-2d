using Platform2D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platform2D.UI {
    public class LifeUI : MonoBehaviour {

        public static LifeUI Instance {
            get {
                return _instance;
            }
            private set {
                _instance = value;
            }
        }
        private static LifeUI _instance;

        [SerializeField]
        private List<Image> _listLifeIcons;

        private void Awake() {
            _instance = this;
        }

        // Start is called before the first frame update
        void Start() {
            DrawLife();
        }

        // Update is called once per frame
        void Update() {

        }

        public void DrawLife() {
            _listLifeIcons.ForEach(item => { item.enabled = false; });
            for(int i = 0; i < GameManager.Instance.GetLifePoints(); i++) {
                _listLifeIcons[i].enabled = true;
            }
        }
    }
}
