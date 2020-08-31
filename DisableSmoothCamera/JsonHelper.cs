using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class JsonHelpers
{
	public static string GetUniqueDirectoryNameByAppendingNumber(string dirName)
	{
		int num = 0;
		string text = dirName;
		while (Directory.Exists(text)) {
			num++;
			text = dirName + " " + num;
		}
		return text;
	}

	public static string[] GetFilePaths(string directoryPath, HashSet<string> extensions)
	{
		if (!Directory.Exists(directoryPath)) {
			return null;
		}
		string[] files = Directory.GetFiles(directoryPath);
		List<string> list = new List<string>();
		foreach (string text in files) {
			string item = Path.GetExtension(text).Replace(".", "");
			if (extensions.Contains(item)) {
				list.Add(text);
			}
		}
		return list.ToArray();
	}

	public static string[] GetFileNamesFromFilePaths(string[] filePaths)
	{
		List<string> list = new List<string>();
		foreach (string path in filePaths) {
			list.Add(Path.GetFileName(path));
		}
		return list.ToArray();
	}

	public static void SaveToJSONFile(object obj, string filePath, string tempFilePath, string backupFilePath)
	{
		try {
			string contents = JsonConvert.SerializeObject(obj);
			if (File.Exists(filePath)) {
				File.WriteAllText(tempFilePath, contents);
				File.Replace(tempFilePath, filePath, backupFilePath);
			}
			else {
				File.WriteAllText(filePath, contents);
			}
		}
		catch {
		}
	}

	public static T LoadFromJSONFile<T>(string filePath, string backupFilePath = null) where T : class
	{
		T t = default(T);
		if (File.Exists(filePath)) {
			try {
				t = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
			}
			catch {
				t = default(T);
			}
		}
		if (t == null && backupFilePath != null && File.Exists(backupFilePath)) {
			try {
				t = JsonConvert.DeserializeObject<T>(File.ReadAllText(backupFilePath));
			}
			catch {
				t = default(T);
			}
		}
		return t;
	}

	public static string LoadJSONFile(string filePath, string backupFilePath = null)
	{
		string text = null;
		if (File.Exists(filePath)) {
			try {
				text = File.ReadAllText(filePath);
			}
			catch {
				text = null;
			}
		}
		if (text == null && backupFilePath != null && File.Exists(backupFilePath)) {
			try {
				text = File.ReadAllText(backupFilePath);
			}
			catch {
				text = null;
			}
		}
		return text;
	}
}
