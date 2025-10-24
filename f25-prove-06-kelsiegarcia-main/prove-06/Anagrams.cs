namespace prove_06;

public static class Anagrams {
    /// <summary>
    /// <p>Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.</p>
    /// <p>Examples:</p>
    /// <p><c>is_anagram("CAT","ACT")</c> would return true</p>
    /// <p><c>is_anagram("DOG","GOOD")</c> would return false because GOOD has 2 O's</p>
    /// <p>Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces. You should also ignore cases. For 
    /// example, 'Ab' and 'Ba' should be considered anagrams</p>
    /// <p>Reminder: You can access a letter by index in a string by 
    /// using the [] notation.</p>
    /// </summary>
    public static bool IsAnagram(string word1, string word2) {
        word1 = new string(word1
            .ToLower()
            .Where(char.IsLetter)
            .OrderBy(c => c)
            .ToArray());

        word2 = new string(word2
            .ToLower()
            .Where(char.IsLetter)
            .OrderBy(c => c)
            .ToArray());

        return word1 == word2;
    }
}