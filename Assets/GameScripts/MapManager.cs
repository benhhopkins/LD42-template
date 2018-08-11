using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class MapManager : MonoBehaviour {

	[HideInInspector] public Grid m_grid;
	[HideInInspector] public Tilemap m_foregroundTilemap;
	[HideInInspector] public Tilemap m_backgroundTilemap;
	[HideInInspector] public Tilemap m_cursorTilemap;

	public RuleTile[] m_foregroundTileTypes;
	public RuleTile[] m_backgroundTileTypes;
	public RuleTile m_cursorTile;
	public Vector2Int m_mapStartingSize = new Vector2Int(100, 100);

    private Vector2Int m_mapSize;
    public Vector2Int MapSize
    {
        get
        {
            return m_mapSize;
        }
    }

    void Start () {
		m_grid = GetComponent<Grid>();
		m_foregroundTilemap = transform.Find("ForegroundTilemap").GetComponent<Tilemap>();
		m_backgroundTilemap = transform.Find("BackgroundTilemap").GetComponent<Tilemap>();
		m_cursorTilemap = transform.Find("CursorTilemap").GetComponent<Tilemap>();

		m_mapSize = m_mapStartingSize;

		if(m_foregroundTileTypes.Length > 0) {
			for(int x = 0; x < m_mapSize.x; x++) {
				for(int y = Random.Range(m_mapSize.y - 30, m_mapSize.y - 15); y > 0; y--) {
					m_foregroundTilemap.SetTile(new Vector3Int(x, y, 0), m_foregroundTileTypes[0]);
				}
			}
		}

		if(m_backgroundTileTypes.Length > 0) {
			for(int x = 0; x < m_mapSize.x; x++) {
				for(int y = Random.Range(m_mapSize.y - 20, m_mapSize.y - 10); y > 0; y--) {
					m_backgroundTilemap.SetTile(new Vector3Int(x, y, 0), m_backgroundTileTypes[0]);
				}
			}
		}

		m_cursorTilemap.SetTile(new Vector3Int(0, 0, 0), m_cursorTile);
	}
	
	void Update () {
		
		
	}

	public void SetCursorPosition(Vector3Int position) {
		m_cursorTilemap.transform.position = position;
	}
}
