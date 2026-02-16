public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // Initiate a rusult array with the capacity of the lenght of the select array
        var result = new int[select.Length];
        int l1Index = 0; // Variable that will save current index in the first array
        int l2Index = 0; // Variable that will save current index in the second array
        for (int i=0; i < select.Length; i++)
        {
            if (select[i] == 1) // If value in select array equals to 1
            {
                result[i] = list1[l1Index++]; // Add the value from the current index of the first array and increment index by 1

                
            }
            else // If value in select array equals to 2
                result[i] = list2[l2Index++]; // Add the value from the current index of the second array and increment index by 1
        }
        return result;
    }
}