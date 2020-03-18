using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMagicCollisionSound : MonoBehaviour
{
    public AudioClip SwordAndMagicCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("leftarrow");
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Magic")
        {
            GetComponent<AudioSource>().PlayOneShot(SwordAndMagicCollision);
            Debug.Log("atatta");
        }
    }
    
}
