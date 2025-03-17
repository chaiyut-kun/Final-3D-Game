using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform hero; // ตัวแปรชนิด Transform เก็บตำแหน่งของ hero
    //ใช้เก็บข้อมูลอ้างอิงของตำแหน่ง หมุน และขนาด (position, rotation, scale) ของ GameObject ที่ต้องการให้กล้องติดตาม
    public Vector3 offset = new Vector3(0, 5, -10); // ระยะห่างระหว่างกล้องกับ hero
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         // หากยังไม่ได้กำหนด hero ผ่าน Inspector ให้ค้นหาด้วย tag "hero"
        if (hero == null)
        {
            GameObject heroObj = GameObject.FindGameObjectWithTag("WoodenBall");
            if (heroObj != null)
            {
                hero = heroObj.transform;
            }
            else
            {
                Debug.LogWarning("ไม่พบ GameObject ที่มี tag 'woodenBall'");
            }
        }
    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // ตรวจสอบว่า hero ไม่เป็น null ก่อนทำงาน
        if (hero != null)
        {
            // อัพเดทตำแหน่งกล้องให้ติดตาม hero พร้อม offset
            transform.position = hero.position + offset;
            // ตัวเลือก: ทำให้กล้องหันไปที่ hero ด้วย
            transform.LookAt(hero);
        }
    }

}
