using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // private float timeLeft = 30;
    // public BallScript ball;
    // public Text timer;
    

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     timeLeft -= Time.deltaTime;
    //     // หมดเวลา
    //     if ( timeLeft < 0 )
    //     {
    //         // คะแนนไม่ถึงตามกำหนด 20
    //         if (ball.GetPoint() < 20){
    //             // ตาย (จบเกม แพ้)
    //             ball.SetDead(true);
    //             timer.text = "0";  

    //         }
    //         else {
    //             // ชนะ
    //             ball.winnerscene.SetActive(true);
    //             timer.text = 0.ToString();  
    //         }
    //         timer.text = "0";
            
    //     }
    //     // คะแนนครบตามกำหนด
    //     if (ball.GetPoint() >= 20){
    //         // ชนะ
    //         ball.winnerscene.SetActive(true);
    //         timer.text = "0";
    //         timeLeft=0;
    //     }

    //     if (timeLeft > 0){
    //         // โชว์เวลาบนหน้าจอ
    //         timer.text = timeLeft.ToString("0.00");
    //     }
    //     else {
    //         timer.text = "0";
    //     }
    // }
}
