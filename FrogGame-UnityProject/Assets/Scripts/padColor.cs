using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padColor : MonoBehaviour {
    private Renderer renderer;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected) {
            renderer.material.color = Color.red;
        }

        if(!isSelected) {
            renderer.material.color = Color.green;
        }
    }
}


