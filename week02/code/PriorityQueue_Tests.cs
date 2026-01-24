using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test if the item with the highest priority 
    // Expected Result: sue
    // Defect(s) Found: actual result is bob
    // Fix: in Dequeue function implementation in the condition of the for loop replaced index < _queue.Count - 1 with index < _queue.Count 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("bob", 3);
        priorityQueue.Enqueue("jim", 1);
        priorityQueue.Enqueue("sue", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("sue", result);      

        //Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Test if between two items with the same priority the item that was added first will be dequeued first.
    // Expected Result: "jim"
    // Defect(s) Found: actual result is mik
    // Fix: In Dequeue function for loop if condition replaced >= to >.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("bob", 1);
        priorityQueue.Enqueue("jim", 3);
        priorityQueue.Enqueue("sue", 1);
        priorityQueue.Enqueue("mik", 3);
        

        
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("jim", result);      
        
        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}