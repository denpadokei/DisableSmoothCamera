using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class FileHelpers
{
	

	// Token: 0x0600000B RID: 11 RVA: 0x00002390 File Offset: 0x00000590
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

	// Token: 0x0600000C RID: 12 RVA: 0x000023C4 File Offset: 0x000005C4
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

	// Token: 0x0600000D RID: 13 RVA: 0x00002428 File Offset: 0x00000628
	public static string[] GetFileNamesFromFilePaths(string[] filePaths)
	{
		List<string> list = new List<string>();
		foreach (string path in filePaths) {
			list.Add(Path.GetFileName(path));
		}
		return list.ToArray();
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002464 File Offset: 0x00000664
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

	// Token: 0x0600000F RID: 15 RVA: 0x000024B0 File Offset: 0x000006B0
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

	// Token: 0x06000010 RID: 16 RVA: 0x00002530 File Offset: 0x00000730
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
