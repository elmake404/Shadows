using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomMethod : MonoBehaviour
{
    public void StartSpawn()
    {
        CanvasManager.IsGameFlow = false;
        SpawnBalls.Instance.StartSpawn();
        Time.timeScale = CanvasManager.Instance.AccelerationOfTime;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
