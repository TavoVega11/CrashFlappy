using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;

    private int score;
    public Text scoreText;
    private void Awake()
    {
        if(GameController.instance == null)
        {
            GameController.instance = this;
        }else if(GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no deberia pasar");
        }
        
    }
    
    public void CrashScored()
    {
        if (gameOver) return;

        score++;
        scoreText.text = "Puntuación: " + score;
        SoundSystem.instance.PlayCoin();
    }

    public void crashDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    private void OnDestroy()
    {
        if(GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
