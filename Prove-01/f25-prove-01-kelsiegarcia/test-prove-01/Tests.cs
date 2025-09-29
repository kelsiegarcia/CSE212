using System.IO.Compression;
using System.Text.RegularExpressions;
using static prove_01.Lists;

using NUnit.Framework;

public class Tests
{
    [Test]
    public void TestMultiples1()
    {
        double[] result = MultiplesOf(7, 5);
        double[] expected = [7, 14, 21, 28, 35];
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestMultiples2()
    {
        double[] result = MultiplesOf(1.5, 10);
        double[] expected = [1.5, 3, 4.5, 6, 7.5, 9, 10.5, 12, 13.5, 15];
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestMultiples3()
    {
        double[] result = MultiplesOf(-2, 10);
        double[] expected = [-2, -4, -6, -8, -10, -12, -14, -16, -18, -20];
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestRotateRight1()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        RotateListRight(numbers, 1);
        List<int> expected = [9, 1, 2, 3, 4, 5, 6, 7, 8];
        Assert.That(numbers, Is.EqualTo(expected));
    }

    [Test]
    public void TestRotateRight2()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        RotateListRight(numbers, 5);
        List<int> expected = [5, 6, 7, 8, 9, 1, 2, 3, 4];
        Assert.That(numbers, Is.EqualTo(expected));
    }

    [Test]
    public void TestRotateRight3()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        RotateListRight(numbers, 3);
        List<int> expected = [7, 8, 9, 1, 2, 3, 4, 5, 6];
        Assert.That(numbers, Is.EqualTo(expected));
    }

    [Test]
    public void TestRotateRight4()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        RotateListRight(numbers, 9);
        List<int> expected = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        Assert.That(numbers, Is.EqualTo(expected));
    }

    [Test]
    public void TestWordDocumentUpdated()
    {
        var responseDocument = new FileInfo("../../../../prove-01/01-prove_response.docx");
        var zipArchive = ZipFile.Open(responseDocument.FullName, ZipArchiveMode.Read);
        Assert.That(responseDocument.Exists, Is.True);
        var sr = new StreamReader(zipArchive.GetEntry("word/document.xml")!.Open());
        var textOfWordDocument = Regex.Replace(Regex.Replace(sr.ReadToEnd(), "<.*?>", string.Empty), "prove-01.*?repository", string.Empty);
        var unchangedDocument =
            "\r\nCSE 212 – Programming with Data Structures W01 Prove – Response DocumentName:Date:Teacher:It is a violation of BYU-Idaho Honor Code to post or share this document with others or to post it online.  Storage into a personal and private repository (e.g. private GitHub repository, unshared Google Drive folder) is acceptable.Question 1:  For the rotate right problem, provide a description of how you solved the problem.Question 2:  For the rotate right problem, draw a picture of how you solved the problem.Remember:  You need to commit all the changes to the  along with this document. Then submit a link to the repository in I-Learn. ";
        // responseDocument.CreationTimeUtc
        Assert.That(textOfWordDocument, Is.Not.EqualTo(unchangedDocument), "You need to edit and save the response document (01-prove_response.docx)");
    }
}