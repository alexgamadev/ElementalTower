using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Transform _target;
    Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(
            _target.position.x - transform.position.x,
            _target.position.y - transform.position.y
        ).normalized;

        _movement.Move(moveDirection, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health healthComp = collision.transform.parent.GetComponent<Health>();
            healthComp.Damage(10);
        }
    }
}
