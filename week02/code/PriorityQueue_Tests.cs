using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority: "High", "Medium", "Low"
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority
    // Expected Result: Items with same priority should follow FIFO - "First", "Second", "Third"
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, including duplicates
    // Expected Result: High priority first, then FIFO for same priorities
    // Defect(s) Found: 
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        // Priority 5 items first (FIFO: B, then D)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        // Priority 3 items next (FIFO: A, then C)
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        // Priority 1 item last
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue alternately
    // Expected Result: Each dequeue should return the highest priority item available at that time
    // Defect(s) Found: 
    public void TestPriorityQueue_AlternateOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue()); // Remove High

        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Higher", 4);

        Assert.AreEqual("Higher", priorityQueue.Dequeue()); // Remove Higher (priority 4)
        Assert.AreEqual("Medium", priorityQueue.Dequeue()); // Remove Medium (priority 3)
        Assert.AreEqual("Low", priorityQueue.Dequeue());    // Remove Low (priority 1)
    }

    [TestMethod]
    // Scenario: Enqueue items in reverse priority order
    // Expected Result: Should still dequeue in correct priority order
    // Defect(s) Found: 
    public void TestPriorityQueue_ReversePriorityOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple same-priority groups
    // Expected Result: Highest priority group dequeued first (in FIFO), then next group
    // Defect(s) Found: 
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("P2-First", 2);
        priorityQueue.Enqueue("P5-First", 5);
        priorityQueue.Enqueue("P3-First", 3);
        priorityQueue.Enqueue("P5-Second", 5);
        priorityQueue.Enqueue("P2-Second", 2);
        priorityQueue.Enqueue("P3-Second", 3);

        // Priority 5 (FIFO)
        Assert.AreEqual("P5-First", priorityQueue.Dequeue());
        Assert.AreEqual("P5-Second", priorityQueue.Dequeue());
        // Priority 3 (FIFO)
        Assert.AreEqual("P3-First", priorityQueue.Dequeue());
        Assert.AreEqual("P3-Second", priorityQueue.Dequeue());
        // Priority 2 (FIFO)
        Assert.AreEqual("P2-First", priorityQueue.Dequeue());
        Assert.AreEqual("P2-Second", priorityQueue.Dequeue());
    }
}