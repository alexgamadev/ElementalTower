using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 _movementVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_movementVector * Time.deltaTime);
    }

    void FixedUpdate()
    {

    }

    public void Move(Vector2 direction, float speed)
    {
        _movementVector = direction * speed;
    }
}
