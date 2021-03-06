﻿// 
//  Copyright 2012  Andrew Okin
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace MultiMC
{
	public class AppSettings : ConfigFile
	{
		public AppSettings()
			: base()
		{

		}

		private static AppSettings inst;

		/// <summary>
		/// The main settings provider.
		/// </summary>
		/// <value>
		/// The main settings provider.
		/// </value>
		public static AppSettings Main
		{
			get
			{
				if (inst != null)
				{
					return inst;
				}
				else
				{
					Console.WriteLine("Loading settings...");
					inst = new AppSettings();
					inst.Load();

					return inst;
				}
			}
		}

		public override void Load(string path = null)
		{
			if (path == null)
				path = Properties.Resources.ConfigFileName;

			base.Load(path);
		}

		public override void Save(string path = null)
		{
			if (path == null)
				path = Properties.Resources.ConfigFileName;

			base.Save(path);
		}

		/// <summary>
		/// Automatically finds the path to where java is installed.
		/// </summary>
		/// <returns>
		/// True if java was found. Otherwise, <c>false</c>
		/// </returns>
		public bool AutoDetectJavaPath()
		{
			if (OSUtils.OS == OSEnum.Windows)
			{
				Console.WriteLine("Finding Java on Windows...");

				RegistryKey x64LocalMachineKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
				RegistryKey javaKey = null;
				if (x64LocalMachineKey != null)//On x64 first try x64-Java else x86-java
				{
					javaKey = x64LocalMachineKey.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment") ?? x64LocalMachineKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Javasoft\\Java Runtime Environment");
				}
				else
				{
					javaKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment");
				}

				if (javaKey != null)
				{
					string javaVersion = javaKey.GetValue("CurrentVersion").ToString();
					try
					{
						JavaPath = javaKey.OpenSubKey(javaVersion).GetValue("JavaHome").ToString() + @"\bin\java.exe";
						return true;
					}
					catch (NullReferenceException)
					{
						//Key not found or JavaHome not found ... in both cases: use failsafe
					}
				}

				//Old version as failsave ...
				string[] possiblePaths = new string[]
				{
					@"C:\Program Files\Java\jre7\bin\java.exe",
					@"C:\Program Files\Java\jre6\bin\java.exe",
					@"C:\Program Files (x86)\Java\jre7\bin\java.exe",
					@"C:\Program Files (x86)\Java\jre6\bin\java.exe",
				};

				foreach (string path in possiblePaths)
				{
					if (File.Exists(path))
					{
						Console.WriteLine("Found Java at {0}", path);
						JavaPath = path;
						return true;
					}
				}
				return false;
			}
			else if (OSUtils.OS == OSEnum.Linux)
			{
				Console.WriteLine("Finding Java on Linux...");
				ProcessStartInfo info = new ProcessStartInfo("which", "java");
				info.UseShellExecute = false;
				info.RedirectStandardOutput = true;
				Process findJavaProc = Process.Start(info);
				string path = findJavaProc.StandardOutput.ReadToEnd();
				path = path.Trim();
				if (File.Exists(path))
				{
					Console.WriteLine("Found Java at {0}", path);
					JavaPath = path;
					return true;
				}
				else
					return false;
			}
			return false;
		}

		public int MinMemoryAlloc
		{
			get { return ParseSetting<int>("MinMemoryAlloc", 512); }
			set { this["MinMemoryAlloc"] = value.ToString(); }
		}

		public int MaxMemoryAlloc
		{
			get { return ParseSetting<int>("MaxMemoryAlloc", 1024); }
			set { this["MaxMemoryAlloc"] = value.ToString(); }
		}

		public string JavaPath
		{
			get { return this["JavaPath", "java"]; }
			set { this["JavaPath"] = value; }
		}

		public string InstanceDir
		{
			get
			{
				return Environment.ExpandEnvironmentVariables(
					this["InstDir", "instances"]);
			}
			set { this["InstDir"] = value; }
		}

		public string RawInstanceDir
		{
			get { return this["InstDir", "instances"]; }
			set { this["InstDir"] = value; }
		}

		public string CentralModsDir
		{
			get { return this["ModsDir", "mods"]; }
			set { this["ModsDir"] = value; }
		}

		public bool ShowConsole
		{
			get { return ParseSetting<bool>("ShowConsole", false); }
			set { this["ShowConsole"] = value.ToString(); }
		}

		public bool AutoCloseConsole
		{
			get { return ParseSetting<bool>("AutoCloseConsole", false); }
			set { this["AutoCloseConsole"] = value.ToString(); }
		}

		public bool AutoUpdate
		{
			get { return ParseSetting<bool>("AutoUpdate", true); }
			set { this["AutoUpdate"] = value.ToString(); }
		}

		public bool QuitIfProblem
		{
			get { return ParseSetting<bool>("QuitIfProblem", false); }
			set { this["QuitIfProblem"] = value.ToString(); }
		}
	}
}
