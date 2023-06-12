using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private float timer;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2") && timer > cooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation) as GameObject;
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}