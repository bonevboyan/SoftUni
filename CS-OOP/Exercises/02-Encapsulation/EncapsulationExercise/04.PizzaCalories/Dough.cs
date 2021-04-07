using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;


        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get => flourType;

            set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => bakingTechnique;

            set
            {
                var valueAsLower = value.ToLower();
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
        internal double GetDoughCalories()
        {
            double flourModifier = GetFlourTypeModifier(this.FlourType);
            double bakingModifier = GetBakingTechniqueModifier(this.BakingTechnique);

            double doughCalories = (2 * this.Weight) * flourModifier * bakingModifier;

            return doughCalories;
        }

        private double GetFlourTypeModifier(string flourType)
        {
            double flourModifier;
            if (flourType.ToLower() == "white")
            {
                flourModifier = 1.5;
            }
            else
            {
                flourModifier = 1.0;
            }

            return flourModifier;
        }

        private double GetBakingTechniqueModifier(string bakingTechnique)
        {
            double bakingTechniqueModifier = 0;

            if (bakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueModifier = 0.9;
            }
            else if (bakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueModifier = 1.1;
            }
            else if (bakingTechnique.ToLower() == "homemade")
            {
                bakingTechniqueModifier = 1.0;
            }

            return bakingTechniqueModifier;

        }
    }
}
