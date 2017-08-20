using System;
using System.Collections.Generic;
using System.IO;

namespace HyperLib
{
	public class RedEngine
	{
		#region Properties
		private string rootdirectory;
		private List<string> scannresult = new List<string>();

		public string RootDirectrory
		{
			get
			{
				return rootdirectory;
			}
			set
			{
				rootdirectory = value;
			}
		}

		public List<string> ScannResult
		{
			get
			{
				return scannresult;
			}
			private set
			{
				scannresult = value;
			}
		}

		#endregion

		public delegate void scanndone();
		public event scanndone ScannDone;

		public RedEngine() { }

		public RedEngine(string RootDir)
		{
			if(Directory.Exists(RootDir))
				RootDirectrory = RootDir;
		}

		/// <summary>
		/// Runs the hash scann, for all subdirectorys in the root directory
		/// </summary>
		/// <param name="RootDir">Root dir.</param>
		/// <param name="SHA256hash">SHA 256hash.</param>
		public void RunHashScann(string RootDir, string SHA256hash) 
		{
			scann(RootDir, SHA256hash);
			runSubdir(RootDir, SHA256hash);
			ScannDone();
		}

		/// <summary>
		/// Runs the hash scann, for all subdirectorys in the root directory
		/// </summary>
		/// <returns>The scann.</returns>
		/// <param name="RootDir">Root dir.</param>
		/// <param name="Sha256Hash">Sha256 hash.</param>
		public List<string> RunScann(string RootDir, string Sha256Hash)
		{
			scann(RootDir, Sha256Hash);
			runSubdir(RootDir, Sha256Hash);
			return scannresult;
		}

		/// <summary>
		/// Scanns only one directory
		/// </summary>
		/// <param name="Dir">Dir.</param>
		/// <param name="SHA256hash">SHA 256hash.</param>
		public void ScannOneDir(string Dir, string SHA256hash)
		{
			scann(Dir, SHA256hash);
			ScannDone();
		}

		/// <summary>
		/// This scanns a dir and the dirs in it
		/// </summary>
		/// <param name="dir">Dir.</param>
		/// <param name="SHA256hash">SHA 256hash.</param>
		private void runSubdir(string dir, string SHA256hash)
		{
			string[] dirlist = Directory.GetDirectories(dir);
            foreach (string x in dirlist)
            {
				scann(x, SHA256hash);
				runSubdir(x, SHA256hash);
            }
		}

		/// <summary>
		/// This is the actual scann ..
		/// </summary>
		/// <returns>The scann.</returns>
		/// <param name="ActDir">Act dir.</param>
		/// <param name="SHAhash">SHA hash.</param>
		private void scann(string ActDir, string SHAhash)
		{
			try
			{
				FileStream fs = null;
				foreach (var file in Directory.GetFiles(ActDir))
				{
					fs = new FileStream(file, FileMode.Open, FileAccess.Read);
					string hash = EasyHash.GetSHA256Hash(fs);
					if (hash == SHAhash)
					{
						scannresult.Add(file);
					}
				}
				if(fs != null)
					fs.Close();
			}
			catch (Exception e)
			{
				scannresult.Add(e.Message);
			}
		}
	}
}
