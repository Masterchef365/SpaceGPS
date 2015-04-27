using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ImportRoids : MonoBehaviour {
	public GameObject prefab;
	public List<string> textElements = new List<string>();
	public List<Vector3> posElements = new List<Vector3>();

	void Start () {
		ArrayList coordList = new ArrayList ();
		FileStream f = new FileStream("gps.txt", FileMode.Open);
		StreamReader reader = new StreamReader(f);
		while (true)
		{
			string line = reader.ReadLine();
			if (line == "")
			{
				break;
			}
			else
			{
				coordList.Add(line);
			}
		}
		for (int i = 0; i < coordList.Count; i++)
		{
			string[] coord = coordList[i].ToString().Split(':');
			float x,y,z;
			string name = coord[1];
			float.TryParse(coord[2], out x);
			float.TryParse(coord[3], out y);
			float.TryParse(coord[4], out z);
			Vector3 pos = new Vector3(x/10000f,y/10000f,z/10000f);
			GameObject roid = (GameObject)GameObject.Instantiate(prefab.gameObject, pos, Quaternion.identity);
			roid.name = name;
			textElements.Add(name);
			posElements.Add(pos);
		}
	}

	void OnGUI () {
		for (int i = 0; i < textElements.Count; i ++) {
			Vector3 actualPos = posElements[i];
			Vector3 marker = gameObject.GetComponent<Camera>().WorldToScreenPoint(actualPos);
			//if () {
				GUI.Label(new Rect(marker.x, Screen.height - marker.y, 100,100), textElements[i]);
			//}
		}
	}

}
