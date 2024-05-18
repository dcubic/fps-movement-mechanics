using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawn : MonoBehaviour {

    private float DESPAWN_TIME = 10f;

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

    private void Start() {
        StartCoroutine(despawnProjectile());
    }

    private IEnumerator despawnProjectile() {
        yield return new WaitForSeconds(DESPAWN_TIME);
        Destroy(gameObject);
    }
}
