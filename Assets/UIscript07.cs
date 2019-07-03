using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript07 : MonoBehaviour {
	public GameObject[] questionGroupArr;
	public QAclass07[] qaArr;
	public GameObject AnswerPanel;
	//public GameObject generator;
	public ProceduralToolkit.Examples.CharacterGeneratorConfigurator generator;

	// Use this for initialization
	void Start () {

		//ProceduralToolkit.Examples
		qaArr = new QAclass07[questionGroupArr.Length];
		//generatorComp = generator.GetComponent<ProceduralToolkit.Examples.ChairGeneratorConfigurator> ();

	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < qaArr.Length; i++) {
			qaArr [i] = ReadQuestionAndAnswer (questionGroupArr [i]);
		}
		if(qaArr[0].Answer=="feminine")
		{
			Final.gender =0;
		}
		else if(qaArr[0].Answer=="masculine")
		{
			Final.gender = 2;
		}
		if (qaArr [1].Answer != null)
			Final.age = int.Parse (qaArr [1].Answer);
		else
			Final.age = 0;
		Final.cur_car = int.Parse(qaArr [2].Answer);
		Final.ori_car = int.Parse(qaArr [3].Answer);
		Final.ene_res = int.Parse(qaArr [4].Answer);
		Final.fri_cha = int.Parse(qaArr [5].Answer);
		Final.ner_con = int.Parse(qaArr [6].Answer);
		Final.name = qaArr [7].Answer;
		
	}

	public void on_value_change(float slider_input)
	{
		
	}

	public void SubmitAnswer()
	{

		generator.Generate ();
	}

	QAclass07 ReadQuestionAndAnswer(GameObject questionGroup)
	{
		QAclass07 result = new QAclass07 ();
		GameObject q = questionGroup.transform.Find ("question").gameObject;
		GameObject a = questionGroup.transform.Find ("answers").gameObject;

		result.Question = q.GetComponent<Text> ().text;
		result.Answer = "0";
		if (a.GetComponent<ToggleGroup> () != null) {
			for (int i = 0; i < a.transform.childCount; i++) {
				if (a.transform.GetChild (i).GetComponent<Toggle> ().isOn) {
					result.Answer = a.transform.GetChild (i).Find ("Label").GetComponent<Text> ().text;
					break;
				}
			}

		} else if (a.GetComponent<InputField> () != null) {
			result.Answer = a.transform.Find ("Text").GetComponent<Text> ().text;
			if (result.Answer == "")
				result.Answer = "0";

		} else if (a.GetComponent<Slider> () != null) {
			result.Answer = a.GetComponent<Slider> ().value.ToString ();
		} else {
			result.Answer = "0";
		}
			

		return result;
		
	}
}

[System.Serializable]
public class QAclass07
{
	public string Question ;
	public string Answer ;

}
