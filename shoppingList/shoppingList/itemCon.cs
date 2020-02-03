using System;

public class item
{
	public string name { get; set; }
	public int quantity { get; set; }

	public item(string name, int quantity)
	{
		this.name = name;
		this.quantity = quantity;
	}

}
