using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //Tableau pour re affecter le sprite
    public Sprite[] sprites;
    //Index pour le sprite
    private int spriteIndex;

    public AudioSource audioSourceBonus;

    //Force a laquelle on fait remonter le personnage
    public float force = 5f;

    //Gravit� a l'aquelle retombe le personnage
    public float gravity = -9.81f;

    public float inclinaison = 5f;

    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimationSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        //Si le joueur clique sur la barre d'espace ou sur le clique gauche de la souris
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //On ajoute la force au vector vertical
            direction = Vector3.up * force;
        }

        // Application de la gravit� et on update la position de iron man
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Rotation du personnage
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * inclinaison;
        transform.eulerAngles = rotation;
    }

    //
    private void AnimationSprite()
    {
        //Incrementation de l'index
        spriteIndex++;

        
        if (spriteIndex >= sprites.Length)
        {
            //Remise de l'index a l'etat initial
            spriteIndex = 0;
        }

        //Raffectation du spririt renderer avec l'element du tableau sprites
        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gestion des collisions du joueur avec les éléments
        switch (other.gameObject.tag) {
            case "Obstacle":
                FindObjectOfType<GameManager>().GameOver();
                break;
            case "Scoring":
                FindObjectOfType<GameManager>().IncreaseScore();
                break;
            case "bonus":
                FindObjectOfType<GameManager>().Bonus(audioSourceBonus);
                // Destruction du bonus
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

}
