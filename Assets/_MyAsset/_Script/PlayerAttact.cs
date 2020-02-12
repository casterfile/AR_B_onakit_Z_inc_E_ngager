using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerAttact : MonoBehaviour {
	public AudioSource popSound;
	public bool isPopUpInfo;
	public GameObject PopupInfo;
	public AudioClip otherClip;

	void Start(){
		popSound = GetComponent<AudioSource>();
	}



	void OnMouseDown()
	{
//		popSound.Play ();
		popSound.clip = otherClip;
		popSound.Play();
		GameScoring.PlayerScore++;
//		if(GameScoring.PlayerScore >= 8){
//			Debug.Log ("You Win the Game");
//		}


//		Debug.Log (this.gameObject.tag);
		if(isPopUpInfo == true){
			GameScoring.isPause = true;
			Debug.Log ("Show Popup");
			PopupInfo.SetActive (true);
		}

//        Destroy (this.gameObject);

//        gameObject.SetActive(false);
		transform.position = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(0, 0, 0);
		
	}
}
