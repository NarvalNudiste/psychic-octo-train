using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    public AudioClip intro;
    public AudioClip loop;
    private AudioSource aS;
    void Start() {
            DontDestroyOnLoad(this.gameObject);
            aS = this.GetComponent<AudioSource>();
            aS.loop = false;
            aS.clip = intro;
            aS.Play();
        }
    }
    void Update() {
        if (!aS.isPlaying) {
            aS.clip = loop;
            aS.loop = true;
            aS.Play();
        }
    }
}