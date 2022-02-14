/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1,7,10,13 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                // the below is a basic binary search method where we compare with the mid value as the array is already sorted.
                int min = 0;
                int max = nums.Length - 1;
               
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    if (nums[mid] < target)
                    {
                        min = mid + 1;  
                    }
                    else
                    {
                        max = mid - 1;     
                    }
                    
                }
                return max+1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                //Declared string to remove special characters
                string[] rem = { "!", ",", ".", "?", ";", "''", "'" };
                int[] p = new int[100];
                //In this for loop i am removing the special characters from the string
                foreach (string i in rem)
                {
                    paragraph = paragraph.Replace(i, "");
                }
                //The below array stores the words that are split by space and are converted to lower sentence format.
                string[] arr = paragraph.ToLower().Split(' ');
                int count = 1;
                //Declared dictionary to store the count of repeatance of each word in the sentence
                Dictionary<string, int> k = new Dictionary<string, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    //if the loop comes across new word it adds to dictionary
                    if (!k.ContainsKey(arr[i]))
                    {
                        k.Add(arr[i], count);
                    }
                    //If its a repeated word, it just increases the count which is stored in the value part.
                    else
                    {
                        k[arr[i]]++;
                    }
                }
                //If we do not have any banned words in the input it goes into this loop.
                if (banned.Length == 0)
                {
                    //Defined the maxword function below on line 236 to return the max words in the sentence
                    //Here we do not have any banned words to delete as length is zero.
                    return k.FirstOrDefault(x => x.Value == maxword(k)).Key;
                }
                //If the banned words array length is greater than zero it goes to this condition.
                else
                {
                    //the below for loop is to delete banned words from the dictionary.
                    for (int i = 0; i < banned.Length; i++)
                    {
                        k.Remove(banned[i]);
                    }
                    int y = maxword(k);
                    // This below is a query to return the key which has the highest value quantity..obtained from stackoverflow.
                    return k.FirstOrDefault(x => x.Value == maxword(k)).Key;
                }
                //This function is defined to return maximum times recurrence of a word.
                int maxword(Dictionary<string, int> k)
                {
                    //Declared a list to store each key of the dictionary
                    List<string> keyList = new List<string>(k.Keys);
                    //Below loop is to store the each value of the key into seperate integer array.
                    for (int i = 0; i < keyList.Count; i++)
                    {
                        p[i] = k[keyList[i]];
                    }
                    //This returns the Maximum value in the integer array.
                    return p.Max();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> x = new Dictionary<int, int>();
                int z = -1;
                for (int i = 0; i < arr.Length; i++)
                {
                    //This condition makes the values in array to enter the dictionary
                    if (!x.ContainsKey(arr[i]))
                    {
                        x.Add(arr[i], 1);
                    }
                    //If the dictionary already has the key, then it increments its value
                    else
                    {
                        x[arr[i]]++;
                    }
                }
                //THis for loop searches if the frequency of number is equal to its value, to find the lucky number.
                foreach(var y in x)
                {
                    if (y.Key == y.Value)
                    {
                         z= Math.Max(z,y.Key);
                    }
                }
                return z;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //Declared x and y to return the number of bulls and cows respectively
                int x = 0;
                int y = 0;
                Dictionary<double, int> mem = new Dictionary<double, int>();
                //This for loop is to give unique numbers in the input string into the dictionary
                for (int i = 0; i < secret.Length; i++)
                {
                    //if the dictionary already contains the key it increments its value
                    if (mem.ContainsKey(secret[i]))
                    {
                        mem[secret[i]] = mem[secret[i]] + 1;
                    }
                    //else it adds the number to dictionary
                    else
                    {
                        mem.Add(secret[i], 1);
                    }

                }
                //This for loop is to find the bulls and cows.
                for (int i = 0; i < secret.Length; i++)
                {
                    //This condition checks the numbers on the line and increments if any same found.
                    if (secret[i] == guess[i])
                    {
                        //THis condition is to check if the number is unique or not.
                        if (mem[guess[i]] > 0)
                        {
                            //so now the bull count increases here and its value is reduced in the dictionary as it is a repetitive number
                            x = x + 1;
                            mem[guess[i]] = mem[guess[i]] - 1;
                        }
                        else if (y > 0)
                        {
                            x = x + 1;
                            y = y - 1;
                        }

                    }
                    //If this condition satisfies it increments the cows count
                    else if (mem.ContainsKey(guess[i]) && mem[guess[i]] > 0)
                    {
                        y = y + 1;
                        mem[guess[i]] = mem[guess[i]] - 1;

                    }
                }
                return x + "A" + y + "B";
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                List<int> result = new List<int>();
                Dictionary<char, int> alphaLast = new Dictionary<char, int>();
                //Initializing a dictionary of alphabets with -1 as value
                for (int i = 97; i < 123; i++)
                {
                    alphaLast[(Char)i] = -1;
                }
                //Populating the dictionary with the last position of each character present in the input string
                for (int i = s.Length - 1; i > -1; i--)
                {
                    if (alphaLast[s[i]] == -1)
                    {
                        alphaLast[s[i]] = i;
                    }
                }
                int minPosition = -1;
                String subString = "";
                //Iterating through the string again
                //Check if the current index of the char of string is equal to it's last position in the string (breaking condition)
                //If breaking condition happens then we have a substring which meets the requirement of the question i.e, we should have a certain char in only substring
                //Once the breaking condition happens we will reinitiate the subString and minPosition to "" and -1 respectively.
                //and repeat the first steps again
                for (int i = 0; i < s.Length; i++)
                {
                    int lastPosition = alphaLast[s[i]];
                    minPosition = Math.Max(lastPosition, minPosition);

                    if (minPosition == i)
                    {
                        subString += s[i];
                        result.Add(subString.Length);

                        minPosition = -1;
                        subString = "";
                    }
                    else
                    {
                        subString += s[i];
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                Dictionary<char,int> n = new Dictionary<char,int>();
                int sum = 0;
                int lc = 1;
                List<int> k = new List<int>();
                //This loop is created to link the width to each particular alphabet.
                for(int i = 97; i <= 122; i++)
                {
                    n.Add((char)i,widths[i - 97]);
                }
                //This loop increments the sum of the alphabets in string.
                for(int i = 0; i < s.Length; i++)
                {
                    sum = sum + n[s[i]];
                    //so now if the sum exceeds 100 it increments the line.
                    if (sum >= 100)
                    {
                        lc = lc + 1;
                        //if sum is exactly 100, it changes to zero for the count of new line
                        if (sum == 100)
                        {
                            sum = 0;
                        }
                        //if the sum is more than 100, it return the modulo. so that it does not miss the previous value that lead to rise the sum above 100.
                        else
                        {
                            sum = sum % (sum - n[s[i]]);
                        }
                        
                    }
                    
                    
                }
                
                if (sum == 0)
                {
                    k.Add(lc - 1);
                    k.Add(100);
                }
                //As we know if the sum is above 100, it should move to the next line and return sum in that line..
                else
                {
                    k.Add(lc);
                    k.Add(sum);
                }
                
                
                

                return k;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                //Gave values and keys to the dictionary as following.
                Dictionary<char, int> x = new Dictionary<char, int>();
                x.Add('(', 1);
                x.Add(')', -1);
                x.Add('[', 2);
                x.Add(']', -2);
                x.Add('{', 3);
                x.Add('}', -3);

                int sum2 = 0;
                //if bullsstring length is odd directly returning false
                if (bulls_string10.Length % 2 != 0)
                {
                    return false;
                }
                //Now if not zero goes into this loop
                for (int i = 0; i < bulls_string10.Length - 1; i++)
                {
                    sum2 = 0;
                    //CHecking concurrent brackets if indice is even, so that sum should be zero, as the brackets are given values accordingly
                    if (i % 2 == 0)
                    {
                        sum2 = x[bulls_string10[i]] + x[bulls_string10[i + 1]];
                        if (sum2 == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }



                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }



        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                string[] m = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
                    ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};
                string[] k = new string[1000];
                int count = 0;
                Dictionary<char, string> n = new Dictionary<char, string>();
                //Assigns each character to the index specific morsecode.
                for (int i = 97; i < 123; i++)
                {
                    n.Add((char)i, m[i - 97]);
                }
                //concatenates the characters of each string in the array in morse code format
                for (int j = 0; j < words.Length; j++)
                {
                    for (int i = 0; i < words[j].Length; i++)
                    {
                        k[j] = k[j] + n[words[j][i]];
                    }
                }
                //compares the elements to return the number of different transformations.
                for (int i = 0; i < k.Length; i++)
                {
                    bool check = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (k[i] == k[j])
                        {
                            check = true;
                            break;
                        }
                    }

                    if (!check)
                    {
                        count++;

                    }
                }


                return (count - 1);
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}