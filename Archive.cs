using System;

class Archive
{
	//The ID to use for the next archive:
	private static uint NextID = 0;

	//The ID of the current ID:
	public uint ID
	{
		get;
		private set;
	}

	public string Label
	{
		get;
		private set;
	}

	public string Content
	{
		get;
		private set;
	}

	//Constructor:
	public Archive(string Label, string Content)
	{
		//Obtain the next serial ID:
		this.ID = Archive.NextID++;

		//Assign label and content:
		this.Label = Label;
		this.Content = Content;
	}
}
