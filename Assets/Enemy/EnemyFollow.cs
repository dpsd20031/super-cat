using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class EnemyFollow : MonoBehaviour
{
    public Transform mainCharacter;
    public float speed = 2.0f;
    private bool isFacingRight = true;

    void Update()
    {
        FollowCharacter();
    }

    void FollowCharacter()
    {
        // Move towards the main character
        transform.position = Vector2.MoveTowards(transform.position, mainCharacter.position, speed * Time.deltaTime);

        // Flip the enemy to face the main character
        if ((mainCharacter.position.x < transform.position.x && isFacingRight) ||
            (mainCharacter.position.x > transform.position.x && !isFacingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // This method is called when the enemy collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object it collided with is the main character
        if (collision.transform == mainCharacter)
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}