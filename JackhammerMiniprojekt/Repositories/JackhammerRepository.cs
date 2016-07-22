using JackhammerMiniprojekt.DataAccess;
using JackhammerMiniprojekt.Models;
using System;
using System.Collections.Generic;
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
			return Questions.ElementAtOrDefault(rand.Next(0, Questions.Count)); //ändrat .Count - 1 till .Count för att se om det kan göra att får annan fråga /Magnus
		}

		public Question GetQuestionByID(int ID) //Lagt till för att kunna plock ut fråga utifrån ID. /Magnus
		{
			return _dbContext.Questions.FirstOrDefault(q => q.ID == ID);
		}
	}
}