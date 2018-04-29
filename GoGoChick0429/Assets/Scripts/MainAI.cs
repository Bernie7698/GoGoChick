using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainAI : MonoBehaviour {

	public GameObject Chick_Yellow;    //存放黃色小雞
	public GameObject Chick_Red;       //存放紅色小雞
	public GameObject Chick;           //記錄該次要放的小雞\
	public GameObject MainCamera;      //紀錄監視器物件
	private int Amount;                //記錄丟小雞的數目
	public static bool IsPress;        //判斷左右旋轉按鈕是否被壓下
	public static int Score;           //紀錄分數
	public Text ScoreString;           //顯示分數字串
	static bool shot;                  //紀錄是否可以射擊
	public static int lift;            //記錄生命值
	public Text LiftString;            //顯示生命字串
	public Button ReturnButton;        //重玩按鈕
	private float Timer;               //倒數計時
	public Image red_Image;            //存放紅色小雞圖示
	public Image yellow_Image;         //存放黃色小雞圖示
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		IsPress = false;
		Score = 0;
		shot = true;
		lift = 10;
		ReturnButton.gameObject.SetActive (false);
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)&&!IsPress && shot) {
			Vector3 ShortPos = new Vector3 (MainCamera.transform.position.x,
				MainCamera.transform.position.y - 0.5f,
				MainCamera.transform.position.z);
			Score++;        //當丟出去的時候加一分
			Amount++;
			if(Amount%5 != 0)
				Chick = Instantiate (Chick_Yellow, ShortPos, Quaternion.Euler (270, 180, 0));
			else
				Chick = Instantiate (Chick_Red, ShortPos, Quaternion.Euler (270, 180, 0));

			audio.Play ();
			if (Amount % 5 == 4) {
				yellow_Image.enabled = false;
				red_Image.enabled = true;
			} else {
				yellow_Image.enabled = true;
				red_Image.enabled = false;
			}

			Ray MouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			Chick.GetComponent<Rigidbody> ().AddForce (MouseRay.direction.x*(Input.mousePosition.y/Screen.height*1200),
													   150,
													   MouseRay.direction.z*(Input.mousePosition.y/Screen.height*1200));
			Chick.GetComponent<Rigidbody> ().AddRelativeTorque (-8, 0, 0);
		}
		if (lift < 1) {
			shot = false;
			Timer += Time.deltaTime;
			if (Timer > 2) {
				ReturnButton.gameObject.SetActive (true);
				red_Image.enabled = false;
				yellow_Image.enabled = false;
			}
		}

      if(IsPress == true)
      {
         shot = false;
      }
      
		ScoreString.text = Score.ToString ();
		LiftString.text = lift.ToString ();
	}
	public void PlayAgain(){
		//Application.LoadLevel 為舊方法
		//Application.LoadLevel (0);
		SceneManager.LoadScene(0);
	}
}
