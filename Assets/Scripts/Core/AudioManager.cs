using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Core {
    public class AudioManager : MonoBehaviour {

        public static AudioManager Instance {
            get {
                return _instance;
            }
            private set {
                _instance = value;
            }
        }

        private static AudioManager _instance;
      
        private AudioSource _audioSource;

        private void Awake() {
            if(_instance == null) {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            } else if(_instance != this) {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start() {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySE(AudioClip clip) {
            _audioSource.PlayOneShot(clip);
        }
    }
}
