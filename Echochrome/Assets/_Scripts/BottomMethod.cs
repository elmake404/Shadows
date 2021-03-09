﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomMethod : MonoBehaviour
{
    public void StartSpawn()
    {
        SpawnBalls.Instance.StartSpawn();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
