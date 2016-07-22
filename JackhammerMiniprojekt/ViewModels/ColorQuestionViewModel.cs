using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.ViewModels
{
	public class ColorQuestionViewModel
	{
		public string Question { get; set; }
		public bool? AnswerCorrect { get; set; }
		public List<Color> AnswerAlternatives { get; set; }

		public bool SetAnswerAlternatives()
		{
			List<Color> allAvailableColors = new List<Color>
			{
				Color.Blue,
				Color.Green,
				Color.Orange,
				Color.Pink,
				Color.Purple,
				Color.Red,
				Color.Yellow,
				Color.Turquoise
			};

			Random rand = new Random();
			Color correctColor = allAvailableColors.ElementAtOrDefault(rand.Next(allAvailableColors.Count));
			Question = correctColor.Name;
			int correctAnswer = rand.Next(0, 3);
			allAvailableColors.Remove(correctColor);
			AnswerAlternatives = new List<Color>();
			for (int i = 0; i < 4; i++ )
			{
				if (i == correctAnswer)
				{
					AnswerAlternatives.Add(correctColor);
				}
				else
				{
					int useColor = rand.Next(allAvailableColors.Count - 1);
					AnswerAlternatives.Add(allAvailableColors.ElementAtOrDefault(useColor));
					allAvailableColors.RemoveAt(useColor);
				}
			}
			if (AnswerAlternatives.Count == 4 && AnswerAlternatives.Contains(correctColor) && AnswerAlternatives.Count == AnswerAlternatives.Distinct().Count())
				return true;
			else
				return false;
		}
	}
}