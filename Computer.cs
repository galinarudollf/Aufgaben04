using System;
using System.IO;
using System.Threading;

class Computer
{

	private string UserNameField;
	public string UserName
	{
		get
		{
			return this.UserNameField;
		}
	}

	public void SwitchUser(string NewUserName)
	{
		Console.WriteLine("Logging out ...");
		Thread.Sleep(1000);
		Console.WriteLine("Logging in as {0} ...", NewUserName);
		Thread.Sleep(1000);

		this.UserNameField = NewUserName;
	}

	private Random CrashRandom;

	public bool HasCrashed
	{
		get;
		private set;
	}


	public void SaveFile(string FileName)
	{
		SaveFile(Path.Combine(@"C:", "Users", this.UserNameField, "Desktop"), FileName);
	}

	public void SaveFile(string FilePath, string FileName)
	{
		if (this.HasCrashed)
		{
			throw new InvalidOperationException("Sorry, the computer has already crashed. Please reboot.");
		}

		Console.WriteLine("Saving file: {0}", Path.Combine(FilePath, FileName));
		if ((this.CrashRandom.Next() % 4) == 3)
		{
			this.HasCrashed = true;
			throw new InvalidOperationException("Oh no, the computer has crashed :( ...");
		}
	}
	public void Reboot()
	{
		Console.WriteLine("Rebooting ...");
		Thread.Sleep(2000);

		Console.Beep();
		Console.WriteLine("Reboot complete!");

		this.HasCrashed = false;
	}
	private byte[] IPAddressBytes;
	public string IPAddress
	{
		get
		{
			return IPTools.IPAddressToString(this.IPAddressBytes);
		}

		set
		{
			this.IPAddressBytes = IPTools.StringToIPAddress(value);
		}
	}

	 public void CreateArchive(string Label, string Content, out Archive archiveToCreate)
	 {
	 	Console.WriteLine("Creating archive ({0}) ...", Label);
	 	Thread.Sleep(2000);

	 	archiveToCreate = new Archive(Label, Content);
	 	Console.WriteLine("Archive has been created successfully.");
	 }

	public void Print()
	{
		Console.WriteLine("========================================");
		Console.WriteLine("{0,-20}: {1}", "Current user", this.UserName);
		Console.WriteLine("{0,-20}: {1}", "IP address", this.IPAddress);
		Console.WriteLine("{0,-20}: {1}", "Has crashed", this.HasCrashed);
		Console.WriteLine("========================================");
	}

	public Computer(Random Rand)
	{

		this.UserNameField = "Administrator";
		this.CrashRandom = Rand;
		this.HasCrashed = false;
		this.IPAddressBytes = IPTools.LocalHostBytes;
	}
}
