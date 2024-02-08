using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

public class CharacterFall : MonoBehaviour
{
    public float deathHeight = -10f; // The height below which the character dies

    // Update is called once per frame
    void Update()
    {
        CheckFall();
    }

    void CheckFall()
    {
        // Check if the character's Y position is less than the deathHeight
        if (transform.position.y < deathHeight)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}