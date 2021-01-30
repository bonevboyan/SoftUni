using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
			List<string> input = Console.ReadLine().Split(", ").ToList();
			string command = string.Empty;
			string action = string.Empty;
			string element = string.Empty;
			string lesson = string.Empty;
			int index = 0;
			string element1 = string.Empty;
			string firstLesson = string.Empty; 
			string secondLesson = string.Empty; 
			while (true)
			{
				command = Console.ReadLine();

				if (command == "course start")
				{
					break;
				}
				List<string> incomingDetails = command.Split(":").ToList();

				for (int i = 0; i < incomingDetails.Count; i++)
				{
					action = incomingDetails[0]; 
					element = incomingDetails[1];
					if (action == "Insert")
					{
						index = int.Parse(incomingDetails[2]);
						lesson = element; 
						break;
					}
					else if (action == "Swap")
					{
						string elementInsert = incomingDetails[2];  
						firstLesson = incomingDetails[1];
						secondLesson = incomingDetails[2];
						break;
					}
				}
				for (int k = 0; k < input.Count; k++)
				{
					if (action == "Add")
					{
						if (!input.Contains(element))
						{
							input.Add(element);
						}
					}
					else if (action == "Remove")
					{
						string excercise = element + '-' + "Exercise";
						if (input.Contains(element))
						{
							input.Remove(element);
						}
						if (input.Contains(excercise))
						{
							input.Remove(excercise);
						}
					}
					else if (action == "Exercise")
					{
						string excercise = element + '-' + "Exercise";
						if (!input.Contains(element))
						{
							if (!input.Contains(excercise)) 
							{
								input.Add(element);
								input.Add(excercise);
								break;
							}
							break;
						}
						else if (input.Contains(element) && !input.Contains(excercise)) 
						{
							int indexx = input.IndexOf(element);
							input.Insert(indexx + 1, excercise);
							break;
						}
					}
					else if (action == "Insert")
					{
						if (!input.Contains(lesson)) 
						{
							input.Insert(index, lesson);
							break;
						}
						break;
					}
					else if (action == "Swap") 
					{
						if (input.Contains(firstLesson) && input.Contains(secondLesson))
						{
							string excercise = firstLesson + '-' + "Exercise";
							int index1 = input.IndexOf(firstLesson); 
							int index2 = input.IndexOf(secondLesson); 
							string temp = firstLesson;
							input.RemoveAt(index1);
							input.Insert(index1, secondLesson);
							if (input.Contains(excercise))
							{
								input.Remove(excercise);
								input.Insert(index1 + 1, excercise);
							}
							excercise = string.Empty;
							excercise = secondLesson + '-' + "Exercise"; 
							input.RemoveAt(index2);
							input.Insert(index2, temp);
							if (input.Contains(excercise))
							{
								input.Remove(excercise);
								input.Insert(index1 + 1, excercise); 
							}
						}
						break;
					}
				}
			}
			for (int p = 0; p < input.Count; p++)
			{
				Console.WriteLine($"{p + 1}.{input[p]}");
			}
		}
    }
}
