using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour{

    public GameObject gameOverScreen;

    public int playerScore;
    public Text textLegacy;

    [ContextMenu("incrementScore")]
    public void incrementScore() {
        this.playerScore++;
        this.textLegacy.text = new string(this.playerScore.ToString());
    }

    public void restartGame() {
        this.gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("activateGameOverScreen")]
    public void activateGameOverScreen() {
        this.gameOverScreen.SetActive(true);
    }
}
