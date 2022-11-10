using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBox : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
