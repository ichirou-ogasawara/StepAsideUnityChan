using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestructor : MonoBehaviour
{
    public GameObject unitychan;

    private float unitychanPos;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        this.unitychanPos = this.unitychan.transform.position.z;
        
        if (this.gameObject.transform.position.z < unitychanPos)
        {
            Destroy (this.gameObject, 0.5f);
        }
    }
}
