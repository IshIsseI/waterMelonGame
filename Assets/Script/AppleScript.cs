using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public GameObject Pear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Apple")
        {
            if(string.Compare(this.gameObject.name, collision.gameObject.name) < 0)
            {
                Instantiate(Pear, Vector2.Lerp(this.gameObject.transform.position, collision.gameObject.transform.position, 0.5f), Quaternion.identity);
                GameObject fruits_clone = GameObject.Find("Pear(Clone)");
                fruits_clone.name = "Fruits" + MainScript.i;
                MainScript.i++;
                MainScript.Pear_S++;
            }
            Destroy(this.gameObject);
        }  
    }
}
