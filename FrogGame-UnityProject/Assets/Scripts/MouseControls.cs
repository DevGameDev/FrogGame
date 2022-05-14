using System.Collections;  
using System.Collections;  
using UnityEngine;  
  
public class MouseControls: MonoBehaviour {  
  
  private Renderer renderer;
  public GameObject[] pads;
  void Start() 
  {
    pads = GameObject.FindGameObjectsWithTag("lilypad");
  }  
  
    
  void Update() 
  {  
    if (Input.GetMouseButtonDown(0)) {  
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
      RaycastHit hit;  
      if (Physics.Raycast(ray, out hit)) {  
           
        if (hit.transform.tag == "lilypad") {  
          foreach (GameObject pad in pads) {
            renderer = pad.GetComponent<Renderer>();
            renderer.material.color = Color.green;
          }
          renderer = hit.transform.GetComponent<Renderer>();
          renderer.material.color = Color.red;
          print("hit");  
        } 
      }  
    }  
  }  
} 
