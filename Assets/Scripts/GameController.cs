using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;

    Quaternion playerRotation;
    MovementController movementController;
    private GameOver gameOver;
    private AudioManager audioManager;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        playerRb = GetComponent<Rigidbody2D>();
        gameOver = FindObjectOfType<GameOver>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        checkpointPos = transform.position;
        playerRotation = transform.rotation;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
        playerRotation = transform.rotation;
    }

    public void Die()
    {
        if (audioManager != null)
        {
            audioManager.PauseMusic();
            audioManager.PlaySFX(audioManager.death);
        }
        gameOver.GameOverScreen();
        StartCoroutine(Respawn(0.5f));
    }
    IEnumerator Respawn(float duration)
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.rotation = playerRotation;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
        movementController.UpdateRelativeTransform();
    }
    public void RespawnInstant()
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = checkpointPos;
        transform.rotation = playerRotation;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
        movementController.UpdateRelativeTransform();
    }
}
