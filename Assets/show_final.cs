using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_final : MonoBehaviour {

	public  string name;
	public  int gender =1 ;
	public  int age =20;
	public  int cur_car =5;
	public  int ori_car =5;
	public  int ene_res =5;
	public  int fri_cha = 5;
	public  int ner_con =5 ;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		age = Final.age;
		gender = Final.gender;
		cur_car = Final.cur_car;
		ori_car = Final.ori_car;
		ene_res = Final.ene_res;
		fri_cha = Final.fri_cha;
		ner_con	= Final.ner_con;
		name = Final.name;

		
	}
}
