using UnityEngine;

public class BananaBehaviour : MonoBehaviour
{
    // Component for score UI
    public ScoreManager scoreManager;

    // Component to spawn banana
    public BananaSpawner bananaSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize our fields once the program runs
        // This is essential, as Banana will turn into a prefab
        // Of which fields like these have to be initiailized through code
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        bananaSpawner = GameObject.FindGameObjectWithTag("BananaManager").GetComponent<BananaSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when another collider triggers Banana's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the collider is from the Player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player touched the banana!");
            AudioManager.Instance.playSfx("swallow");
            scoreManager.IncreaseScore();

            // destroy this instance of a banana
            // the player already ate it
            Destroy(gameObject);

            // spawn another banana
            bananaSpawner.spawnBanana();
        }
    }

}
