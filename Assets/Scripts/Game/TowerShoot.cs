using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject Bullet;
	public AudioSource ShootAudioSource;
	public AudioClip ShootSound;
	public float ShootVolume;
	public float DestroyTime;

	public Transform target;
	public float range;
	public float ShootSpeed;
	public string enemyTag = "Enemy";
	public bool CanShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ArmyAim();
		ShootAudioSource.volume = ShootVolume;
    }

    void ArmyAim () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
			if(CanShoot){
				Invoke("ShootControl", ShootSpeed);
				CanShoot = false;
			}
		} else {
			target = null;
		}

		if (target != null) {
			transform.LookAt (target);
		}
	}

	void ShootControl(){
		GameObject b = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z));
		if(ShootAudioSource != null){
			ShootAudioSource.PlayOneShot(ShootSound);
		}
		Destroy(b, DestroyTime);
		CanShoot = true;
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
