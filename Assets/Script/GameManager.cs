using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("SombreroGame", LoadSceneMode.Single);
        }
    }
}
