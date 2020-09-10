using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTembak : MonoBehaviour
{
    public GameObject bullet, Pos_peluru;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, Pos_peluru.transform.position, Quaternion.Euler(0, 0, -45));
        }   
    }
}
