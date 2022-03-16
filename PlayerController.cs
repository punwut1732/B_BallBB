using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public  Text countText;
    public  Text CongratText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        CongratText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ขยับ
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // เคลื่อนที่ช้า-เร็ว
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement*speed);
    }
        // itemcoin
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"));
        {
            other.gameObject.SetActive(false);
            // คำนวนสกอ
            count = count +1;
            SetCountText();

            AudioSource audio = GetComponent <AudioSource>();
            audio.Play();

        }
    }
    // การนับการเก็บitem
    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
        if (count >= 5)
        {
            CongratText.text = "Congrats!!!";
        }
    }
    
}