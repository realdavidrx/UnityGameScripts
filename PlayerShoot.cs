using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.25f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    
    private float timeUntilFire;
    PlayerMovement pm;


    private void Start() {
        pm = gameObject.GetComponent<PlayerMovement>();
    }
    private void Update() {
    if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time) {
        Shoot();
        timeUntilFire = Time.time + fireRate;
        }
    }
    void Shoot() {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
