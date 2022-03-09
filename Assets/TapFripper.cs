using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFripper : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;

    //�e�������̌X��
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
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
                //����ʂ��^�b�v�����Ƃ����t���b�p�[�𓮂���
                if (myTouch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //�E��ʂ��^�b�v�������E�t���b�p�[�𓮂���
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
                //�w�𗣂����Ƃ����t���b�p�[�����ɖ߂�
                if (myTouch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
               
                //�w�𗣂����Ƃ��E�t���b�p�[�����ɖ߂�
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

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
