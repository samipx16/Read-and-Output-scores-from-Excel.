/*This program reads and output the scores of several students from a excel file */
using System.IO;
using System.Linq;
using static System.Console;
class Program
{
	public static void Main()
	{
		//Read csv file
		const string FILENAME = "scores.csv";
		const string CHECKER = @"""scores.csv""";
		string path = @"C:\Users\samip\Desktop\Projects\ConsoleApp4\ConsoleApp4\bin\Debug\net6.0\scores.csv";
		bool fileExist = File.Exists(path);
		


		if (fileExist)
		{
			FileStream inFile = new FileStream(FILENAME,
			FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(inFile);
			string recordIn;
			string name;

			WriteLine("Student Name                  Test Scores       Average   Grade");
			WriteLine("============               ==================   =======   =====");
			inFile.Seek(0, SeekOrigin.Begin);
			recordIn = reader.ReadLine();
			

			while (recordIn != null)
			{
				string[] fields = recordIn.Split(',');
				name = fields[0];
				int  testScore1 = Convert.ToInt32(fields[1]);
				int testScore2 = Convert.ToInt32(fields[2]);
				int testScore3 = Convert.ToInt32(fields[3]);
				int testScore4 = Convert.ToInt32(fields[4]);	
				int testScore5 = Convert.ToInt32(fields[5]);
				double average = GetAverage(fields,testScore1,testScore2,testScore3,testScore4,testScore5);
				char grade = GetGrade(average);
				WriteLine("{0,-25} {1,3} {2,3} {3,3} {4,3} {5,3} {6,8:F1} {7,6}",
                                    name, testScore1,testScore2,testScore3,testScore4,testScore5, average, grade);
				recordIn = reader.ReadLine();

			}
		}
		else
		{
			WriteLine(" Input file {0} not found ", CHECKER);
		}
		



	}
	//this method returns the average
	public static double GetAverage(string [] fields, int testScore1, int testScore2, int testScore3, int testScore4, int testScore5 )
	{
		double sum = 0;
		for (int i = 1; i < fields.Length; i++)
		{
			sum = sum + double.Parse(fields[i]);
		}
		double sumAv = sum / 5 ;

		return sumAv;
		
	}
	public static char GetGrade(double average)
	{
		//Compares the value given in the data
		if (average >= 90)
		{
			return 'A';
		}
		else if (average >= 80)
		{
			return 'B';
		}
		else if (average >= 70)
		{
			return 'C';
		}
		else if (average >= 60)
		{
			return 'D';
		}
		else
		{
			return 'F';
		}
	}
}
	
