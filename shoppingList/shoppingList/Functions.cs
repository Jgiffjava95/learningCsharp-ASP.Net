using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Functions
{

	bool keepLooping = true;

	public void options(List<item> shoppingList)
	{
		Console.WriteLine("***WELCOME TO JEREMY'S SHOPPING LIST PROGRAM***");

		while (keepLooping)
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("*---------------------------------------*");
			Console.WriteLine("|Enter number to select options.        |");
			Console.WriteLine("|Add item of same name to up quantity.  |");
			Console.WriteLine("|1 = Add Item To List.                  |");
			Console.WriteLine("|2 = Delete Item From List.             |");
			Console.WriteLine("|0 = Close Program.                     |");
			Console.WriteLine("*---------------------------------------*");
			viewList(shoppingList);


			string input = Console.ReadLine();
			int inputToNum;
			bool result = int.TryParse(input, out inputToNum);

			if (inputToNum > 3 || inputToNum < 0 || result == false)
			{
				Console.WriteLine("The command " + input + " is not a correct input.");
			}

			else
			{

				switch (inputToNum)
				{
					case 1:
						addToList(shoppingList);
						continue;         
					case 2:
						deleteFromList(shoppingList);
						continue;
					case 0:
						Environment.Exit(0);
						break;
				}
			}
		}
	}

	private void viewList(List<item> shoppingList)
	{
		int itemListNum = 1;
		

		Console.WriteLine("Item List");
		Console.WriteLine("-------------");

		if (shoppingList.Any())
		{
			foreach (item i in shoppingList)
			{
				Console.WriteLine((itemListNum++) + ". " + i.name + " x " + i.quantity);
			}
		}
		else
		{
			Console.WriteLine("The list is currently empty.");
			
		}
		Console.WriteLine("-------------");
		return;
	}

	private void addToList(List<item> shoppingList)
	{

		while (keepLooping)
		{
			int quan;

			Console.WriteLine("Enter Name of item you wish to add.");
			string input = Console.ReadLine();
			string upper = input.ToUpper();

			Console.WriteLine("Enter Quantity for " + input + ".");
			string stringQuan = Console.ReadLine();

			if (upper.Length == 0 || stringQuan.Length == 0)
			{
				Console.WriteLine("Both Name and Quantity must have a value.");
				continue;
			}
			else
			{

				bool result = int.TryParse(stringQuan, out quan); 

				if (result == false)
				{
					Console.WriteLine("Quantity must be a number.");
					continue;
				}

				else if (quan <= 0)
				{
					quan = 1;
					Console.WriteLine("Quantity defaulted to 1.");
				}

			}

			if (shoppingList.Count != 0)
			{
				foreach (item i in shoppingList)
				{
					if (i.name.ToUpper() == upper)
					{
						int newQuan = i.quantity + quan;
						Console.WriteLine("Item " + i.name + " quantity updated from " + i.quantity + " to " + newQuan + ".");
						i.quantity = newQuan;
						return;
					}
				}
			}
			string itemUpperLower = upper.Substring(0, 1).ToUpper() + upper.Substring(1).ToLower();
			item addItem = new item(itemUpperLower, quan);
			shoppingList.Add(addItem);
			Console.WriteLine("Item " + itemUpperLower + " added.");
			return;
		}
	}

	private void deleteFromList(List<item> shoppingList)
	{
		if (shoppingList.Count != 0)
		{
			while (keepLooping)
			{
				Console.WriteLine("Enter Name of item to be deleted.");
				Console.WriteLine("Enter 'All' to clear whole list.");
				Console.WriteLine("Or enter 0 to exit back to menu.");
				string delete = Console.ReadLine();
				string upper = delete.ToUpper(); 

				if(delete == "0")
				{
					return;
				}

				if (upper.Length == 0)
				{
					Console.WriteLine("Must give name of item you want to delete");
					continue;
				}
				else if (upper == "ALL")
				{
					shoppingList.Clear();
					Console.WriteLine("List cleared.");
					return;
				}
				else
				{

					foreach (item i in shoppingList)
					{
						if (i.name.ToUpper() == upper)
						{
							shoppingList.Remove(i);
							Console.WriteLine(i.name + " Deleted from list.");
							return;
						}
						else
						{
							Console.WriteLine(upper + " is not on the list.");
						}
					}
				}
			}
		}
		else
		{
			Console.WriteLine("No items to delete.");
		}
	}
}