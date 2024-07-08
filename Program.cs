using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace test_console_app
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var p = new Program();
			string curdir = Environment.CurrentDirectory;
			string filepath = curdir + @"\testfile.pdf";
			string newpath = curdir + @"\newfolder\newfile.pdf";

			Console.WriteLine($"Current Directory is: {curdir}");
			

			Console.WriteLine("\nMake sure there is a file named 'testfile.pdf' inside the same directory as this program.");
			Console.WriteLine("Once you are  sure, press any key to continue.");
			Console.ReadKey(); // Waits for a key press from the user
			Console.WriteLine($"Copying {filepath} to {newpath}");

			try
			{
				File.Copy(filepath, newpath, true);
			}
			catch (UnauthorizedAccessException uae)
			{
				Console.WriteLine(uae.Message);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
			}
			catch (PathTooLongException ptle)
			{
				Console.WriteLine(ptle.Message);
			}
			catch (DirectoryNotFoundException dnfe)
			{
				Console.WriteLine(dnfe.Message);
				Console.WriteLine($"Creating new folder {Environment.CurrentDirectory + @"\newfolder\"}");
				try
				{
					DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + @"\newfolder\");
					
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				finally
				{
					try
					{
						Console.WriteLine($"Copying {filepath} to {newpath}");
						File.Copy(filepath, newpath, true);
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
					finally
					{
						try
						{
							Process.Start(newpath);
						}
						catch (Exception e)
						{
							Console.WriteLine(e);
						}
					}
				}
			}
			catch (FileNotFoundException fnfe)
			{
				Console.WriteLine(fnfe.Message);
			}
			catch (IOException ioe)
			{
				Console.WriteLine(ioe.Message);
			}
			catch (NotSupportedException nse)
			{
				Console.WriteLine(nse.Message);
			}
			finally
			{
				try
				{
					Process.Start(newpath);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
				Console.WriteLine("\nPress any key to exit...");
				Console.ReadKey(); // Waits for a key press from the user
			}
		}
	}
}
