using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;

    // [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;

    //[SerializeField] private Text scoreText;

    private Rigidbody2D rigidBody2d;
    private Animator animator;

    public GameObject skor, medal_silver, medal_gold, medal_bronze;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            //Burung meloncat
            Jump();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    //Membuat Burung Mati
    public void Dead()
    {
        //Pengecekan jika belum mati dan value OnDead tidak sama dengan Null
        if (!isDead && OnDead != null)
        {
            //Memanggil semua event pada OnDead
            OnDead.Invoke();
        }

        //Mengeset variable Dead menjadi True
        isDead = true;

    }

    void Jump()
    {
        //Mengecek rigidbody null atau tidak
        if (rigidBody2d)
        {
            //menghentikan kecepatan burung ketika jatuh
            rigidBody2d.velocity = Vector2.zero;

            //Menambahkan gaya ke arah sumbu y agar burung meloncat
            rigidBody2d.AddForce(new Vector2(0, upForce));
        }

        //Pengecekan Null variable
        if (OnJump != null)
        {
            //Menjalankan semua event OnJump event
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //menghentikan Animasi Burung ketika bersentukan dengan object lain
        animator.enabled = false;
        if (PlayerPrefs.GetInt("highScore") < skor.GetComponent<skor>().score)
        {
            PlayerPrefs.SetInt("highScore", skor.GetComponent<skor>().score);
        }

        if (skor.GetComponent<skor>().score > 25)
        {
            medal_gold.SetActive(true);
        } else if (skor.GetComponent<skor>().score > 10)
        {
            medal_silver.SetActive(true);
        }
        else if (skor.GetComponent<skor>().score > 1)
        {
            medal_bronze.SetActive(true);
        }
    }

    public void AddScore(int value)
    {
        skor.GetComponent<skor>().score++;

        if (OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
    }
}
