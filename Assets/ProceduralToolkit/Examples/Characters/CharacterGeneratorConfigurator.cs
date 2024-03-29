using UnityEngine;

namespace ProceduralToolkit.Examples
{
    public class CharacterGeneratorConfigurator : MonoBehaviour
    {
        public CharacterGenerator generator;
        public bool constantSeed = false;

        private void Start()
        {
            Generate();
        }

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Generate();
            //}
        }

        public void Generate()
        {
            if (constantSeed)
            {
                Random.InitState(0);
            }
            generator.Generate();
        }
    }
}
