using System.Collections;
using System.Diagnostics.Tracing;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        // base case
        if (n<=0)
        {
            return 0;
        }
        
        else
        {   //smaller problem n to the power of two plus the n-1 to the pwer of two
            return n*n + SumSquaresRecursive(n-1);
        }

    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size)
        {
            results.Add(word);
            return; // Stop
        }
        
        // Add each available letter
        for (var i = 0; i < letters.Length; i++)
        {
            // Remove the letter at index i so it is not used in the next function call
            var lettersLeft = letters.Remove(i, 1);
            // Add the letter to the 'word' string and call the function again
            PermutationsChoose(results, lettersLeft, size, word + letters[i]);
        }

    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        // If this is the first time calling the function, then
        // we need to create the dictionary.
        if (remember == null)
            remember = new Dictionary<int, decimal>();


        // Check if we have solved this step before
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
       
        // Remember result before returning
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        // Find the first wildcard
        int index = pattern.IndexOf('*');

        // If no wildcards found, return the results
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        
        // Replace the '*' at 'indext'
        // Split the pattern into two parts. One before the '*'
        // and one after the '*'. Replace the '*' with '0' or '1'
        string beforeWildcard = pattern[..index];
        string afterWildcard = pattern[(index + 1)..];

        //Replace '*' with '0'
        WildcardBinary(beforeWildcard + '0' + afterWildcard, results);

        // Replace '*' with '1'
        WildcardBinary(beforeWildcard + '1' + afterWildcard, results);

    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path
        currPath.Add((x, y));
        // TODO Start Problem 5
        // Check if we reached the end of the maze
        if (maze.IsEnd(x, y))
        {
            // Add path to the results array keeping track of complete maze solutions
            results.Add(currPath.AsString());
        }
        else
        {
            // Possible movements
            var moves = new (int nextX, int nextY)[] {(x, y-1), (x, y+1), (x-1, y), (x+1, y)};

            foreach (var move in moves)
            {
                // Check if moving to the next square is within boundaries, not a wall, and not visited
                if (maze.IsValidMove(currPath, move.nextX, move.nextY))
                {
                    // Check the next square
                    SolveMaze(results, maze, move.nextX, move.nextY, currPath);
                }
            }

        }
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
        // Remove the current square from the path before returning to the previous call
        currPath.RemoveAt(currPath.Count - 1);
    }
}