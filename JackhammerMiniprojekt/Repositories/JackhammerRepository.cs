using JackhammerMiniprojekt.DataAccess;
using JackhammerMiniprojekt.Models;
//using JackhammerMiniprojekt.ViewModels;
using JackhammerMiniprojekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JackhammerMiniprojekt.Repositories
{

	public class JackhammerRepository
	{
		JackhammerContext _dbContext;
		public JackhammerRepository()
		{
			_dbContext = new JackhammerContext();
		}
		public JackhammerRepository(JackhammerContext inContext)
		{
			_dbContext = inContext;
		}

		public IEnumerable<Question> GetQuestions(int category)
		{
			return _dbContext.Questions.Where(q => q.Category == category);
		}

		public Question GetQuestion(int category)
		{
			var Questions = _dbContext.Questions.Where(q => q.Category == category).ToList();
			if (Questions.Count == 0)
				return null;

			var rand = new Random();
			return Questions.ElementAtOrDefault(rand.Next(0, Questions.Count)); //ändrat .Count - 1 till .Count för att se om det kan göra att får annan fråga /Magnus
		}

		public Question GetQuestionByID(int ID) //Lagt till för att kunna plock ut fråga utifrån ID. /Magnus
		{
			return _dbContext.Questions.FirstOrDefault(q => q.ID == ID);
		}

		public ColorQuestionViewModel GetColorQuestion()
		{
			ColorQuestionViewModel resultQuestion = new ColorQuestionViewModel();

			resultQuestion.SetAnswerAlternatives();

			return resultQuestion;
		}

		public WordsQuestionViewModel GetWordQuestion()
		{
			Question question = GetQuestion(2);
			WordsQuestionViewModel result = new WordsQuestionViewModel();
			result.Words = question.QuestionString.Split(',').ToList();

			return result;
		}

		public WordsQuestionViewModel CheckWordsAnswer(WordsQuestionViewModel answer)
		{
			int points = 0;
			List<string> answers = answer.Answer.ToLower().Split(' ').ToList();
			List<string> missingWords = new List<string>();
			foreach (string word in answer.Words)
			{
				if (answers.Contains(word.ToLower()))
				{
					answers.Remove(word);
					points++;
				}
				else
				{
					missingWords.Add(word);
				}
			}
			string invalidWords = "";
			foreach (string word in answers)
			{
				invalidWords += word + " ";
			}
			return new WordsQuestionViewModel { Words = missingWords, Answer = invalidWords, Points = points, ShowResult = true };
		}

		public FiveQuestionsViewModel FiveQuestionGetNext(int category, int questionDone, int points, int lastQuestion, int currentQuestion, string answer, string questionString)
		{
			if (category > 0 && questionDone <= 5)
			{
				string QuestionAnswer = GetQuestionByID(currentQuestion).Answer;
				int pointsFromAnswer = CheckAnswer(category, QuestionAnswer, answer);

				var q = GetQuestion(category);
				while (q.ID == lastQuestion)
				{
					q = GetQuestion(category);
				}
				FiveQuestionsViewModel model = new FiveQuestionsViewModel();
				model.Category = category;
				model.Answer = "";
				model.QuestionDone = questionDone + 1;
				model.Points = points + pointsFromAnswer;
				model.LastQuestion = lastQuestion;
				model.QuestionString = q.QuestionString;
				model.LastQuestion = currentQuestion;
				model.CurrentQuestion = q.ID;
				return model;
			}
			else
			{
				FiveQuestionsViewModel model = new FiveQuestionsViewModel();
				model.Category = category;
				model.Answer = "";
				model.QuestionDone = questionDone;
				model.Points = points;
				model.LastQuestion = lastQuestion;
				model.QuestionString = questionString;
				model.LastQuestion = lastQuestion;
				model.CurrentQuestion = currentQuestion;
				return model;
			}
		}

		private int CheckAnswer(int Category, string expectedAnswer, string answered)
		{
			switch (Category)
			{
				case 1:
					if (expectedAnswer.Trim().ToLower() == answered.Trim().ToLower())
						return 1;
					else
						return 0;
				default:
					break;
			}

			return 0;
		}

		public int CheckPlaceHighscore(int Category, int Points)
		{
			//var highscoresOver = _dbContext.Highscores.Where(v => v.Score > Points).OrderByDescending(v => v.Rank);
			//int Highest = highscoresOver.First().Rank;
			//if (Highest)
			//var Rank = _dbContext.Highscores.Where(v => v.Score <= Points && v.Score);
			return 0;
		}
		public void AddHighscore(string Name, int Category, int Points)
		{
			Highscore hig = new Highscore();
			hig.Date = DateTime.Now;
			hig.Category = Category;
			hig.Score = Points;
			hig.Name = Name;

			_dbContext.Highscores.Add(hig);
			_dbContext.SaveChanges();
		}

		public IEnumerable<Highscore> ShowHighscore(int Category)
		{
			var highscores = _dbContext.Highscores.Where(high => high.Category == Category)
												  .OrderByDescending(high => high.Score)
												  .ThenByDescending(high => high.Date)
												  .Take(10);
			return highscores;
		}
	}
}