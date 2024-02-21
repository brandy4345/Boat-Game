using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posPlayer = player.transform.position;
        transform.position = new Vector3(posPlayer.x,20,posPlayer.z-13);
    }
}
