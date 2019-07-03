using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CharacterSave : MonoBehaviour {

	// Use this for initialization
	public void Save ()
    {
       string path = "Assets/Resources/args.txt";
        string savePath = "Assets/Resources/save.txt";
        File.Delete(savePath);
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(savePath, true);
        StreamReader reader = new StreamReader(path);
        string s=reader.ReadLine();
        writer.WriteLine(s);
        writer.Close();
        reader.Close();
        File.Delete(path);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
