// C# program to illustrate how 
// to create a sortedlist 
using System;
using System.Collections;

class SortedListDemo
{

	// Main Method 
	public static void Start()
	{

		// Creating a sortedlist 
		// Using SortedList class 
		SortedList my_slist1 = new SortedList();

		// Adding key/value pairs in 
		// SortedList using Add() method 
		my_slist1.Add(1.02, "This");
		my_slist1.Add(1.07, "Is");
		my_slist1.Add(1.04, "SortedList");
		my_slist1.Add("hey", "Tutorial");

		foreach (DictionaryEntry pair in my_slist1)
		{
			Console.WriteLine("{0} and {1}",
					pair.Key, pair.Value);
		}
		Console.WriteLine();

		// Creating another SortedList 
		// using Object Initializer Syntax 
		// to initalize sortedlist 
		SortedList my_slist2 = new SortedList() {
								{ "b.09", 234 },
								{ "b.11", 395 },
								{ "b.01", 405 },
								{ "b.67", 100 }};

		foreach (DictionaryEntry pair in my_slist2)
		{
			Console.WriteLine("{0} and {1}",
					pair.Key, pair.Value);
		}
	}
}
