using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFripper : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;


    // Start is called before the first frame update
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
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);

            
            if (myTouch.phase == TouchPhase.Began) 
            {
                //左画面をタップしたとき左フリッパーを動かす
                if (myTouch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //右画面をタップした時右フリッパーを動かす
                if (myTouch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
               
                Touch[] myTouches = Input.touches;
                for (int i = 1; i < Input.touchCount; i++)
                {
                    SetAngle(this.flickAngle);
                }
            }


            
            

            
            if(myTouch.phase == TouchPhase.Ended)
            {
                //指を離したとき左フリッパーを元に戻す
                if (myTouch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
               
                //指を離したとき右フリッパーを元に戻す
                if(myTouch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                Touch[] myTouches = Input.touches;
                for (int i = 1; i < Input.touchCount; i++)
                {
                    SetAngle(this.defaultAngle);
                }

            }
            
        }


    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
