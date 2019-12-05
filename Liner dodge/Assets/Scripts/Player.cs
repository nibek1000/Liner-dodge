using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    public float speed;
    private int whereIs = 0;
    public AudioSource Effects;
    public AudioClip A;
    public AudioClip B;

    public GameObject toSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!Input.GetKey(KeyCode.Mouse0))
        {
            float step = speed * Time.deltaTime;
            if (whereIs == 1 || whereIs == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetB.transform.position, step);
            }
            if (whereIs == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetA.transform.position, step);
            }


            if (transform.position == targetA.transform.position)
            {
                whereIs = 1;
                Effects.clip = A;
                //Effects.Play();
            }
            if (transform.position == targetB.transform.position)
            {
                whereIs = 2;
                Effects.clip = B;
                //Effects.Play();
            }
        }

    }
}
