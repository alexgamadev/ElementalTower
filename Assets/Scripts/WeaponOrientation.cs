using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponOrientation : MonoBehaviour
{
    public bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        if (!flipped && (transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f))
        {
            flipped = true;
        }
        else if (flipped && (transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f))
        {
            flipped = false;
        }

        if (!flipped)
        {
            transform.right = direction;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        }
        else
        {
            direction.x *= -1;
            transform.right = direction;
            transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);
        }

    }
}
