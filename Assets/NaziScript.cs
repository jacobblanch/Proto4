using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaziScript : MonoBehaviour {

    public GameObject retort;
    public GameObject player;
    public float force;
    public Camera m_Camera;
    bool billboarding = true;
    bool beenHit;
    public AudioSource ouchSound;
    public Rigidbody rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        Debug.Log("Billboarding = " + billboarding);
        if (Vector3.Distance(transform.position, player.transform.position) <= 8f)
            if (!retort.activeInHierarchy)
                if (!beenHit)
                    retort.SetActive(true);
        if (Vector3.Distance(transform.position, player.transform.position) <= 2f)
            rb.isKinematic = false;

        if (billboarding)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            billboarding = false;
            beenHit = true;
            retort.SetActive(false);
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
            ouchSound.Play();
        }
    }
}
