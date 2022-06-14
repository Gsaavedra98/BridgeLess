using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public GameObject target;
    public float speed;
    bool grow = true;
    bool jump = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0) && grow)
        {
            this.transform.localScale += new Vector3(0f, 1.4f * Time.deltaTime);
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && grow)
        {
            grow = false;
            this.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(200f, 0f),  new Vector2(this.GetComponent<Rigidbody2D>().centerOfMass.y + this.transform.position.y, this.transform.position.x));
            
        }
        if (!grow)
        {

            StartCoroutine(Move());

        }
        
        
        
    }

    

    IEnumerator Move()
    {
        float step = speed * Time.deltaTime;
        yield return new WaitForSeconds(5f);
        
        GameObject.Find("Player").transform.position = Vector3.MoveTowards(GameObject.Find("Player").transform.position, target.transform.position, step);
        if (!jump)
        {
            Instantiate(target, target.transform.position, Quaternion.identity);
            GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            jump = true;
        }
    }
}
