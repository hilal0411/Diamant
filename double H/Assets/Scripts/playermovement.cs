using UnityEngine;

public class playermovement : MonoBehaviour
{
    //Spielerattribute 
    public float speed;
    public int health;
    public int damage;
    public int armor;
    public int maxHealth;
    public int maxArmor;

    private bool isDead = false;
    private bool isGoing = false;
    private float yVelocity = 0f;
    private float xVelocity = 0f;

    private CharacterController characterController;
    private bool facingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController component is missing from this game object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController != null && !isDead)
        {
            //Bewegung des Spielers
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            isGoing = true;

            Vector3 move = transform.right * x + transform.up * y;

            xVelocity = x * speed;
            yVelocity = y * speed;

            float currentSpeed = speed;
            characterController.Move(move * currentSpeed * Time.deltaTime);

            // Flip the sprite if necessary
            if (x > 0 && !facingRight)
            {
                FlipSprite();
            }
            else if (x < 0 && facingRight)
            {
                FlipSprite();
            }

        }
    }

    // Methode zum Umdrehen des Sprites
    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Methode zum Aktualisieren der Animationsparameter
    void UpdateAnimationParameters()
    {
        // Hier kannst du die Animationsparameter aktualisieren, z.B.:
        // animator.SetBool("isGoing", isGoing);
        // animator.SetBool("isDead", isDead);
        // animator.SetFloat("xVelocity", xVelocity);
        // animator.SetFloat("yVelocity", yVelocity);
    }
}