using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

	public GameObject LabelWin, LabelLost,PopupInfo1,PopupInfo2,PopupInfo3,PopupInfo4,SummaryPopup,ScoreTemp;
	public GameObject PointController1, PointController2, PointController3, PointController4, PointController5, PointController6, PointController7, PointController8;
	public GameObject ScorePoint1,ScorePoint2,ScorePoint3,ScorePoint4,ScorePointAll;
	private bool isPlayAPPLAUSE,isPoint1,isPoint2,isPoint3,isPoint4,isPoint5;

	public Text timer,Score;
	private float timeLeft;
	private float timeLeftData = 60.0f;
	private bool isBabyCry1, isBabyCry2, isBabyCry3;

	public AudioClip APPLAUSE;
	private AudioSource audio;

	void Awake() {
		GameScoring.EnemyKill = 0;
		GameScoring.PlayerScore = 0;
		GameScoring.EnemyAttack = 0;
		audio = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		LabelWin.SetActive (false);
		LabelLost.SetActive (false);

		GameScoring.EnemyKill = 0;
		GameScoring.PlayerScore = 0;
		GameScoring.EnemyAttack = 0;

		timeLeft = timeLeftData;

		PointController1.SetActive(false);
		PointController2.SetActive(false);
		PointController3.SetActive(false);
		PointController4.SetActive(false);
		PointController5.SetActive(false);
		PointController6.SetActive(false);
		PointController7.SetActive(false);
		PointController8.SetActive(false);


		ScorePoint1.SetActive (false);
		ScorePoint2.SetActive (false);
		ScorePoint3.SetActive (false);
		ScorePoint4.SetActive (false);
		ScorePointAll.SetActive (false);

		isPoint1 = false;
		isPoint2 = false; 
		isPoint3 = false; 
		isPoint4 = false;
		isPoint5 = false;

		isPlayAPPLAUSE = false;

		ScoreTemp.SetActive(true);


	}

	// Update is called once per frame
	void Update () {

		if(timeLeft < 0 && isPlayAPPLAUSE == false){
			isPlayAPPLAUSE = true;
			audio.Stop();
			audio.clip = APPLAUSE;
			audio.Play();
		}


		if (GameScoring.isPause == false){
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0 && GameScoring.EnemyAttack != 3) {
				Debug.Log ("You Win the Game");
				//GameScoring.EnemyKill = 1;
				LabelWin.SetActive (true);
				LabelLost.SetActive (false);

				GameScoring.isPause = true;

				//				if(GameScoring.PlayerScore == 0){
				//					ScorePoint0.SetActive (true);
				//				}
				//				else 

				if(GameScoring.PlayerScore == 1){
					ScorePoint1.SetActive (true);
				}
				else if(GameScoring.PlayerScore == 2){
					ScorePoint2.SetActive (true);
				}
				else if(GameScoring.PlayerScore == 3){
					ScorePoint3.SetActive (true);
				}
				else if(GameScoring.PlayerScore == 4){
					ScorePoint4.SetActive (true);
				}
				else if(GameScoring.PlayerScore == 5){
					ScorePointAll.SetActive (true);
				}

			} else {
				if (GameScoring.EnemyAttack < 3) {
					if (Mathf.Round(timeLeft) < 120 && Mathf.Round(timeLeft) > 60) {
						timer.text = "01:" + Mathf.Round(timeLeft - 60);
					}
					else if (Mathf.Round(timeLeft) < 10) {
						timer.text = "00:0" + Mathf.Round(timeLeft);
					} else {
						timer.text = "00:" + Mathf.Round(timeLeft);
					}

					Score.text = "" + GameScoring.PlayerScore;
					if (GameScoring.PlayerScore > 0)
					{
						ScoreTemp.SetActive(false);
					}

					int Data = Random.Range(0, 9);
					Debug.Log(Data);
					if(Data == 1  && Mathf.Round(timeLeft) < 50 && isPoint1 == false)
					{
						isPoint1 = true;
						PointController1.SetActive(true);
					}

					else if (Data == 2 && Mathf.Round(timeLeft) < 35  && isPoint2 == false)
					{
						isPoint2 = true;
						PointController2.SetActive(true);
					}

					else if (Data == 3  && Mathf.Round(timeLeft) < 25  && isPoint3 == false)
					{
						isPoint3 = true;
						PointController3.SetActive(true);
					}

					else if (Data == 4 && Mathf.Round(timeLeft) < 15  && isPoint4 == false)
					{
						isPoint4 = true;
						PointController4.SetActive(true);
					}

					else if (Data == 5 && Mathf.Round(timeLeft) < 10  && isPoint4 == false)
					{
						isPoint5 = true;
						PointController5.SetActive(true);
					}
					// This for the Other Rumdom

					else if (Data == 6  && Mathf.Round(timeLeft) < 50  && isPoint1 == false)
					{
						isPoint1 = true;
						PointController6.SetActive(true);
					}

					else if (Data == 7  && Mathf.Round(timeLeft) < 25   && isPoint3 == false)
					{
						isPoint3 = true;
						PointController7.SetActive(true);
					}

					else if (Data == 8  && Mathf.Round(timeLeft) < 10   && isPoint5 == false)
					{
						isPoint5 = true;
						PointController8.SetActive(true);
					}
				}
			}
		}
	}


	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		//		Debug.Log ("Nice one");
		//		BabyController.GetComponent<Animation>().Stop ("cry");
		//		BabyController.GetComponent<Animation>().Play ("Happy Baby");
	}

	public void RestartGame(){
		timeLeft = timeLeftData;
		GameScoring.isPause = false;
		GameScoring.EnemyKill = 0;
		GameScoring.PlayerScore = 0;
		GameScoring.EnemyAttack = 0;
		Application.LoadLevel ("Summary");
	}

	public void ShowSummary(){
		LabelWin.SetActive (false);
		SummaryPopup.SetActive (true);

	}

}
