using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptSenseiFromFile : MonoBehaviour {

	public string langFile;
	public string[] script_master;
	public Sprite[] spr_penguin;

	public int index;

	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader(Application.dataPath + "/Dialog/" + langFile);
		string script = reader.ReadToEnd ();
		reader.Close ();
		script_master = script.Split ("\n".ToCharArray());
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && index < 27) {
			index++;
		}
			
		if (index >= 27) {
			SceneManager.LoadScene ("Game");
		}

		this.gameObject.GetComponent<Text> ().text = script_master [index];

		if (index == 1 || index == 4 || index == 5 || index == 7 || index == 8 || index == 10 || index == 15 || index == 16 ||  index == 20 ||  index == 24) {
			GameObject.Find ("Penguin_spr").GetComponent <Image> ().sprite = spr_penguin [1];
		} else if (index == 0 || index == 3 || index == 6 || index == 9 || index == 11 || index == 12 || index == 14 || index == 17 ||index == 18 ||index == 22 || index == 26) {
			GameObject.Find ("Penguin_spr").GetComponent <Image> ().sprite = spr_penguin [0];
		} else if (index == 2|| index == 13|| index==19|| index==21|| index==23|| index == 25) {
			GameObject.Find ("Penguin_spr").GetComponent <Image> ().sprite = spr_penguin [2];
		} 


	}
}
