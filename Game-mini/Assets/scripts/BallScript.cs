using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{

    public Rigidbody rb;
    private float move_force = 20f; // แรงที่ใช้ในการเดิน จะทดลองนำไปใช้คู่กับ Addforce ใน script นี้
    public Transform Camera;
    public float jump_force = 100f; // กำหนดแรงกระโดด
    private bool is_grounded = true; // ตรวจสอบว่าลูกบอลอยู่บนพื้นหรือไม่
    private Vector3 checkpoint;
    private bool win = false;
    public GameObject Winner;
    public AudioSource source;
    public AudioClip oof;
    public AudioClip exp;
    public AudioClip walk;
    public AudioClip jump;


    private int coin = 0;

    // sound asset

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
        IsWin();
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
            source.clip = jump;
            source.Play();
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
            source.clip = oof;
            source.Play();
            
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
        if(collision.gameObject.CompareTag("Win")){
            win = true;
        }
        
        
    }


    // // เช็คการชนะ
    private void IsWin(){
        if (win){
            Winner.SetActive(true);
        }
        
    }

}
