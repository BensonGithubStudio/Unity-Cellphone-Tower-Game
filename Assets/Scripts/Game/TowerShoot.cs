using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public bool IsRun;

	[Header("升級資訊")]
	public GameObject GameControlGameObject;
	public GameObject UpgradeEffect;
	public float TowerLevel;
	public Text TowerLevelInfoText;
	public Text UpgradeMoneyText;
	public int UpgradeMoney;
	public string TheTower;
	public AudioSource TowerAudioSource;
	public AudioClip UpgradeSound;
    
    // Start is called before the first frame update
    void Start()
    {
		IsRun = true;
        CanShoot = true;
		TowerLevel = 1;
		UpgradeMoney = 200;
		GameControlGameObject = GameObject.Find("Game Control");
    }

    // Update is called once per frame
    void Update()
    {
		if(IsRun){
        	ArmyAim();
			ShootAudioSource.volume = ShootVolume;
			TowerLevelInfoText.text = "Level " + TowerLevel;
			UpgradeMoneyText.text = UpgradeMoney + "$";
		}
    }

	public void OnClickUpgrade(){
		if(GameControlGameObject.GetComponent<MoneyControl>().Money >= UpgradeMoney){
			GameControlGameObject.GetComponent<MoneyControl>().Money -= UpgradeMoney;
			TowerLevel += 1;
			TowerAudioSource.PlayOneShot(UpgradeSound);
			UpgradeEffect.SetActive(false);
			UpgradeEffect.SetActive(true);
			UpgradeMoney += 50;
		}
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
				InvokeRepeating("ShootControl", 0, ShootSpeed);
				CanShoot = false;
			}
		} else {
			target = null;
			CancelInvoke("ShootControl");
			CanShoot = true;
		}

		if (target != null) {
			transform.LookAt (target);
		}
	}

	void ShootControl(){
		if(IsRun){
			GameObject b = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z));
			if(TheTower == "Single"){
				b.GetComponent<SingleTowerBullet>().BulletStrong += TowerLevel * 50;
			}else if(TheTower == "Quick"){
				b.GetComponent<QuickTowerBullet>().BulletStrong += TowerLevel * 30;
			}else if(TheTower == "Laser"){
				b.GetComponentInChildren<LaserTowerBullet>().BulletStrong += TowerLevel * 60;
			}else if(TheTower == "Bomb"){
				b.GetComponent<BombTowerBullet>().BulletStrong += TowerLevel * 40;
			}
			if(ShootAudioSource != null){
				ShootAudioSource.PlayOneShot(ShootSound);
			}
			Destroy(b, DestroyTime);
		}
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
