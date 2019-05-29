using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start()
	{
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update()
	{
		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		//発展課題
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.touches[i];

			if (touch.phase == TouchPhase.Began)
			{
				if (touch.position.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				else if (touch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
				{
					SetAngle(this.flickAngle);
				}
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				if (touch.position.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
				else if (touch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
		}
		
		//発展課題のマウスクリックでのテスト（アンドロイド端末を持っていないためこちらでテストをしました）
		/*
		var pos = Input.mousePosition;
		if (Input.GetMouseButton(0))
		{
			if (pos.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
			{
				SetAngle(this.flickAngle);
			}
			else if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag")
			{
				SetAngle(this.flickAngle);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			if (pos.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
			{
				SetAngle(this.defaultAngle);
			}
			else if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag")
			{
				SetAngle(this.defaultAngle);
			}
		}
		*/
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}