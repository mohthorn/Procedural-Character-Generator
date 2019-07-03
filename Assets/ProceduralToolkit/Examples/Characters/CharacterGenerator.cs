using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace ProceduralToolkit.Examples
{
	/// <summary>
	/// 2D character generator
	/// </summary>
	/// <remarks>
	/// Sprites made by Kenney http://kenney.nl/
	/// </remarks>
	public class CharacterGenerator : MonoBehaviour
	{
		private int trait_len=7;
		public Character character;
		public TextAsset namesJson;
		public List<Sprite> hairSprites = new List<Sprite>();
		public List<Sprite> bodySprites = new List<Sprite>();
		public List<Sprite> headSprites = new List<Sprite>();
		public List<Sprite> chestSprites = new List<Sprite>();
		public List<Sprite> legsSprites = new List<Sprite>();
		public List<Sprite> feetSprites = new List<Sprite>();
		public List<Sprite> weaponSprites = new List<Sprite>();
		public List<Sprite> shieldSprites = new List<Sprite>();
		public TraitsSet traits=new TraitsSet();
		public List<int[]> hairtraits = new List<int[]>();
		public List<int[]> bodytraits = new List<int[]>();
		public List<int[]> headtraits = new List<int[]>();
		public List<int[]> chesttraits = new List<int[]>();
		public List<int[]> legstraits = new List<int[]>();
		public List<int[]> feettraits = new List<int[]>();
		public List<int[]> weapontraits = new List<int[]>();
		public List<int[]> shieldtraits = new List<int[]>();


		public int[] whiteBearlist = new int[] { 66, 67, 76, 77, 78, 79 };

		public int[] BrownBearlist = new int[] { 34, 35, 38, 39, 48, 52, 56, 58, 59, 60, 61, 62, 63 };

		public int[] youngbearlist = new int[] { 2, 3, 6, 7, 16, 20, 24, 25, 26, 27, 28, 29, 30, 31 };

		public int[] woman_whiteBearlist;
		public int[] woman_BrownBearlist; 
		public int[] woman_youngbearlist; 
		public int[] cautionhead;
		public int[] curioushead;
		public int[] orgnized_man_chestlist;
		public int[] unorgnized_man_chestlist; 
		public int[] orgnized_woman_chestlist;
		public int[] unorgnized_woman_chestlist; 
		public int[] womanBodylist;
		public int[] manBodylist;

		private NameGenerator nameGenerator;

        public void Write(string s)
        {
            string path = "Assets/Resources/args.txt";
            if(File.Exists(path))
                  File.Delete(path);
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.Flush();
            writer.WriteLine(s);
            writer.Close();
        }

        public bool SaveFileExists()
        {
            string path = "Assets/Resources/save.txt";
            if(File.Exists(path))
            {
                return true;
            }
            return false;
        }

        private void Awake()
		{
			whiteBearlist = new int[] { 66, 67, 76, 77, 78, 79 };

			BrownBearlist = new int[] { 34, 35, 38, 39, 48, 52, 56, 58, 59, 60, 61, 62, 63 };

			youngbearlist = new int[] { 2, 3, 6, 7, 16, 20, 24, 25, 26, 27, 28, 29, 30, 31 };
			womanBodylist = new int[] { 1,3,5,7};
			manBodylist = new int[] {0, 2, 4, 6 };

			woman_whiteBearlist = new int[] { 65, 69, 70, 71 };
			woman_BrownBearlist = new int[] { 33, 41, 42, 43 };
			woman_youngbearlist = new int[] { 1, 5, 9, 10, 11, 13, 14, 15 };
			cautionhead = new int[] {0, 1, 2,3, 4, 5, 6,7,8,9,10,11,12,13 ,14,15,16,17,18,19,20,21,22,23};
			curioushead = new int[] {24,25,26,27,28,29,30,31,32,33,34,35 };

			orgnized_man_chestlist = new int[]{1,2,4,5,6,8,14,16,18,20,38};
			unorgnized_man_chestlist = new int[]{4,8,13,17,40,73,77,81,113,115};
			orgnized_woman_chestlist = new int[]{3,7,9,10,12,22,24,25,26,29,30,33,34,37,38,39,47};
			unorgnized_woman_chestlist = new int[]{27,28,31,32,35,36,48};
			nameGenerator = new NameGenerator(namesJson);
			for (int i = 0; i < hairSprites.Count; i++) { hairtraits.Add(new int[]{1, 20, 5, 5, 5, 5, 5}); }
			for (int i = 0; i < bodySprites.Count; i++) { bodytraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < headSprites.Count; i++) { headtraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < chestSprites.Count; i++) { chesttraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < legsSprites.Count; i++) { legstraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < feetSprites.Count; i++) { feettraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < weaponSprites.Count; i++) { weapontraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }
			for (int i = 0; i < shieldSprites.Count; i++) { shieldtraits.Add(new int[] { 1, 20, 5, 5, 5, 5, 5 }); }


			//hair
			for(int i = 64; i < 80; i++)
			{
				hairtraits[i][1] = 50;
			}
			for(int i = 32; i < 64; i++)
			{
				hairtraits[i][1] = 35;
			}
			for(int i = 0; i < 32; i++)
			{
				hairtraits[i][1] = 20;
			}

			int[] male = { 3, 4, 7, 8, 17, 21, 25, 26, 27, 28, 29, 30, 31, 32};
			for(int i = 0; i < male.Length; i++)
			{
				hairtraits[male[i] - 1][0] = 1;
				hairtraits[male[i] + 31][0] = 1;
			}
			hairtraits[66][0] = 1;
			hairtraits[67][0] = 1;
			hairtraits[76][0] = 1;
			hairtraits[77][0] = 1;
			hairtraits[78][0] = 1;
			hairtraits[79][0] = 1;


			//chest
			int[] rd = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			for(int i = 0; i < chestSprites.Count; i++)
			{
				chesttraits[i][2] = rd.GetRandom();
				chesttraits[i][3] = rd.GetRandom();
				chesttraits[i][4] = rd.GetRandom();
				chesttraits[i][5] = rd.GetRandom();
				chesttraits[i][6] = rd.GetRandom();
			};


			traits.gender = 0;// 1 male; 0 female
			traits.Age = 25;

			traits.O = 6;
			traits.C = 6;
			traits.E = 6;
			traits.A = 6;
			traits.N = 6;
		}
		public void Update()
		{
			traits.Age = Final.age;
			traits.gender = Final.gender;
			traits.O = Final.cur_car;
			traits.C = Final.ori_car;
			traits.E = Final.fri_cha;
			traits.A = Final.ene_res;
			traits.N = Final.ner_con;
		}


		public void Generate()
		{

            float hairTransform = Random.value * 0.4f;  //scale to 0-0.4
            float headTransform = Random.value * 0.4f;  //scale to 0-0.4
			float bodyTransform = (traits.A*(Random.value*0.2f+0.8f) * 0.4f)/10.0f;  //scale to 0-0.4
			float chestTransform = Random.value;        //scale to 0-1
			float legsTransform = Random.value * 0.1f;  //scale to 0-0.1,position -0.05-0.05
			float bodyScoreH = bodyTransform + 0.8f;
            int hairNum = 0;
            int bodyNum = 0;
            int headNum = 0;
            int chestNum = 0;
            int legsNum = 0;
            int feetNum = 0;
            int weaponNum = -1;
            int shieldNum = -1;

            if (!SaveFileExists())
            {

                character.bodyRenderer.transform.localScale = new Vector3(1f, bodyScoreH, 1f);
                character.hairRenderer.transform.localScale = new Vector3(1f, (0.8f + hairTransform) * bodyScoreH, 1f);
                character.headRenderer.transform.localScale = new Vector3(1f, (0.8f + headTransform) * bodyScoreH, 1f);
                character.chestRenderer.transform.localScale = new Vector3(1f, (0.5f + chestTransform) * bodyScoreH, 1f);
                character.legsRenderer.transform.localPosition = new Vector3(0f, -(0.05f - legsTransform) / 10 * bodyScoreH, 0f);
                character.legsRenderer.transform.localScale = new Vector3(1f, (0.95f + legsTransform) * bodyScoreH, 1f);
                if (bodyScoreH > 1)
                {
                    character.feetRenderer.transform.localPosition = new Vector3(0f, (1 - bodyScoreH) / 8, 0f);
                }
                else
                {
                    character.feetRenderer.transform.localPosition = new Vector3(0f, (1 - bodyScoreH) / 20, 0f);
                }



                if (traits.gender == 2)
                { //male


                    bodyNum = manBodylist.GetRandom();
                    character.bodyRenderer.sprite = bodySprites[bodyNum];

                    if (traits.Age > 50)
                    {
                        print("here");
                        hairNum = whiteBearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                    else if (traits.Age > 25)
                    {
                        hairNum = BrownBearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                    else
                    {
                        hairNum = youngbearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                }
                else if (traits.gender == 0) //female
                {
                    bodyNum = womanBodylist.GetRandom();
                    character.bodyRenderer.sprite = bodySprites[bodyNum];
                    if (traits.Age > 50)
                    {
                        hairNum = woman_whiteBearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                    else if (traits.Age > 25)
                    {
                        hairNum = woman_BrownBearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                    else
                    {
                        hairNum = woman_youngbearlist.GetRandom();
                        character.hairRenderer.sprite = hairSprites[hairNum];
                    }
                }

                if (traits.O > 3)
                {
                    headNum = cautionhead.GetRandom();
                    character.headRenderer.sprite = headSprites[headNum];
                }
                else
                {
                    headNum = curioushead.GetRandom();
                    character.headRenderer.sprite = headSprites[headNum];
                }




                if (traits.C < 3)
                {
                    if (traits.gender == 2)
                    {
                        chestNum = orgnized_man_chestlist.GetRandom();
                        character.chestRenderer.sprite = chestSprites[chestNum];
                    }
                    else
                    {
                        chestNum = orgnized_woman_chestlist.GetRandom();
                        character.chestRenderer.sprite = chestSprites[chestNum];
                    }
                }

                else
                {
                    if (traits.gender == 2)
                    {
                        chestNum = unorgnized_man_chestlist.GetRandom();
                        character.chestRenderer.sprite = chestSprites[chestNum];
                    }
                    else
                    {
                        chestNum = unorgnized_woman_chestlist.GetRandom();
                        character.chestRenderer.sprite = chestSprites[chestNum];
                    }
                }


                if (traits.E > 3)
                {
                    character.weaponRenderer.enabled = true;
                    weaponNum = (int)(weaponSprites.Count * Random.value);
                    character.weaponRenderer.sprite = weaponSprites[weaponNum];
                }
                else
                {
                    character.weaponRenderer.enabled = false;
                    //character.weaponRenderer.sprite = weaponSprites.GetRandom ();
                }

                if (traits.N > 3)
                {
                    character.shieldRenderer.enabled = true;
                    shieldNum = (int)(shieldSprites.Count * Random.value);
                    character.shieldRenderer.sprite = shieldSprites[shieldNum];
                }
                else
                {
                    character.shieldRenderer.enabled = false;
                }
                feetNum = (int)(feetSprites.Count * Random.value);
                character.feetRenderer.sprite = feetSprites[feetNum];
                legsNum = (int)(legsSprites.Count * Random.value);
                character.legsRenderer.sprite = legsSprites[legsNum];

                string saveString = hairNum.ToString() + " ";
                saveString += headNum.ToString() + " ";
                saveString += bodyNum.ToString() + " ";
                saveString += chestNum.ToString() + " ";
                saveString += legsNum.ToString() + " ";
                saveString += feetNum.ToString() + " ";
                saveString += weaponNum.ToString() + " ";
                saveString += shieldNum.ToString() + " ";
                saveString += hairTransform.ToString() + " ";
                saveString += headTransform.ToString() + " ";
                saveString += chestTransform.ToString() + " ";
                saveString += legsTransform.ToString() + " ";
                saveString += bodyScoreH.ToString() + " ";
                Write(saveString);
            }
            else
            {
                string savePath= "Assets/Resources/save.txt";
                StreamReader reader = new StreamReader(savePath);
                hairNum = reader.Read();
                print(hairNum);
                headNum = reader.Read();
                bodyNum = reader.Read();
                chestNum = reader.Read();
                legsNum = reader.Read();
                feetNum = reader.Read();
                weaponNum = reader.Read();
                print(weaponNum);
                shieldNum = reader.Read();
                print(shieldNum);
                hairTransform = reader.Read();
                headTransform = reader.Read();
                chestTransform = reader.Read();
                legsTransform = reader.Read();
                bodyScoreH = reader.Read();
                character.hairRenderer.sprite = hairSprites[hairNum];
                character.headRenderer.sprite = headSprites[headNum];
                character.chestRenderer.sprite = chestSprites[chestNum];
                character.bodyRenderer.sprite = bodySprites[bodyNum];
                character.legsRenderer.sprite = legsSprites[legsNum];
                character.feetRenderer.sprite = feetSprites[feetNum];
                character.bodyRenderer.transform.localScale = new Vector3(1f, bodyScoreH, 1f);
                character.hairRenderer.transform.localScale = new Vector3(1f, (0.8f + hairTransform) * bodyScoreH, 1f);
                character.headRenderer.transform.localScale = new Vector3(1f, (0.8f + headTransform) * bodyScoreH, 1f);
                character.chestRenderer.transform.localScale = new Vector3(1f, (0.5f + chestTransform) * bodyScoreH, 1f);
                character.legsRenderer.transform.localPosition = new Vector3(0f, -(0.05f - legsTransform) / 10 * bodyScoreH, 0f);
                character.legsRenderer.transform.localScale = new Vector3(1f, (0.95f + legsTransform) * bodyScoreH, 1f);
                File.Delete(savePath);
            }
        }
	}
}
