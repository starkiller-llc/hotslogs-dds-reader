using System;
using System.IO;

namespace DDSReader.Console
{
	class Program
	{
		static void Main(string[] args) {
            var files = Directory.GetFiles(".","*.dds");
            foreach (var file in files) {
                var pngFile = Path.ChangeExtension(file, "png");
                System.Console.WriteLine($"Saving {file} -> {pngFile}");
                try {
                    var dds = new DDSImage(file);
                    dds.Save(pngFile);
                }
                catch (Exception e) {
                    System.Console.WriteLine($"   failed {e.Message}");
                }
            }

            return;
			if (args.Length != 2)
			{
				System.Console.WriteLine("ERROR: input and output file required\n");
				Environment.Exit(1);
			}

			var input = args[0];
			var output = args[1];

			if (!File.Exists(input))
			{
				System.Console.WriteLine("ERROR: input file does not exist\n");
				Environment.Exit(1);
			}

			try
			{
				var dds = new DDSImage(input);
				dds.Save(output);
			}
			catch (Exception e)
			{
				System.Console.WriteLine("ERROR: failed to convert DDS file\n");
				System.Console.WriteLine(e);
				Environment.Exit(1);
			}

			if (File.Exists(output))
			{
				System.Console.WriteLine("Successfully created " + output);
			}
			else
			{
				System.Console.WriteLine("ERROR: something went wrong!\n");
				Environment.Exit(1);
			}
		}
	}
}
