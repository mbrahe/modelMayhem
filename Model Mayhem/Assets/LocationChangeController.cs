using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChangeController : MonoBehaviour
{
    public Transform spawnPoint;
    public Camera newCamera;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.position = spawnPoint.position;

            Camera.main.gameObject.SetActive(false);
            newCamera.gameObject.SetActive(true);
        }
    }
}
