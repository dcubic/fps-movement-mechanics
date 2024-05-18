using UnityEngine;

public class ShootFireball : MonoBehaviour {

    public GameObject fireballPrefab;

    private float distanceFromPlayer = 2f;

    private float MIN_PROJECTILE_FORCE = 15f;
    private float MAX_PROJECTILE_FORCE = 30f;
    private float CHARGE_RATE = 1f;

    private bool isCharging = false;
    private float projectileForce;

    // TODO consideration: minChargeDuration before projectile fires
    // TODO consideration: slow movementspeed while charging
    // TODO consideration: explosion/interaction upon collision (pass in as a parameter to the ProjectileDespawn class?)

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            isCharging = true;
            projectileForce = MIN_PROJECTILE_FORCE;
        }

        if (isCharging) {
            projectileForce += CHARGE_RATE * Time.fixedDeltaTime;
            projectileForce = Mathf.Clamp(projectileForce, MIN_PROJECTILE_FORCE, MAX_PROJECTILE_FORCE);
            Debug.Log($"projectileForce: {projectileForce}");
        }

        if (Input.GetButtonUp("Fire1")) {
            Shoot();
            isCharging = false;
        }
    }
    void Shoot() {
        GameObject projectile = Instantiate(fireballPrefab, transform.position + transform.forward * distanceFromPlayer, Quaternion.identity);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(transform.forward * projectileForce, ForceMode.Impulse);

        projectile.AddComponent<ProjectileDespawn>();
    }
}
