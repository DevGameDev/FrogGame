using System.Collections;  
using UnityEngine;
using UnitLibrary;

public class MouseControlsGeneral: MonoBehaviour
{
  new private Renderer renderer;

  public Tile selectedTile;
  public Unit selectedUnit;
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

      if (selectedTile && selectedUnit && !selectedUnit.isEnemy)
      {
        Vector2Int newTilePos = tile.GetPosition();
        Vector2Int oldTilePos = selectedTile.GetPosition();
        Vector2Int tileOffset = new Vector2Int (newTilePos.x - oldTilePos.x, newTilePos.y - oldTilePos.y);
        if (selectedUnit.actionPatterns.Contains(tileOffset) && selectedUnit.AttemptAction(tile)) Reset();
        return;
      }
 
      selectedTile = tile;

      Unit unit = tile.GetComponentInChildren<Unit>();
      if (unit && unit.isSelectable) selectedUnit = unit;

      padColor pad = tile.GetComponentInChildren<padColor>();
      if (pad)
      {
        selectedPad = pad;
        pad.isSelected = true;
        if (selectedUnit)
        {
          ChessBoardManager grid = selectedUnit.grid;
          Vector2Int tilePos = selectedTile.GetPosition();
          foreach (Vector2Int pattern in selectedUnit.actionPatterns)
          {
            int tileX = tilePos.x + pattern.x;
            int tileY = tilePos.y + pattern.y;
            Tile actionableTile = grid.SelectTile(tileX, tileY).GetComponent<Tile>();
            padColor actionablePad = actionableTile.GetComponentInChildren<padColor>();
            actionablePad.isSelected = true;
          }
        }
      }
    }
  }

  void Reset()
  {
    padColor[] pads = FindObjectsOfType<padColor>();
    foreach (padColor pad in pads) pad.isSelected = false;
    selectedTile = null;
    selectedPad = null;
  }
}