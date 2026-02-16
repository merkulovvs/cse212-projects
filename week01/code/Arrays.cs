using System.Runtime.Serialization;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // Implementation 1
        // Set the currentNum variable to number.
        double currentNum = number;
        // Create a fixed array size length
        var result = new double[length];


        for (int i = 0; i < length; i++)
        {
            if (i == 0) // At the index 0 insert the number
                result[i] = number;
            else // Starting from index 1
                currentNum += number; // Incerase the currentNum by number
                result[i] = currentNum; // Insert currentNum to the result array

        }

        return result; // replace this return statement with your own

        // Implementation 2 (improved)
        //var result = new double[length]; // Create a fixed array size length
        //for (int i = 0; i < length; i++)
        //{
        //     result[i] = number*(i + 1); // To get rid of if...else statement we multiply the number at index 0 by (0 + 1).
    
        //}

        //return result;



    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // 1. Create a slicedList that will hold the sliced portion of data list.
        // 2. Slice the portion of data list determined by the amount value.
        // 3. Remove the sliced portion from the data list.
        // 4. Insert the sliced portion from the slicedList into the data list.

        // Slicing the portion of data list determined by the amount value.
        // Adding the sliced portion to the slicedList list.
        List<int> slicedList = data.GetRange(data.Count - amount, amount);
        
        // Removing the sliced portion from the data list.
        data.RemoveRange(data.Count - amount, amount);
        // Inserting the sliced portion of the list from the right to the front of the
        // data list at index 0.
        data.InsertRange(0, slicedList);
        
    }
}
