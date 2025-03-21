using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{

    public Rigidbody rb;


    private float move_force = 20f; // แรงที่ใช้ในการเดิน จะทดลองนำไปใช้คู่กับ Addforce ใน script นี้
    private int life = 10;
    // public float explode_force = 1000f;
    private bool is_dead;
    public Transform Camera;
    public float jump_force = 100f; // กำหนดแรงกระโดด
    private bool is_grounded = true; // ตรวจสอบว่าลูกบอลอยู่บนพื้นหรือไม่
    private Vector3 checkpoint;


    // sound asset
    // public AudioClip boom;
    // public AudioClip coin;
    // public AudioSource source;

    private int point = 0;
    // public TextMeshPro point_text;
    // public TextMeshPro life_text;
    // public GameObject overscene;
    // public GameObject winnerscene;

    // sound asset

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        is_dead = false;
        // life_text.text = life.ToString();
        // overscene.SetActive(false);
        // winnerscene.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {

        // if (!IsWin()){
        //     if (!is_dead){
        //         Move();
        //         Dead();
        //     }
        //     Dead();
        // }
        // Dead();

        Move();
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    private void Move(){

        // //  ---- move part ----
        float move_horizontal = Input.GetAxis("Horizontal");   //Horizontal แนวนอน
        float move_vertical = Input.GetAxis("Vertical");       // Vertical แนวตั้ง
        
        // กำหนดความเร็วของการเคลื่อนที่
        Vector3 forward = Camera.forward;
        Vector3 right = Camera.right;

        Vector3 movement = (forward * move_vertical + right * move_horizontal).normalized * move_force;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * move_force, ForceMode.Force);
        }
	    // move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * move_force, ForceMode.Force);
        }

        Jump();
    }

    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        {
            rb.AddForce(Vector3.up * jump_force); // เพิ่มแรงกระโดด
            is_grounded = false; // ตั้งค่าให้รู้ว่าลูกบอลอยู่กลางอากาศ

            Debug.Log("Jump!");
        }
    }

    private Vector3 GetCheckPoint() {
        return checkpoint;

    }
    private void SetCheckPoint(Vector3 position){
        checkpoint = position;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Lava")){
            rb.position = GetCheckPoint();
        }
        if (collision.gameObject.CompareTag("Ground")) // เช็คว่าลูกบอลแตะพื้น
        {
           is_grounded = true;
           Debug.Log("Ground!");
        }
        
        // check if dead
        if(collision.gameObject.CompareTag("CheckPoint")){
            // Retrieve the position of the checkpoint object
            Vector3 checkpointPosition = collision.gameObject.transform.position; // or use collision.transform.position
            Debug.Log("Checkpoint position: " + checkpointPosition);
            SetCheckPoint(checkpointPosition);
        }
        
    }


    // // เช็คการชนะ
    // private bool IsWin(){
    //     if (GetPoint() >= 20){
    //         return true;
    //     }
    //     return false;
    // }

    // // Set Life Status
    // public void SetDead(bool set){
    //     is_dead = set;
    //     Dead();
    // }


    // public int GetPoint() {
    //     return point;
    // }

    // // Restart the game
    // public void Restart(){
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    // }

    // // check if collision with bomb
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("bomb")){
    //         life--;
    //         rb.AddForce(Vector3.back * explode_force );
    //         rb.AddForce(Vector2.up * explode_force );
    //         // Debug.Log("boomb Your father died");
    //         // source.clip = boom;
    //         // source.Play();

    //         }
    //     if(collision.gameObject.CompareTag("coin")){
    //         // source.clip = coin;
    //         // source.Play();
    //         point_text.text = (++point).ToString();
    //     }
    //     life_text.text = life.ToString();
    // }



}
