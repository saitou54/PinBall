using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコアを表示するテキスト
	private GameObject scoreText;

	// 現在のスコアを保持する変数
	private int score = 0;

	// Use this for initialization
	void Start()
	{
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update()
	{
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ)
		{
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}

		this.scoreText.GetComponent<Text>().text = "score: " + (score).ToString();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "LargeClowdTag")
		{
			score += 40;
		}
		else if (other.gameObject.tag == "SmallClowdTag")
		{
			score += 30;
		}
		else if (other.gameObject.tag == "LargeStarTag")
		{
			score += 20;
		}
		else if (other.gameObject.tag == "SmallStarTag")
		{
			score += 10;
		}
	}
}