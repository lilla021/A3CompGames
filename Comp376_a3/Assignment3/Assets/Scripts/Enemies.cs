using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed, levelSpeed;
    public static bool movesRight, movesLeft;
    GameObject s_rightShark, s_leftShark, m_rightShark, m_leftShark, l_rightShark, l_leftShark, octo;

    private void Start()
    {
        
        levelSpeed = 0;
        s_rightShark = GameObject.Find("s_rightShark");
        s_leftShark = GameObject.Find("s_leftShark");
        m_rightShark = GameObject.Find("m_rightShark");
        m_leftShark = GameObject.Find("m_leftShark");
        l_rightShark = GameObject.Find("l_rightShark");
        l_leftShark = GameObject.Find("l_leftShark");
        //octo = GameObject.Find("Octo");

    
    }
    void Update()
    {
      /*  if (s_rightShark || s_leftShark)
            speed = 4.0f;
        if (m_rightShark || m_leftShark)
            speed = 3.0f;
        if (l_rightShark || l_leftShark)
            speed = 2.0f;*/
       // speed += 3;

        if (this.gameObject.CompareTag("s_rightShark"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, 0f);
        }
        if (this.gameObject.CompareTag("m_rightShark"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, 0f);
        }
        if (this.gameObject.CompareTag("l_rightShark"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, 0f);
        }
        if (this.gameObject.CompareTag("s_leftShark"))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, 0f);
        }
        if (this.gameObject.CompareTag("m_leftShark"))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, 0f);
        }
        if (this.gameObject.CompareTag("l_leftShark"))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, 0f);
        }

        checkBounds();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FirstPersonPlayer"))
        {

            Debug.Log("Hit by enemy!");

            PlayerStats.currentLife -= 1;

        }
    }
    private void checkBounds()
    {
        if (transform.position.x > 860)
        {
            transform.position = new Vector3(421, transform.position.y, transform.position.z);
        }

        if (transform.position.x < 420)
        {
            transform.position = new Vector3(859, transform.position.y, transform.position.z);
        }
    }

    private void FaceDirection(Vector3 direction)
    {
        Quaternion rotation3D = direction == Vector3.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;

    }
    //if shark : distraction method

    //if octo : attack method
}
