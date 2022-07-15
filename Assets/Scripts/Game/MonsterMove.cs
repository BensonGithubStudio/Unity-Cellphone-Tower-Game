using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
	public GameObject GameControlGameObject;

    public Transform[] positions;

	public int index = 0;

	public float speed;
	public int MinusHeart;
	public bool DontMove;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Castle"){
			if(GameControlGameObject.GetComponent<HeartControl>().Heart > 0){
				GameControlGameObject.GetComponent<HeartControl>().Heart -= MinusHeart;
			}
			Destroy(this.gameObject); 
		}

		if(other.gameObject.tag == "Meteorite"){
			Destroy(this.gameObject);
		}
	}

	void Moving() {
		if(DontMove == false){
			//如果index小於 路徑點數組點最大下標 就繼續移動
			if (index <= positions.Length - 1) {
				//獲得 單位向量
				transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
				// transform.position =  Vector3.up * 0.3f;
				if (Vector3.Distance(positions[index].position, transform.position) <= 1f)
				{
					index++;
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		GameControlGameObject = GameObject.Find("Game Control");
	}
	
	// Update is called once per frame
	void Update () {
		Moving ();

	}
}
