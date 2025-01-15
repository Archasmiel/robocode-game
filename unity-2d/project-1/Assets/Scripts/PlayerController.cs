using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb2d;
    private bool isGrounded;
    public int score;
    public int health;
    [SerializeField] Text scoreText;
    [SerializeField] Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded) {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Jewel")) {
            score++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Obstacle")) {
            health--;
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            // collision.enabled = false;
            if (health <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void LateUpdate() {
        scoreText.text = score.ToString();
        hpText.text = health.ToString();
    }
}
