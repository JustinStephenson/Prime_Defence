using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHandler : MonoBehaviour {

    public GameObject shot;
    public GameObject ImageColor;
    public AmmoHandler ammo;
    public Transform shotSpawn;

    private AudioSource myAudio;

    public float fireSpeed = 0.0f;
    private float nextShot = 0.0f;

    public static bool ableToFire = false;
   
    public Color ammoColor;

    //public float speed;
    //public float maxRotation;

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
	}

	void Update()
    {
        //Makes Cannon move by itself mimicing a sinwave pattern.
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, maxRotation * Mathf.Sin(Time.time * speed));

        ImageColor.GetComponent<SpriteRenderer>().color = ammoColor;
        GetComponent<SpriteRenderer>().color = ammoColor;

        if (Input.touchCount > 0 && ClickToFire.touchedFireScreen)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;

            ClickToFire.touchedFireScreen = false;
        }

        if (Time.time > nextShot)
        {
            ableToFire = true;
            
            if (ClickToFire.cannonFired)
            {
                myAudio.Play();

                //This is for firerate.
                nextShot = Time.time + fireSpeed;

                //Picks Color from array "Ammo" and puts it on Instantated Gameobject.
                GameObject newShot = Instantiate(shot, shotSpawn.position, transform.rotation) as GameObject;
                newShot.GetComponent<SpriteRenderer>().color = ammoColor;

                //Reset bool for cannonFired.
                ClickToFire.cannonFired = false;
                ableToFire = false;
            }
        } 
	}
}