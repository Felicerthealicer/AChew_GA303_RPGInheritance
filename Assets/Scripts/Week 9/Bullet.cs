using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject bulletPreFab;
    public Transform bulletSpawnPosition;
    public float force = 500;
    public float bulletCount = 5f;

    public TextMeshProUGUI bulletText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (bulletCount > 0)
            {
                GameObject bullet = Instantiate(bulletPreFab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force);
                bulletCount -= 1;

                Destroy(bullet, 3f);
            }
        }

        bulletText.text = "Bullets Left: " + bulletCount.ToString();

    }

}
