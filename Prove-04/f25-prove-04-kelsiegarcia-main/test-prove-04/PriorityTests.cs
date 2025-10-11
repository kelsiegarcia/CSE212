using NUnit.Framework;
using prove_04;

public class PriorityTests
{
    [Test]
    public void TestPriority1()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Test 1
        // Scenario: I should be able to add items into the queue with different priorities (1, 2, 3)
        // Expected Result: The Dequeue should return items in descending priority order (3, 2, 1)

        var priorityQueue = new PriorityQueue(); // Example of creating and using the priority queue
        priorityQueue.Enqueue("Low", 6);
        priorityQueue.Enqueue("Medium", 7);
        priorityQueue.Enqueue("High", 8);
        
        var firstPriority = priorityQueue.Dequeue();
        var secondPriority = priorityQueue.Dequeue();
        var thirdPriority = priorityQueue.Dequeue();
        Console.WriteLine(priorityQueue);
        Assert.That(firstPriority, Is.EqualTo("High"));
        Assert.That(secondPriority, Is.EqualTo("Medium"));
        Assert.That(thirdPriority, Is.EqualTo("Low"));
        
        // Defect(s) Found: 
        // The output expected was "High" but it only found "Medium". 
        // Using breakpoints showed that the issue was in the _queue.Count - 1 logic. 
        // Changed it to _queue.Count so that it loops through the full count of the index 
        // instead of stopping one early. 
        // Another issue found with the same error message was that the highest-priority 
        // item wasn’t being removed from the list. 
        // This was diagnosed by printing out the queue after each dequeue and noticing 
        // the list never changed.
    }

    [Test]
    public void TestPriority2()
    {
        // Test 2
        // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue
        // will be removed and its value returned. Create distinct names for matching priorities so we can tell which item is closest to the
        // front of the queue

        // Expected Result: The item closest to the front of the queue that has a matching highest priority will be removed and returned first
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 6);
        priorityQueue.Enqueue("Medium1", 7);
        priorityQueue.Enqueue("High1", 8);
        priorityQueue.Enqueue("Medium2", 7);
        priorityQueue.Enqueue("High2", 8);
        priorityQueue.Enqueue("Low2", 6);
        
        var firstPriority = priorityQueue.Dequeue();
        Console.WriteLine($"After 1st dequeue: {priorityQueue}");

        var secondPriority = priorityQueue.Dequeue();
        var thirdPriority = priorityQueue.Dequeue();
        var fourthPriority = priorityQueue.Dequeue();
        var fifthPriority = priorityQueue.Dequeue();
        var sixthPriority = priorityQueue.Dequeue();
        
        Console.WriteLine(string.Join(", ", new [] { firstPriority, secondPriority, thirdPriority, fourthPriority, fifthPriority, sixthPriority }));
        
        Console.WriteLine("Final queue state: " + priorityQueue);
        
        Assert.That(firstPriority, Is.EqualTo("High1"));
        Assert.That(secondPriority, Is.EqualTo("High2"));
        Assert.That(thirdPriority, Is.EqualTo("Medium1"));
        Assert.That(fourthPriority, Is.EqualTo("Medium2"));
        Assert.That(fifthPriority, Is.EqualTo("Low1"));
        Assert.That(sixthPriority, Is.EqualTo("Low2"));
        
        // Defect(s) Found: If the same priority was given, it still fails. 
        //  if (_queue[index].Priority >= _queue[highPriorityIndex].Priority) logic comparison needed to be changed to > because >=
        // Makes the newly added items overwrite the older ones and now this > keeps FIFO structure.
        
    }
    
    [Test]
    public void TestPriority3()
    {
        // Test 3
        // Scenario:If the queue is empty, then an error message will be displayed.
        // Expected Result: 
        // If the queue is empty, then an error should be thrown with a printed message
        var priorityQueue = new PriorityQueue();

        var result = priorityQueue.Dequeue();
        Assert.That(result, Is.EqualTo(null));
        Console.WriteLine("Queue result: " + result);
        
        // Defect(s) Found: None :)
    
    }
}