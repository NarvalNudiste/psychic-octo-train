using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour {
    private MusicManager mp;
    void Awake() {
        if (FindObjectOfType<MusicManager>() == null) {
            GameObject musicPlayerGameObject = new GameObject();
            musicPlayerGameObject.name = "musicPlayer";
            musicPlayerGameObject.AddComponent<AudioSource>();
            musicPlayerGameObject.AddComponent<MusicManager>();
            mp = musicPlayerGameObject.GetComponent<MusicManager>();
            DontDestroyOnLoad(mp.gameObject);

        } else {
            mp = FindObjectOfType<MusicManager>();
        }
    }
}
