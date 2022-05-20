using System;

class Lesson6
{
	static void Main(string[] args)
	{
		/*********************************
		  1.) 
		 *********************************/

		/*
		Computer MyComputer = new Computer();
		*/

		/*********************************
		  2.) 
		 *********************************/

		/*
		Computer MyComputer = new Computer();
		Console.WriteLine("User (before): {0}", MyComputer.UserName);
		
		MyComputer.SwitchUser("groot");
		Console.WriteLine("User (after): {0}", MyComputer.UserName);
		*/

		/*********************************
		  3.) 
		 *********************************/

		/*
		Computer MyComputer = new Computer(new Random());
		int FileCount = 0;

		try
		{
			for (; FileCount < 5; FileCount++)
			{
				MyComputer.SaveFile(String.Format("MyPhoto{0:d2}.jpg", FileCount));
			}
		}
		catch (InvalidOperationException)
		{
			Console.WriteLine("The computer has crashed after {0} files :(", FileCount);
			MyComputer.Reboot();

			return;
		}

		Console.WriteLine("All files have been saved :)");
		*/

		/*********************************
		  4.) 
		 *********************************/

		/*
		try
		{
			Computer MyComputer = new Computer(new Random());
			Console.WriteLine("IP address (before): {0}", MyComputer.IPAddress);

			MyComputer.IPAddress = "ffee:ddcc:bbaa:9988:7766:5544:3322:1100";
			Console.WriteLine("IP address (after): {0}", MyComputer.IPAddress);

			MyComputer.IPAddress = "foobar";
		}
		catch (FormatException Ex)
		{
			Console.WriteLine("Format exception: {0}", Ex.Message);
		}
		*/

		/*********************************
		  5.)
		 *********************************/

		 /*
		 Computer MyComputer = new Computer(new Random());

		 DVD Psycho;
		 MyComputer.BurnDVD("Psycho", "What are you running away from?", out Psycho);

		 DVD StarWars;
		 MyComputer.BurnDVD("Star Wars", "These are not the droids you are looking for.", out StarWars);

		 Console.WriteLine("Label: \"{0}\", content: \"{1}\", serial: {2}", Psycho.Label, Psycho.Content, Psycho.SerialID);
		 Console.WriteLine("Label: \"{0}\", content: \"{1}\", serial: {2}", StarWars.Label, StarWars.Content, StarWars.SerialID);
		 */

		/*********************************
		  6.)
		 *********************************/

		/*
		//Create one random for all of them (important!):
		Random Rand = new Random();

		//Create and fill the array:
		Computer[] ComputerPool = new Computer[100];

		for (int i = 0; i < 100; i++)
		{
			ComputerPool[i] = new Computer(Rand);
			ComputerPool[i].IPAddress = String.Format("139.20.16.{0}", i); //Custom IP address
		}

		//Save policy file and count crashes:
		int Crashed = 0;

		foreach (Computer Comp in ComputerPool)
		{
			try
			{
				Comp.SaveFile("C:", "Policies.pol");
			}
			catch (InvalidOperationException)
			{
				Console.WriteLine("Crash ...");
				Crashed++;
			}
		}

		//Reboot the crashed ones:
		Console.WriteLine("Rebooting {0} computers now ...", Crashed);

		foreach (Computer Comp in ComputerPool)
		{
			if (Comp.HasCrashed)
			{
				Console.WriteLine("Computer to reboot:");
				Comp.Print();
				Comp.Reboot();
			}
		}
		*/
	}
}
