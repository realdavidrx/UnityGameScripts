using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.25f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    PlayerMovement pm;

    private float timeUntilFire;

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
                                                                        //Vector 4 CONFIRMED REAL?!?!?!?!?!?!!?!?
    }
}
