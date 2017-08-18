using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class NaziScript : MonoBehaviour {

    public GameObject retort;
    public GameObject player;
    public float force;
    public Camera m_Camera;
    bool billboarding = true;
    bool beenHit;
    public AudioSource ouchSound;
    public Rigidbody rb;
    GameController gameManagerScript;
    public float timer;
    public float timeLimit;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        gameManagerScript = player.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (beenHit)
            timer += Time.deltaTime;

        if (!GetComponent<Renderer>().isVisible)
        {
            if (timer > timeLimit)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.x);
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                timer = 0;
                beenHit = false;
                retort.SetActive(false);
                billboarding = true;
                rb.isKinematic = true;
            }
        }

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
            if (beenHit == false)
            {
                billboarding = false;
                beenHit = true;
                retort.SetActive(false);
                Vector3 dir = collision.contacts[0].point - transform.position;
                dir = -dir.normalized;
                GetComponent<Rigidbody>().AddForce(dir * force);
                ouchSound.Play();
                Analytics.CustomEvent("naziPunched");
            }
        }
    }
}
