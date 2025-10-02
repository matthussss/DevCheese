using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer sr;
    private BoxCollider2D boxCollider;
    // Adjusts the speed of the mouse, we can edit this in Unity Inspector
    [SerializeField] private float speed;

    // Responsible for our movement
    // To access our RigidBody2D Component, we need a variable to store it
    // Same idea with classes and objects as per most COMP Courses
    private Rigidbody2D rb;

    // A 2D Vector we will use to manipulate movement
    private Vector2 movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // To initialize rb, we can actually access our component RigidBody2D like so
        // Remember we are NOT making a new object, we are only accessing the one we made awhile ago
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves our 2d vector depending on how much we hold WASD or the arrow keys
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Sprite newSprite = sr.sprite;

        // Change sprite depending on direction
        if (moveY > 0) sr.sprite = upSprite;
        else if (moveY < 0) sr.sprite = downSprite;
        else if (moveX > 0) sr.sprite = rightSprite;
        else if (moveX < 0) sr.sprite = leftSprite;

        if (sr.sprite != newSprite)
        {
            // update collider size
            if (boxCollider != null)
            {
                boxCollider.size = sr.sprite.bounds.size;
                boxCollider.offset = sr.sprite.bounds.center;
            }
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        // manipulates the direction of our mouse with regards to speed
        rb.linearVelocity = movementDirection * speed;
    }
}

