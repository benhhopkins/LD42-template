using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public Transform m_unitPrefab;
	
	[HideInInspector] public List<Unit> m_units;

	// Use this for initialization
	void Start () {
		Transform newUnit = Instantiate(m_unitPrefab);
		m_units.Add(newUnit.GetComponent<Unit>());
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Unit unit in m_units)
			unit.transform.position += new Vector3(0.05f, 0, 0);
	}
}
