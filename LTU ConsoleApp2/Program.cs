using System.IO;

namespace LTU_ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
            var memberAmount = ReadMembers();
            string[,] sellerInfo = ReadSellerInfo(memberAmount);
            string[,] sellerInfoSorted = SortArray(sellerInfo, 3);
            string[] filingArray = DisplaySellerResults(sellerInfoSorted, memberAmount);

            File.WriteAllLines("AssignmentTwoFile.txt", filingArray);
        }

        private static void MainMenu()
        {
            Console.WriteLine("-----Assignment 2-----");
            Console.WriteLine();
            Console.WriteLine("--Selling Band--");
        }
        private static int ReadMembers()
        {
            int value = 0;
            string readResult;
            bool validInput;

            Console.WriteLine("How many sellers are in your band?");
            do
            {
                readResult = Console.ReadLine();

                if (int.TryParse(readResult, out _))
                {
                    value = Convert.ToInt32(readResult);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    validInput = false;
                }
            } while (validInput == false);

            return value;
        }
        private static string[,] ReadSellerInfo(int memberAmount)
        {
            var credentialsAmount = 4;
            string[,] sellerInfo = new string[memberAmount, credentialsAmount];

            for (int i = 0; i < memberAmount; i++)
            {
                Console.Clear();

                sellerInfo[i, 0] = ReadSellerName(i);
                sellerInfo[i, 1] = ReadSellerPersonalNumber(sellerInfo[i, 0]);
                sellerInfo[i, 2] = ReadSellerDistrict(sellerInfo[i, 0]);
                sellerInfo[i, 3] = ReadSellerSoldArticles(sellerInfo[i, 0]);
            }

            return sellerInfo;
        }
        private static string[] DisplaySellerResults(string[,] results, int memberAmount)
        {
            List<string> filingList = new List<string>();

            Console.Clear();
            Console.WriteLine("---SELLER INFO---");
            Console.WriteLine();
            Console.WriteLine($"Name\t\tPersnr\t\tDistrict\tArticles");

            filingList.Add("---SELLER INFO---");
            filingList.Add("");
            filingList.Add($"Name\t\tPersnr\t\tDistrict\tArticles");

            string spacingOne = "";
            string spacingTwo = "";

            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;

            for (int i = 0; i <= memberAmount; i++)
            {
                int articles = 0;

                if (i < memberAmount)
                {
                    if (results[i, 0].Length < 8)
                        spacingOne = "\t\t";
                    else
                        spacingOne = "\t";

                    if (results[i, 2].Length < 8)
                        spacingTwo = "\t\t";
                    else
                        spacingTwo = "\t";

                    articles = Convert.ToInt32(results[i, 3]);
                    switch (articles)
                    {
                        case < 50:
                            counterOne++;
                            break;
                        case < 99:
                            counterTwo++;
                            break;
                        case < 199:
                            counterThree++;
                            break;
                        case > 199:
                            counterFour++;
                            break;
                    }
                }

                if (counterOne > 0 && articles > 50)
                {
                    Console.WriteLine($"{counterOne} sellers have reached level 1: 0-50 articles");
                    Console.WriteLine();
                    counterOne = 0;

                    filingList.Add($"{counterOne} sellers have reached level 1: 0-50 articles");
                    filingList.Add("");
                }
                else if (counterTwo > 0 && articles > 99)
                {
                    Console.WriteLine($"{counterTwo} sellers have reached level 2: 50-99 articles");
                    Console.WriteLine();
                    counterTwo = 0;

                    filingList.Add($"{counterTwo} sellers have reached level 2: 50-99 articles");
                    filingList.Add("");
                }
                else if (counterThree > 0 && articles > 199)
                {
                    Console.WriteLine($"{counterThree} sellers have reached level 3: 99-199 articles");
                    Console.WriteLine();
                    counterThree = 0;

                    filingList.Add($"{counterThree} sellers have reached level 3: 99-199 articles");
                    filingList.Add("");
                }
                else if (counterFour > 0 && i >= memberAmount)
                {
                    Console.WriteLine($"{counterFour} sellers have reached level 4: over 199 articles");
                    Console.WriteLine();
                    counterFour = 0;

                    filingList.Add($"{counterFour} sellers have reached level 4: over 199 articles");
                    filingList.Add("");
                }
                if (i < memberAmount)
                {
                    Console.WriteLine($"{results[i, 0]}{spacingOne}{results[i, 1]}\t{results[i, 2]}{spacingTwo}{results[i, 3]}");
                    filingList.Add($"{results[i, 0]}{spacingOne}{results[i, 1]}\t{results[i, 2]}{spacingTwo}{results[i, 3]}");
                }

            }

            return ListToArray(filingList);

        }

        private static string ReadSellerName(int sellerNumber)
        {
            string sellerName = "";

            string readResult;
            bool validInput;

            Console.WriteLine($"What's the name of seller number {sellerNumber + 1}?");
            
            do
            {
                readResult = Console.ReadLine();

                if (readResult.Trim().IsNotNullOrEmpty())
                {
                    validInput = true;
                    sellerName = readResult;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    validInput = false;
                }
            } while (validInput == false);

            return sellerName;
        }
        private static string ReadSellerPersonalNumber(string sellerName)
        {
            string sellerPersonalNumber = "";

            string readResult;
            bool validInput;

            Console.WriteLine($"What's {sellerName}'s personal number?");

            do
            {
                readResult = Console.ReadLine();

                if (readResult.Trim().IsNotNullOrEmpty())
                {
                    if ((long.TryParse(readResult, out _)) && (readResult.Length == 10) || (readResult.Length == 12))
                    {
                        sellerPersonalNumber = readResult;
                        validInput = true;
                    }
                    else 
                    {
                        Console.WriteLine("Incorrect value");
                        validInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    validInput = false;
                }

            } while (validInput == false);

            return sellerPersonalNumber;
        }
        private static string ReadSellerDistrict(string sellerName)
        {
            string sellerDistrict = "";

            string readResult;
            bool validInput;

            Console.WriteLine($"In what district does {sellerName} work?");

            do
            {
                readResult = Console.ReadLine();

                if (readResult.Trim().IsNotNullOrEmpty())
                {
                    validInput = true;
                    sellerDistrict = readResult;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    validInput = false;
                }
            } while (validInput == false);

            return sellerDistrict;

        }
        private static string ReadSellerSoldArticles(string sellerName)
        {
            string sellerSoldArticles = "";

            string readResult;
            bool validInput;

            Console.WriteLine($"How many articles has {sellerName} sold?");

            do
            {
                readResult = Console.ReadLine();

                if (readResult.Trim().IsNotNullOrEmpty())
                {
                    if (int.TryParse(readResult, out _))
                    {
                        sellerSoldArticles = readResult;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value");
                        validInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    validInput = false;
                }
            } while (validInput == false);

            return sellerSoldArticles;
        }

        private static string[,] SortArray(string[,] array, int value)
        {
            int columnIndex = value;
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);

            List<string[]> newList = new List<string[]>();
            for (int i = 0; i < rowCount; i++)
            {
                string[] row = new string[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    row[j] = array[i, j];
                }
                newList.Add(row);
            }

            newList.Sort((x, y) => {
                if (double.TryParse(x[columnIndex], out double xNum) && double.TryParse(y[columnIndex], out double yNum))
                {
                    return xNum.CompareTo(yNum);
                }
                else
                {
                    return x[columnIndex].CompareTo(y[columnIndex]);
                }
            });

            string[,] sortedArray = new string[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                string[] row = newList[i];
                for (int j = 0; j < columnCount; j++)
                {
                    sortedArray[i, j] = row[j];
                }
            }

            return sortedArray;
        }
        private static string[] ListToArray(List<string> dataList)
        {
            string[] listArray = dataList.Select(x => x.ToString()).ToArray();
            return listArray;
        }

    }
}
