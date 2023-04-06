using System;
namespace ArrayTutorial
{
	public class HelloCollection
	{
		public IEnumerator<string> GetEnumerator()
		{
			yield return "Hello";
			yield return "World";
		}
	}
}

