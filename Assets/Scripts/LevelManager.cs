using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        if (PlayerManager.numberOfPlayers > 0)
        {
            SceneManager.LoadScene(name);
        }
    }
}
