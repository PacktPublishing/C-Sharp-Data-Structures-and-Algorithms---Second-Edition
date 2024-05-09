// BOOK READER
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

Page p1 = new("Welcome to the first chapter in which you start your amazing adventure with data structures and algorithms, in the context of the C# programming language. At the beginning, a short introduction to this language is shown. You will get to know how broad possibilities it has, in how many scenarios you can apply this language, as well as what are some basic constructions that you use. Of course, it is not the C# course, presenting various its features one-by-one, so only a brief description is shown here.");
Page p2 = new("While reading the first chapter of the book, you learned many interesting information about data types. So, now it is high time to introduce you the topic of algorithms. You will take a look at their definition, some real-world examples, notations, and types. As you should take care of performance of your applications, the computational complexity, including time complexity, is also presented and explained.");
Page p3 = new("As a developer, you have certainly stored various collections within your applications, such as data of users, books, and logs. One of the natural ways of storing such data is by using arrays. However, have you ever thought about their variants? For example, have you heard about jagged arrays? In this chapter, you will see arrays in action, together with examples and detailed descriptions.");
Page p4 = new("In the previous chapter you learned a lot about arrays and their types. Of course, an array is not the only way of storing data. Another popular and even more powerful group of data structures contains various variants of lists. In this chapter you will see such data structures in action, together with illustrations, explanations and descriptions.");
Page p5 = new("So far, you learned a lot about arrays and lists. However, these structures are not the only ones available. Among others, there is also a group of more specialized data structures, which are called limited access data structures.");
Page p6 = new("The current chapter focuses on data structures related to dictionaries and sets. A proper application of these data structures makes it possible to map keys to values and perform fast lookup, as well as to make various operations on sets. To simplify the understanding of dictionaries and sets, this chapter contains illustrations and code snippets, together with detailed descriptions.");

LinkedList<Page> pages = new();
pages.AddLast(p2);
LinkedListNode<Page> n4 = pages.AddLast(p4);
pages.AddLast(p6);
pages.AddFirst(p1);
pages.AddBefore(n4, p3);
pages.AddAfter(n4, p5);

LinkedListNode<Page> c = pages.First!;
int number = 1;
while (c != null)
{
    Console.Clear();
    string page = $"- {number} -";
    int spaces = (90 - page.Length) / 2;
    Console.WriteLine(page.PadLeft(spaces + page.Length));
    Console.WriteLine();

    string content = c.Value.Content;
    for (int i = 0; i < content.Length; i += 90)
    {
        string line = content[i..];
        line = line.Length > 90 ? line[..90] : line;
        Console.WriteLine(line.Trim());
    }

    Console.WriteLine($"\nQuote from \"C# Data Structures and Algorithms\"\nby Marcin Jamro, published by Packt in 2024.\n");
    Console.Write(c.Previous != null ? "< PREV [P]" : GetSpaces(14));
    Console.Write(c.Next != null ? "[N] NEXT >".PadLeft(76) : string.Empty);
    Console.WriteLine();

    ConsoleKey key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.N && c.Next != null)
    {
        c = c.Next;
        number++;
    }
    else if (key == ConsoleKey.P && c.Previous != null)
    {
        c = c.Previous;
        number--;
    }
}

string GetSpaces(int number) => string.Join(null, Enumerable.Range(0, number).Select(n => " "));
