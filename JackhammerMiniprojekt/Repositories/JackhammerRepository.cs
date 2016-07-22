using JackhammerMiniprojekt.DataAccess;
using JackhammerMiniprojekt.Models;
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
			var Questions =  _dbContext.Questions.Where(q => q.Category == category).ToList();
			if (Questions.Count == 0)
				return null;

			var rand = new Random();
			return Questions.ElementAtOrDefault(rand.Next(0, Questions.Count - 1));
		}

		public ColorQuestionViewModel GetColorQuestion()
		{
			ColorQuestionViewModel resultQuestion = new ColorQuestionViewModel();

			resultQuestion.SetAnswerAlternatives();

			return resultQuestion;
		}
	}
}