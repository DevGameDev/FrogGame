using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class MouseControls: MonoBehaviour {  
  
  private Renderer renderer;
  void Start() 
  {
  }  
  
    
  void Update() 
  {  
    if (Input.GetMouseButtonDown(0)) {  
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
      RaycastHit hit;  
      if (Physics.Raycast(ray, out hit)) {  
           
        if (hit.transform.name == "snake") {  
          
          renderer = hit.transform.GetComponent<Renderer>();
          renderer.material.color = Color.red;
          print("hit");  
        } 

        if (hit.transform.name == "plane") {  
          
          renderer = hit.transform.GetComponent<Renderer>();
          renderer.material.color = Color.blue;
          print("hit");  
        } 

        if (hit.transform.name == "Cube") {  
          
          renderer = hit.transform.GetComponent<Renderer>();
          renderer.material.color = Color.yellow;
          print("hit");  
        }

        if (hit.transform.name == "wings") {  
          
          renderer = hit.transform.GetComponent<Renderer>();
          renderer.material.color = Color.yellow;
          print("hit");  
        }  
      }  
    }  
  }  
} 
