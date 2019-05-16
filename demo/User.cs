using System;
using System.Text.RegularExpressions;

namespace demo
{
	public class User
	{

		string _name;
		string _password;

		public User(string name, string password)
		{
			_name = name;
			_password = password;
		}

		/// <summary>
		/// Validates all properties of this user. Throws exceptions if there are errors.
		/// </summary>
		public void Validate()
		{
			
			if (string.IsNullOrEmpty(_name))
				throw new Exception("The name must not be empty");

			ValidatePassword(_password);
		}

		int _minLength { get; set; } = 5;
		int _maxLength { get; set; } = 12;

		/// <summary>
		/// Validates the password. Throws an exception with the error if invalid
		/// </summary>
		/// <param name="password">Password.</param>
		private void ValidatePassword(string password)
		{
			//throw new Exception("test");

			string ErrorText = string.Empty;


			bool correctLength = !string.IsNullOrEmpty(password) && password.Length >= _minLength && password.Length <= _maxLength;
			if (!correctLength)
			{
				throw new Exception($"The password must be at least {_minLength} characters and at most {_maxLength} characters");
			}

			ValidateOneNumberOneLetter(password);

			ValidateSequences(password);
		}

		/// <summary>
		/// Validates the input has at least one number and one letter and no other non alpha-numeric characters.
		/// </summary>
		/// <param name="test">Test.</param>
		private void ValidateOneNumberOneLetter(string test)
		{

			Regex numericRegex = new Regex("[^0-9]");
			Regex alphaRegex = new Regex("[^a-zA-Z]");

			string numbers = numericRegex.Replace(test, string.Empty);
			string alphas = alphaRegex.Replace(test, string.Empty);

			if (string.IsNullOrEmpty(numbers) || string.IsNullOrEmpty(alphas) || numbers.Length + alphas.Length != test.Length)
				throw new Exception("The password must contain at least one number and one letter and no other non-aplanumeric characters");
		}

		/// <summary>
		/// validates that the input must not contain any sequence of characters immediately followed by the same sequence
		/// </summary>
		/// <param name="test">Test.</param>
		/// <param name="cont">Cont.</param>
		private void ValidateSequences(string test, string cont = "")
		{
			if (string.IsNullOrEmpty(test))
				return;

			for(int i = 0; i < test.Length; i++)
			{
				for(int j = 1; i + j < test.Length; j++)
				{
					string currSequence = test.Substring(i, j);
					string compare = test.Substring(i + j);
					if (compare.StartsWith(currSequence, StringComparison.CurrentCulture))
						throw new Exception($"Repeating sequences ({currSequence}).");
				}
			}
		}

		public override string ToString()
		{
			return _name;
		}

		public override bool Equals(object obj)
		{
			return obj.ToString().Equals(ToString());
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
	}
}
