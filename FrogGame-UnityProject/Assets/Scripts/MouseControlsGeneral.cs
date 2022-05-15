using System.Collections;  
using UnityEngine;
using UnitLibrary;

public class MouseControlsGeneral: MonoBehaviour {  
  
  new private Renderer renderer;

  public Tile selectedTile;
  public padColor selectedPad;

  void Update() 
  {  
    if (Input.GetMouseButtonDown(0))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
      RaycastHit hit;

      if ((!Physics.Raycast(ray, out hit) || (hit.transform.tag != "tile"))) {Reset(); return;}

      Tile tile = hit.transform.gameObject.GetComponent<Tile>();
      if (!tile) {Reset(); return;}

      if (selectedTile && selectedTile.GetComponent<Unit>().AttemptAction(tile)) {Reset(); return;}
 
      selectedTile = tile;
      padColor pad = tile.GetComponentInChildren<padColor>();
      selectedPad = pad;
      selectedPad.isSelected = true;
    }
  }

  void Reset()
  {
    selectedPad.isSelected = false;
    selectedTile = null;
    selectedPad = null;
  }
}