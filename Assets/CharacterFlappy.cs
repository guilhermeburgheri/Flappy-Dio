using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterFlappy : MonoBehaviour
{
    private Rigidbody2D _myRigidbody;
    [SerializeField] private Vector2 flapForce;
    [SerializeField] private InfiniteScroll pipeInfiniteScroll;
    private bool isDead;
    private int currentScore;
    [SerializeField] private Text scoreText;

    public UnityEvent onDeath;

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Flap()
    {
        if(isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        pipeInfiniteScroll.enabled = true;
        _myRigidbody.velocity = Vector2.zero;
        _myRigidbody.AddForce(flapForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            GainScore();
        }
    }

    void GainScore()
    {
        currentScore++;
        scoreText.text = "Score: " + currentScore;
    }

    void Death()
    {
        InfiniteScroll[] allScrools = FindObjectsOfType<InfiniteScroll>();

        foreach (InfiniteScroll scroll in allScrools)
        {
            scroll.enabled = false;
        }
        onDeath?.Invoke();
        isDead = true;
    }
}
