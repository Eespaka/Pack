using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

class ParseJSON
{
    private Dictionary<string, object> tests;
    private Dictionary<string, object> values;
    private Dictionary<string, object> resp;

    public ParseJSON(string testsPath, string valuesPath)
    {
        tests = ReadJson(testsPath);
        values = ReadJson(valuesPath);
        resp = new Dictionary<string, object>();
    }

    public void MainParse()
    {
        JsonParse(values);
        JsonParse(tests, true);
        string reportJson = JsonConvert.SerializeObject(tests, Formatting.Indented);
        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "report.json"), reportJson);
    }

    private void JsonParse(object data, bool write = false)
    {
        if (data is Dictionary<string, object>)
        {
            foreach (var item in (Dictionary<string, object>)data)
            {
                if (item.Value is List<object>)
                {
                    foreach (var x in (List<object>)item.Value)
                    {
                        if (!write)
                        {
                            InsertValue(x);
                            if (((Dictionary<string, object>)x).ContainsKey("values"))
                            {
                                JsonParse(((Dictionary<string, object>)x)["values"], write);
                            }
                        }
                        else
                        {
                            JsonWrite(x);
                            if (((Dictionary<string, object>)x).ContainsKey("values"))
                            {
                                JsonParse(((Dictionary<string, object>)x)["values"], write);
                            }
                        }
                    }
                }
            }
        }
        else if (data is List<object>)
        {
            foreach (var i in (List<object>)data)
            {
                if (!write)
                {
                    InsertValue(i);
                }
                else
                {
                    JsonWrite(i);
                }
                JsonParse(i, write);
            }
        }
    }

    private void InsertValue(object dct)
    {
        if (dct is Dictionary<string, object>)
        {
            string id = (string)((Dictionary<string, object>)dct)["id"];
            object value = ((Dictionary<string, object>)dct)["value"];
            resp[id] = value;
        }
    }

    private void JsonWrite(object dct)
    {
        if (dct is Dictionary<string, object>)
        {
            string id = (string)((Dictionary<string, object>)dct)["id"];
            ((Dictionary<string, object>)dct)["value"] = resp[id];
        }
    }

    private Dictionary<string, object> ReadJson(string file)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(file));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Path to tests.json file: ");
        string testsPath = Console.ReadLine();
        Console.Write("Path to values.json file: ");
        string valuesPath = Console.ReadLine();
        ParseJSON parse = new ParseJSON(testsPath, valuesPath);
        parse.MainParse();
    }
}


