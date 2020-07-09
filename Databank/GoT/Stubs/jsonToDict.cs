// using System;
// using System.Collections.Generic;
// import SimpleJSON;
// using System.IO;

// internal class FooSerial
// {
// 	[JsonConverter(typeof(DictionaryConverter))]
// 	public Dictionary<string, string> a { get; set; }
// }

// internal class DictionaryConverter : JsonConverter
// {
// 	public override bool CanWrite { get { return false; } }
// 	public override bool CanConvert(Type objectType)
// 	{
// 		return objectType == typeof(Dictionary<string, string>);
// 	}
// 	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
// 	{
// 		if (reader.TokenType == JsonToken.StartArray)
// 		{
// 			reader.Read();
// 			if (reader.TokenType == JsonToken.EndArray)
// 				return new Dictionary<string, string>();
// 			else
// 				throw new JsonSerializationException("Non-empty JSON array does not make a valid Dictionary!");
// 		}
// 		else if (reader.TokenType == JsonToken.Null)
// 		{
// 			return null;
// 		}
// 		else if (reader.TokenType == JsonToken.StartObject)
// 		{
// 			Dictionary<string, string> ret = new Dictionary<string, string>();
// 			reader.Read();
// 			while (reader.TokenType != JsonToken.EndObject)
// 			{
// 				if (reader.TokenType != JsonToken.PropertyName)
// 					throw new JsonSerializationException("Unexpected token!");
// 				string key = (string)reader.Value;
// 				reader.Read();
// 				if (reader.TokenType != JsonToken.String)
// 					throw new JsonSerializationException("Unexpected token!");
// 				string value = (string)reader.Value;
// 				ret.Add(key, value);
// 				reader.Read();
// 			}
// 			return ret;
// 		}
// 		else
// 		{
// 			throw new JsonSerializationException("Unexpected token!");
// 		}
// 	}

// 	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
// 	{
// 		throw new NotImplementedException();
// 	}
// }

// public static class Prog
// {
// 	static void DeserializeAndPrint(JsonSerializer ser, string data)
// 	{
// 		var foo = ser.Deserialize<FooSerial>(new JsonTextReader(new StringReader(data)));
// 		Console.WriteLine("Dict Contains: {0}", foo.a.Count);
// 		foreach (var kvp in foo.a)
// 		{
// 			Console.WriteLine("[{0}] = {1}", kvp.Key, kvp.Value);
// 		}

// 	}

// 	public static void Main()
// 	{
// 		string bad = "{\"a\": [] }";
// 		string good = "{\"a\":{\"farmer\":\"sun faded clothes and shoes caked in mud\",\"blacksmith\":\"an apron smeared black over brown clothes and thick gloves\",\"fisherman\":\"clothes smelling of fish and tall black boots\",\"merchant\":\"almost gaudy clothing of many colors\",\"rich\":\"adorned with fancy markings and wearing some jewelry.\",\"guard\":\"a leather jacket over some padded clothes\",\"commoner\":\"of average quality.\",\"noble\":\"well tailored and finely made.\",\"poor\":\"that doesn't fit and has all manner of rips and patches.\",\"knight\":\"knightly regalia. Under the tabbard displaying their coat of arms and chainmail.\"}}";
// 		string hasitems = "{\"a\" : { \"foo\" : \"bar\", \"fuz\" : \"baz\" } }";

// 		var ser = JsonSerializer.Create();
// 		DeserializeAndPrint(ser, bad);
// 		DeserializeAndPrint(ser, good);
// 		DeserializeAndPrint(ser, hasitems);
// 	}
// }
