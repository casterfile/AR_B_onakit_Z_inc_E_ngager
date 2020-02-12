using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
//	public Transform target;
	private float speed = 0.5f;
	private float step;
	private GameObject TransLocation;
	private bool isAttackOn;




	void Start(){
		isAttackOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameScoring.isPause == false){
			step = speed * Time.deltaTime;
			if(GameScoring.EnemyAttack < 3 && GameScoring.EnemyKill == 0){
				//			Debug.Log ("Player Dead");
				TransLocation = GameObject.FindWithTag("Baby");
				transform.position = Vector3.MoveTowards(transform.position, TransLocation.transform.position, step);
			}

			if(transform.position == TransLocation.transform.position){
				//			Debug.Log ("Enemy Remove");
				//			GameScoring.PlayerScore++;
				//			GameScoring.EnemyAttack;
//				if(isAttackOn == false && GameScoring.EnemyAttack == 0){
//					GameScoring.EnemyAttack = 1;
//					isAttackOn = true;
//				}
//				else if(isAttackOn == false && GameScoring.EnemyAttack == 1){
//					GameScoring.EnemyAttack = 2;
//					isAttackOn = true;
//				}
//				else if(isAttackOn == false && GameScoring.EnemyAttack == 2){
//					GameScoring.EnemyAttack = 3;
//					isAttackOn = true;
//				}

				Destroy (this.gameObject);

			}
		}
	}
}
