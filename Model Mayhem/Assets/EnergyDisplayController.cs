using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDisplayController : MonoBehaviour
{
    // Start is called before the first frame update

    protagMove player;
    SpriteRenderer sr;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<protagMove>();
    }

    // Update is called once per frame
    private void Update()
    {
        float size = player.energy / player.energyMax;
        transform.localScale = new Vector3(size,size,size);
    }
}
