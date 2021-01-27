using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFaust : MonoBehaviour
{
    
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On collision Enter", collision.gameObject);
        if (collision.gameObject.CompareTag("Explosion"))
        {
        
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}
