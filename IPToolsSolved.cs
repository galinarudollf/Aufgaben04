using System;
using System.Globalization;

static class IPTools
{
	public static readonly byte[] LocalHostBytes = new byte[] { 127, 0, 0, 1 };
	public static readonly string LocalHost;

	//Format an IPv4 or IPv6 address as string:
	public static string IPAddressToString(byte[] Address)
	{
		if (Address.Length == 4)
		{
			return IPTools.IPv4AddressToString(Address);
		}
		else
		{
			return IPTools.IPv6AddressToString(Address);
		}
	}

	//Format an IP address (four-byte-array) as string:
	public static string IPv4AddressToString(byte[] Address)
	{
		//Check length:
		if (Address.Length != 4)
		{
			throw new FormatException("IPv4 address must have four components.");
		}

		//Iterate over components and format as decimal string:
		string[] Components = new string[4];

		for (int i = 0; i < 4; i++)
		{
			Components[i] = Address[i].ToString();
		}

		//Concatenate all array entries using "." as separator:
		return string.Join(".", Components);
	}

	//Format an IP address (sixteen-byte-array) as string:
	public static string IPv6AddressToString(byte[] Address)
	{
		//Check length:
		if (Address.Length != 16)
		{
			throw new FormatException("IPv6 address must have sixteen components.");
		}

		//Iterate over components and format as four-char, lowercased hex string:
		string[] Components = new string[8];

		for (int i = 0; i < 8; i++)
		{
			Components[i] = Address[2 * i].ToString("x2") + Address[(2 * i) + 1].ToString("x2");
		}

		return string.Join(":", Components);
	}

	//Parse a given string as IPv4 or IPv6 address:
	public static byte[] StringToIPAddress(string Value)
	{
		if (Value.Contains("."))
		{
			return IPTools.StringToIPv4Address(Value);
		}
		else if (Value.Contains(":"))
		{
			return IPTools.StringToIPv6Address(Value);
		}
		else
		{
			throw new FormatException("Invalid IP address string");
		}
	}

	//Parse a given string as IPv4 address:
	public static byte[] StringToIPv4Address(string Value)
	{
		//Split the string at all occurrences of ".":
		string[] Components = Value.Split('.');

		//Check length:
		if (Components.Length != 4)
		{
			throw new FormatException("IPv4 address must have four components.");
		}

		//Parse from decimal strings:
		byte[] Result = new byte[4];

		for (int i = 0; i < 4; i++)
		{
			Result[i] = byte.Parse(Components[i]);
		}

		return Result;
	}

	//Parse a given string as IPv6 address:
	public static byte[] StringToIPv6Address(string Value)
	{
		//Split the string at all occurrences of ":":
		string[] Components = Value.Split(':');

		//Check length:
		if (Components.Length != 8)
		{
			throw new FormatException("IPv6 address must have sixteen components.");
		}

		//Parse from hex strings:
		byte[] Result = new byte[16];

		for (int i = 0; i < 8; i++)
		{
			ushort CurrShort = ushort.Parse(Components[i], NumberStyles.AllowHexSpecifier);

			Result[2 * i] = (byte)(CurrShort >> 8);
			Result[(2 * i) + 1] = (byte)(CurrShort & 0x00FF);
		}

		return Result;
	}

	//Static constructor:
	static IPTools()
	{
		IPTools.LocalHost = IPTools.IPv4AddressToString(IPTools.LocalHostBytes);
	}
}
