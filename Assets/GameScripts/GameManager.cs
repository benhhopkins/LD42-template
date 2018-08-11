using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager I = null;

	[HideInInspector] public MapManager m_map;
	[HideInInspector] public UnitManager m_unitManager;

	void Awake() {
		// singleton
		if (I == null)
			I = this;
		else if (I != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		m_map = transform.Find("Map").GetComponent<MapManager>();
		m_unitManager = transform.Find("UnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MouseMove(Vector3 position)
	{
		Vector3Int positionInt = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
		m_map.SetCursorPosition(positionInt);
	}

	public void LeftClick(Vector3 position)
	{
		Vector3Int positionInt = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
		RuleTile tile = (RuleTile)m_map.m_foregroundTilemap.GetTile(positionInt);
 
		if (tile != null)
		{
			Debug.Log(string.Format("Tile is: {0}", tile.GetType()));
		}
	}

	public void RightClick(Vector2 position)
	{
		
	}
}
