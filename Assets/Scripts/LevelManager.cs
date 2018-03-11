﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        if (NewPlayerScript.numberOfPlayers > 0)
        {
            SceneManager.LoadScene(name);
        }
    }
}
