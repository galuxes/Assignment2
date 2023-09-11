using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private Transform firePoint, rotatePoint;
    [SerializeField] private float bulletSpeed;
    private int _currWeapon = 0;
    
    /// <summary>
    /// The direction of the initial velocity of the fired projectile. That is,
    /// this is the direction the gun is aiming in.
    /// </summary>
    public Vector3 FireDirection => firePoint.up;

    /// <summary>
    /// The position in world space where a projectile will be spawned when
    /// Fire() is called.
    /// </summary>
    public Vector3 SpawnPosition => firePoint.position;

    /// <summary>
    /// The currently selected weapon object, an instance of which will be
    /// created when Fire() is called.
    /// </summary>
    public GameObject CurrentWeapon => projectiles[_currWeapon];

    /// <summary>
    /// Spawns the currently active projectile, firing it in the direction of
    /// FireDirection.
    /// </summary>
    /// <returns>The newly created GameObject.</returns>
    public GameObject Fire()
    {
        var obj = Instantiate(CurrentWeapon, SpawnPosition, Quaternion.identity);
        obj.GetComponent<Particle2D>().velocity = FireDirection * bulletSpeed;
        return obj;
    }

    /// <summary>
    /// Moves to the next weapon. If the last weapon is selected, calling this
    /// again will roll over to the first weapon again. For example, if there
    /// are 4 weapons, calling this 4 times will end up with the same weapon
    /// selected as if it was called 0 times.
    /// </summary>
    public void CycleNextWeapon()
    {
        _currWeapon++;
        if (_currWeapon >= projectiles.Count)
        {
            _currWeapon = 0;
        }
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard.enterKey.wasPressedThisFrame)
        {
            Fire();
        }
        if (keyboard.wKey.wasPressedThisFrame)
        {
            CycleNextWeapon();
        }
        if (keyboard.digit1Key.isPressed)
        {
            transform.RotateAround(rotatePoint.position, Vector3.forward, 0.5f);
        }
        if (keyboard.digit2Key.isPressed)
        {
            transform.RotateAround(rotatePoint.position, Vector3.back, 0.5f);
        }
    }
}
