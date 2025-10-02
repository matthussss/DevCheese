using UnityEditor;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    // Fields for Banana PreFab, and map
    public GameObject bananaPrefab, map;

    // Used to determine the area where we can spawn bananas
    // using map's collider box
    private Collider2D spawnableArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Note: we are not saying we are spawning bananas ON the colliderbox
        // We are simply gathering its bounds, to know where in the board is the edge
        spawnableArea = map.GetComponent<Collider2D>();
        spawnBanana();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns an instance of a banana that does not collide with the Map
    [ContextMenu("Spawn Banana")]
    public void spawnBanana()
    {
        // create a random 2d vector along the spawnable area
        Vector2 spawnPosition = getRandomPositionInArea(spawnableArea);

        // Checks if spawnPosition collides with some other collider
        // First, it creates a small circle at spawnPosition
        // If said circle collides with another collider, isColliding is true
        bool isColliding = Physics2D.OverlapCircle(spawnPosition, 0.25f);

        // keep generating a new position until isColliding is false
        while (isColliding)
        {

            spawnPosition = getRandomPositionInArea(spawnableArea);
            isColliding = Physics2D.OverlapCircle(spawnPosition, 0.25f);
        }

        // Clones a banana
        Instantiate(bananaPrefab, spawnPosition, Quaternion.identity);
    }

    // Returns a random Vector around the passed Collider2D area
    private Vector2 getRandomPositionInArea(Collider2D area)
    {
        return new Vector2(
            Random.Range(area.bounds.min.x, area.bounds.max.x),
            Random.Range(area.bounds.min.y, area.bounds.max.y)
        );
    }
}
