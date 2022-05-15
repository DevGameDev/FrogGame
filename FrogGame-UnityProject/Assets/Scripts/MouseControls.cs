using System.Collections;  
using UnityEngine;  
  
public class MouseControls: MonoBehaviour {  
  
  new private Renderer renderer;
  public GameObject[] pads;
  public GameObject selectedPad;
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
           
        if (hit.transform.tag == "tile") {  
          foreach (GameObject pad in pads) {
            padColor padcolor = pad.GetComponent<padColor>();
            padcolor.isSelected = false;
          }
          //selectedPad = hit.transform.FindGameObjectsWithTag("lilypad");
          if (hit.transform.childCount > 0)
                {
                    // Add tile to list if it contains a child with the tag
                    foreach (Transform child in hit.transform)
                    {
                        if (child.gameObject.tag == "lilypad")
                        {
                          padColor padcolor = child.GetComponent<padColor>();
                          padcolor.isSelected = true;
                        }
                    }
                } 
        } 
      }  
    }  
  }  
} 
