using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int score = 0; //スコア計算用変数
    Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GameObject.Find("Text").GetComponent<Text>();
        this.textComponent.text = score.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        string yourtag = collision.gameObject.tag;
        if (yourtag == "SmallStarTag")
        {
            score += 10;
        }
        else if (yourtag == "LargeStarTag")
        {
            score += 20;
        }
        else if (yourtag == "SmallCloudTag")
        {
            score += 15;
        }
        else if (yourtag == "LargeCloudTag")
        {
            score += 25;
        }

        AddScore();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void AddScore()
    {
        this.textComponent.text = score.ToString();
    }
}
