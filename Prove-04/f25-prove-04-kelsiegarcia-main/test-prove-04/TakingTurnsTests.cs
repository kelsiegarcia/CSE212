using NUnit.Framework;
using prove_04;

public class TakingTurnsTests
{
    [Test]
    public void TestTakingTurns1()
    {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        //           run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        Console.WriteLine(players);    // This can be un-commented out for debug help
        var results = new List<string>();
        while (players.Length > 0)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
            (string[]) ["Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim"]));
        Assert.That(players.Length, Is.EqualTo(0));

        // Defect(s) Found:
        // Both Test 1 and Test 2 failed 
        // due to this same root cause.
        // The queue produced a LIFO (Last In, First Out) order instead of the expected FIFO (First In, First Out).
        // The first output value was incorrect ("Sue" instead of "Bob"), indicating that the queue was adding new
        // people to the front rather than the end.
        // Root Cause: The PersonQueue.Enqueue() method used Insert(0, person), which reversed the order of entries.
        // Fix: Changed Enqueue() to use Add(person) so new people are appended to the end of the queue.
        // Verified Output (before fix):
        // [(Sue:3), (Tim:5), (Bob:2)]
        // Sue
        // Sue
        // Sue
        // Tim
        // Tim
        // Tim
        // Tim
        // Tim
        // Bob
        // Bob

        
    }

    [Test]
    public void TestTakingTurns2()
    {
        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        //           After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);

        var results = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            results.Add(players.GetNextPerson());
        }

        players.AddPerson("George", 3);
        while (players.Length > 0)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
        new []{
            "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim",
            "George", "Sue", "Tim", "George", "Tim", "George"
        }));
        Assert.That(players.Length, Is.EqualTo(0));
        // Defect(s) Found:
        // Both Test 1 and Test 2 failed 
        // due to this same root cause.
        // The output had the correct number of items, but the first value was incorrect ("Sue" instead of "Bob").
        // It also returned a List instead of an array.
        // Root Cause: The PersonQueue.Enqueue() method used Insert(0, person), which reversed the order of items,
        // causing the queue to behave like a stack (LIFO) instead of a queue (FIFO).
        // Fix: Changed Enqueue() to use Add(person) to append to the end of the list.
        // Verified: Output now matches the expected order and passes the test.

    }

    [Test]
    public void TestTakingTurns3()
    {
        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        //           Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        Console.WriteLine(players);
        var results = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            results.Add(players.GetNextPerson());
        }

        Assert.That(results, Is.EqualTo(
            (string[]) ["Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim"]));

        // Tim is the only one left
        Assert.That(players.Length, Is.EqualTo(1));

        // Defect(s) Found: After it shows Bob twice, Tim once, and Sue three times, it errors by saying 
        // "No one in the queue." After adding breakpoints, I saw that it starts showing _people as null. 
        // I think it's running through the people who have limited turns, and once it gets to Tim (Forever), 
        // it throws the error because it hasn’t re-added Tim to the queue yet.
        // Root cause: The re-enqueue condition only checked if the turn was > 1 the players with 
        // <= 0 turns were not being added cause it the line to empty and throw an error
        // Fix: add another if statement and condition to check for  turn > 1 || or turn <= 0 to guarantee
        // those with turns like Tim (forever) will be readded to the queue.
        //[(Bob:2), (Tim:Forever), (Sue:3)]
        // Bob
        // Tim
        // Sue
        // Bob
        // Tim
        // Sue
        // Tim
        // Sue
        // Tim
        // Tim
    }

    [Test]
    public void TestTakingTurns4()
    {
        // Test 4
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        var players = new TakingTurnsQueue();
        try
        {
            players.GetNextPerson();
            Assert.Fail("The code should fail with an exception");
        }
        catch (InvalidOperationException)
        {
            Assert.Pass("You should have had an exception");
        }

        // Defect(s) Found: Don't think this had any errors. If it did it was fixed with the last test.
    }
}