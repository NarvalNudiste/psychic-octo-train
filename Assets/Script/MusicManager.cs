using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    private AudioClip intro;
    private AudioClip loop;
    private AudioSource aS;
    void Start() {
        intro = Resources.Load("musique_pepito_intro") as AudioClip;
        loop = Resources.Load("musique_pepito_loop") as AudioClip;
        aS = this.GetComponent<AudioSource>();
        aS.loop = false;
        aS.clip = intro;
        aS.Play();
    }
    void Update() {
        if (!aS.isPlaying) {
            aS.clip = loop;
            aS.loop = true;
            aS.Play();
        }
    }
}