using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public Text scoreText,scoreTextBG;
	public GameObject restartMessage,knifeSelector,gunSelector,endSection;
	int currentScore=0;
	static GameManager myslf;
	public bool gameOver=false;
	public bool isPlayerVisible=false;
	// int enemyCount;
	void Awake(){
		myslf = this;

	}
	// Use this for initialization
	void Start () {
	
	}

	public void SetPlayerVisible(bool visibility){
		myslf.isPlayerVisible = visibility;
	}

	public static bool GetIsPlayerVisible() {
		return myslf.isPlayerVisible;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			Application.LoadLevel(Application.loadedLevel);
		}
		// if (gameOver && Input.GetKeyDown(KeyCode.R)) {
		// 	Application.LoadLevel(Application.loadedLevel);
		// }

	}
	public static void AddScore(int pointsAdded){
		myslf.currentScore += pointsAdded;
		myslf.scoreText.text = myslf.currentScore.ToString ();
		myslf.scoreTextBG.text = myslf.currentScore.ToString ();
		myslf.scoreText.transform.localScale = Vector3.one * 2.5f;
		iTween.Stop (myslf.scoreText.gameObject);
		iTween.ScaleTo (myslf.scoreText.gameObject, iTween.Hash ("scale", Vector3.one, "time", 0.25f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
	}
	public static void RegisterPlayerDeath(){
		Debug.Log("death");
		//TODO HANDLE DEATH!  Alternatively, use GameManager.gameOver flag elsewhere to restart level or whatever.
		// myslf.restartMessage.SetActive (true);
		// myslf.restartMessage.transform.localScale = Vector3.one *2.0f;
		// iTween.Stop (myslf.restartMessage.gameObject);
		// iTween.ScaleTo (myslf.restartMessage, iTween.Hash ("scale", Vector3.one, "time", 0.5f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
		myslf.gameOver = true;
	}
	public static void SelectWeapon(PlayerWeaponType weaponType){
		switch (weaponType) {
			case PlayerWeaponType.KNIFE:
				myslf.knifeSelector.SetActive(true);
				myslf.gunSelector.SetActive(false);
			break;
			case PlayerWeaponType.PISTOL:
				myslf.knifeSelector.SetActive(false);
				myslf.gunSelector.SetActive(true);
			break;
		}

	}
	// public static void AddToEnemyCount(){
	// 	myslf.enemyCount++;
	// }
	// public static void RemoveEnemy(){
	// 	myslf.enemyCount--;
	// 	if (myslf.enemyCount <= 0) {
	// 		myslf.endSection.SetActive(true);
	// 	}

	// }
}

