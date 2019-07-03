using UnityEngine;

public class TraitsSet
{
    public string name;
	public int gender=1; //feminine, neutral, masculine; 0, 1, 2
    //feminine should have more diverse features, may be a thin waist is enough for pixel avatars
    //feminine can be more likely to wear dress-like clothes, masculine may have those shields and swords.
    public int Age=20;//example: 16 means 16 years old)
    public int O=5;//Curious-Cautious, higher score means more curious
          //Curious avatar should have exaggerated features such as bigger feet, bigger hands but thin limbs and neck
          //month should be exaggerated, eyes do not need to be big but should be kind of staring-looking
          //curious avatars can have strange hair and beard

    public int C=5;//Organized-Careless, higher score means more organized
          //More in props
          //Organized avatars can have more mundane looking clothes and hats
          //Careless avatars can have belly-revealing and strange color-matching clothes 

    public int E=5;//Energetic-Reserved, higher score means energetic
          //Similar to O, should have energetic eyes.
          //Mouth can be exaggerated and big
          //Bigger feet and hands but thin limbs
          //slightly fancy looking clothes and helmets and small mustache
          //Reserved avatar may have sleepy eyes and heavier lower body

    public int A=5;//Friendly-Challenging, higher score means friendly
          //Friendliness can be in many ways, maybe challenging avatar can be done with a heavier looking body
          //A heavier avatar should have larger upper body, long strong arms and short heavy legs.
          //Head should have a relatively small proportion
          //glaring eyes

    public int N=5;//Nervous-Confident, higher score means nervous
          //A high nervous score should mean more tiring-looking eyes similar to those in a reserved avatar
          //maybe more bigger shields and heavier armor to represent insecurity?
    public double DIST(TraitsSet target)
    {
        double result = 0.0;
        result += (double)(Mathf.Abs(Age - target.Age))/100.0;
        result += (double)(Mathf.Abs(gender - target.gender)) / 2.0;
        result += (double)(Mathf.Abs(O - target.O)) / 10.0;
        result += (double)(Mathf.Abs(C - target.C)) / 10.0;
        result += (double)(Mathf.Abs(E - target.E)) / 10.0;
        result += (double)(Mathf.Abs(A - target.A)) / 10.0;
        result += (double)(Mathf.Abs(N - target.N)) / 10.0;

        return result;
    }

    public double DIST(int[] target)
    {
        double result = 0.0;
        result += (double)(Mathf.Abs(Age - target[1])) / 100.0;
        result += (double)(Mathf.Abs(gender - target[0])) / 2.0;
        result += (double)(Mathf.Abs(O - target[2])) / 10.0;
        result += (double)(Mathf.Abs(C - target[3])) / 10.0;
        result += (double)(Mathf.Abs(E - target[4])) / 10.0;
        result += (double)(Mathf.Abs(A - target[5])) / 10.0;
        result += (double)(Mathf.Abs(N - target[6])) / 10.0;

        return result;
    }
}

