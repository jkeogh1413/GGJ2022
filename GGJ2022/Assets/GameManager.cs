using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float restartDelay = 3f;
    public GameObject gameOverPanel;

    public enum GameState {
        Active,
        Paused,
        Ended
    }

    public static GameState gameState;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        gameState = GameState.Active;
    }

    public static void EndGame() {
        gameState = GameState.Ended;
        AudioManager.GameOverManGameOver();

        // Display game over screen
        instance.gameOverPanel.SetActive(true);

        // Wait for seconds and restart scene
        if (instance != null)
            instance.StartCoroutine(instance.DelayedRestart());
    }

    IEnumerator DelayedRestart() {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
