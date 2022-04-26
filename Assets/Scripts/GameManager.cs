using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }


    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        // Initialise le jeu
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Vitesse du jeu
        Time.timeScale = 1f;
        player.enabled = true;

        // Cherche le SpawnerBonus et les spawns
        Tuyaux[] pipes = FindObjectsOfType<Tuyaux>();
        Bonus[] bonus = FindObjectsOfType<Bonus>();

        // Boucles pour détruire les pipes et les bonus
        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

        for (int i = 0; i < bonus.Length; i++) {
            Destroy(bonus[i].gameObject);
        }

    }

    public void GameOver()
    {
        // Dans le cas où le joueur perd après un bonus, permet d'afficher le score du joueur au lieu du +2
        scoreText.text = score.ToString();
        // Affiche les boutons "Jouer" et "GameOver"
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        // Met en pause la partie
        // Met le temps à 0 (pas de mouvement) et désactive le player
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        // Incrémente le score
        score++;
        scoreText.text = score.ToString();
    }

    public void Bonus(AudioSource audioSource)
    {
        // Incrémente le score
        score += 2;
        scoreText.text = "+2";
        // Joue le son
        audioSource.Play();
    }

}