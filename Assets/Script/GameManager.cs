using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public static GameManager instance = null;

    public GameObject winText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("SombreroGame", LoadSceneMode.Single);
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Call when the player finish the level
    /// </summary>
    public void Win()
    {
        winText.SetActive(true);
    }

}
