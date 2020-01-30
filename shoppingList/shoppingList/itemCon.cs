using System;

public class item
{
	private string name;
	private int quantity;

	public item(string name, int quantity)
	{
		this.name = name;
		this.quantity = quantity;
	}

	public string getName()
    {
		return name;
    }

	public void setName(string name)
    {
		this.name = name;
    }

	public int getQuantity()
    {
		return quantity;
    }

	public void setQuantity(int quantity)
	{
		this.quantity = quantity;
	}

}
