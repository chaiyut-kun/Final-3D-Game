    using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Some");
        if(other.gameObject.CompareTag("WoodenBall")){
            Destroy(gameObject);  
        }
    }
}
