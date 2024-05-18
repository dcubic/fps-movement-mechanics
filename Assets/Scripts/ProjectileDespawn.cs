using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawn : MonoBehaviour {

    private float DESPAWN_TIME = 10f;

    private void OnCollisionEnter(Collision collision) {
        GameObject collidedObject = collision.gameObject;
        Destroy(gameObject);
        CrawlerBehaviour crawler = collidedObject.GetComponent<CrawlerBehaviour>(); // Expand to EnemyBehaviour in the future will all classes implementing takeDamage()
        if (crawler != null) crawler.takeDamage();
    }

    private void Start() {
        StartCoroutine(despawnProjectile());
    }

    private IEnumerator despawnProjectile() {
        yield return new WaitForSeconds(DESPAWN_TIME);
        Destroy(gameObject);
    }
}
