using System;
using System.IO;

/**
 * This program read data from a csv file and process this data. While this data process, 
 * When this data is processed, three members are important. 
 * These members are song_id(Identifier of a song), client_id(Identifier of a client),
 * and play_ts(date time of the client playing a song).
 * I am creating a client that have these member.Then I am adding to Binary Tree this client.
 * After I am counting the number of customers playing different numbers and displays.
 */

class Test
{
    public static void Main(string[] args)
    {
        //input file path
        string inputFilePath = @"C:\Users\deniz\Documents\Visual Studio 2017\Cshap\piWorks\input.csv";
        //desired date
        const string disaredDate = "10/08/2016";
        //Keep clients with binary tree
        BinarySearchTree clients = new BinarySearchTree(); 
        string line; // temp value
        int i = 1;  //if catch a exception when read input file, display the number of line.
        try
        {   
            using (FileStream fs = new FileStream(inputFilePath, FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
            
            // Read the file and display it line by line.
            using (System.IO.StreamReader file = new System.IO.StreamReader(fs))
            {
                
                line = file.ReadLine(); // first  read line, because unnecessary
                while ((line = file.ReadLine()) != null)
                {
                    // parse string line to process data
                    string[] subString = line.Split(' ', '\t');
                    
                    int len = subString.Length;

                    //if data is not fix, desired data is received
                    //etc: "					44BB190BC2493964E053CF0A000AB546				6164	249	10/08/2016 09:16:34"
                    if (len >= 4) {
                        string[] temp = new string[5];
                        int j=0;
                        for (int k = 0; k < len; ++k)
                        {
                            if (subString[k] != "") //
                            {
                                temp[j] = subString[k];
                                ++j;
                            }
                        }
                        subString = temp;
                    }
                    else if (len < 4)//If the data is incomplete
                    {
                        continue;
                    }
                    else throw new IndexOutOfRangeException("index out of boundary");

                    //if this date is the desired date, enter in the if case;
                    if (subString[3].Equals(disaredDate))
                    {
                        Client client = new Client(subString[1], subString[2], subString[3]); // create temp value
                        clients.Insert(client); //insert client to binary tree
                    }
                    
                    ++i;
                }
            }
        }catch(IndexOutOfRangeException e) 
        {
            Console.WriteLine("Catch a Exception(index out of boundary).");
            Console.WriteLine("Wrong Line : {0}", i);
            Console.WriteLine("True Format Example: '44BB190BC24B3964E053CF0A000AB546   9648    589 10 / 08 / 2016 06:08:53'");
            Console.Read();
            Environment.Exit(0); //exit
        }

        //if tree size more than zero
        if (clients.size() > 0)
        {
            clients.display(); //displays customers playing different numbers.

          //  Console.WriteLine("\nMaximum number of distinct songs  played is "+ clients.size());
        }


        Console.WriteLine("\nfinish"); //finish
        Console.Read();
    }

}
