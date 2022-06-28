using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth;

    public delegate void DeathAction(GameObject gameObject);
    public event DeathAction OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnDeath?.Invoke(this.gameObject);

        if (this.transform.tag == "Player")
        {
            GameManager.Instance.GetTimer().StopTimer();
            SceneManager.LoadScene("GameOver");
        }
        else if (this.transform.tag == "Boss")
        {
            GameManager.Instance.GetTimer().StopTimer();
            SceneManager.LoadScene("LevelComplete");
        }
        else
        {
            Destroy(this.transform.gameObject, 0.1f);
        }
    }
}
