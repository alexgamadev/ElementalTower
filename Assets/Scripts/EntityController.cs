using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    ElementalTower _playerActions;
    Movement _movement;
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] ProjectileWeapon _weapon;

    void Awake()
    {
        _playerActions = new ElementalTower();
        _movement = GetComponent<Movement>();
        _weapon.Equip();
    }

    // Update is called once per frame
    void Update()
    {
        PollActions();
        PollMovement();
    }

    void OnEnable()
    {
        _playerActions.Player.Enable();
    }

    void PollActions()
    {
        if (_playerActions.Player.Fire.WasPressedThisFrame())
        {
            _weapon.Attack();
        }
    }

    void PollMovement()
    {
        _movement.Move(_playerActions.Player.Move.ReadValue<Vector2>(), _movementSpeed);
    }

    void OnDisable()
    {
        _playerActions.Player.Disable();
    }
}
