using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawn;
    public Transform bullletContainer;
    public float shotCooldown = 1.0f;
    public bool canShoot = true;

    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

        // Parent and child are based on transform and not GameObject.

        // Type for and hit tab a couple times to get the base for loop code

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.back * horizontalInput * speed * Time.deltaTime);
        
        transform.Translate(Vector3.right * verticalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine("ShootWithCooldown");
        }

    }

    IEnumerator ShootWithCooldown()
    {
        // Stuff before the delay
        Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation, bullletContainer);
        canShoot = false;
        Debug.Log(bullletContainer.childCount + " total bullet(s).");

        // The delay
        yield return new WaitForSeconds(shotCooldown);

        //anim.SetBool("Reloading", true)

        //yield return new WaitForSeconds(0.5f);

        // Stuff after the delay
        canShoot = true;
    }

    //IEnumerator SpawnWave()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Instantiate(bulletPrefab);
    //        yield return new WaitForSeconds(1);
    //    }
    //}


}
