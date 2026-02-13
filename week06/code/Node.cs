using System.Linq.Expressions;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {    
        // Check if the value is a duplicate
        if (value == Data)
        {
            return; 
        }
        // If value is less that the data in the current node
        else if (value < Data)
        {
            if (Left is null) // If there is no node to the left - create a new node and isert value
                Left = new Node(value);
            else // If node to the left exists - insert value
                Left.Insert(value);
        }
        else // If value is greater than the data in the current node
        {
            if (Right is null) // If there is no node to the right - create a new node and isert value
                Right = new Node(value);
            else // If node to the right exists - insert value
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // If value is greater than the data in current node - search the right
        // subtree.
        if (this.Data < value)
        {
            if (this.Right is not null) // If there is a node to the right
            {
                if (this.Right.Contains(value)) // Recursevely call the Contains function
                    return true;
                
            }
            else // If there is no node to the right - return false
                return false;
           
        }
        // If value is less that the data in the current node - search the left
        // subtree
        else if (this.Data > value)
        {
            if (this.Left is not null) // If there is a node to the left
            {
                if (this.Left.Contains(value)) // Recursevely call the Contains function
                    return true;
            }
            else
                return false; // If there is no node to the left - return false
            
        }
        else // The Base Case. this.Data == value
        {
            return true;
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight  = 0;
        int rightHeight = 0;

        // Recursively go throught the left branch
        if (this.Left is not null)
        {
            leftHeight = this.Left.GetHeight();            
        }   
        
        // Recursively go throught the right branch
        if (this.Right is not null)
        {
            rightHeight = this.Right.GetHeight();
        }
        
        // Return the maximum height plus one to account for the root
        if (leftHeight > rightHeight)
            return 1 + leftHeight;
        else
            return 1 + rightHeight;
        
           
        //return 0; // Replace this line with the correct return statement(s)
    }
}