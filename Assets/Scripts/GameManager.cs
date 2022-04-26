using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }


    //Mettre un délai lors du lancement
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        //Initialise le score à 0
        score = 0;
        scoreText.text = score.ToString();

        //Desactive l'apparition des élements gameOver et le button de play
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Tuyaux[] pipes = FindObjectsOfType<Tuyaux>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    //Permet d'afficher le menu lorsque l'on perds et relancer
    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    //Permet de figer le jeu
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    //Methode permettant d'incrémenter le score
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
