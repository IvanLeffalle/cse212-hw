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
        var multiples = new double[length]; // Step 1: Create an array of doubles with the specified length
        for (int i = 0; i < length; i++) // Step 2: Loop through each index of the array
        {
            multiples[i] = number * (i + 1); // Step 3: Calculate the multiple and assign it to the array
        }
        return multiples; // Step 4: Return the populated array

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

        if( data == null) //Step 1 : input validation
        {
            throw new ArgumentNullException(nameof(data), "The data list cannot be null");
        }
           if (amount <= 0 || amount > data.Count)
        {
            throw new ArgumentException("Amount must be between 1 and data.Count (inclusive).", nameof(amount));
        }
         // Step 2: handle trivial cases (if data is empty or amount equals the full length)
        // (Note: amount > 0 by validation; check amount == data.Count to short-circuit)
            if (data.Count == 0 || amount == data.Count)
        {
            // rotating by the full length yields the same list
            return;
        }

         // Step 3: capture the tail segment (last 'amount' items)
         int startIndex = data.Count - amount;
         List<int> tail = data.GetRange(startIndex, amount);

        // Step 4: remove that tail segment from the original list
        data.RemoveRange(startIndex,amount);

        //Step 5: insert the tail at the front (index 0)
        data.InsertRange(0, tail);

        //Step 6: Finish, the data list is modified in place
    }
}
