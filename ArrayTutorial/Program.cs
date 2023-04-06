// See https://aka.ms/new-console-template for more information
using ArrayTutorial;

Console.WriteLine("Hello, World!");


Array intArray1 = Array.CreateInstance(typeof(int), 5);
for(int i = 0; i < 5; i++) {

    intArray1.SetValue(3 * i, i);
}

for(int i = 0; i < 5; i++) {
    Console.WriteLine(intArray1.GetValue(i));
}

int[] intArray2 = (int[])intArray1;

// multi-dimensional arrays
int[] lengths = { 2, 3 };
int[] lowerBounds = { 1, 10 };

Array racers = Array.CreateInstance(typeof(Person), lengths, lowerBounds);

racers.SetValue(new Person("Dominion", "Lloyd"), 1, 10);
racers.SetValue(new Person("Emem", "Lloyd"), 1, 11);
racers.SetValue(new Person("Emerson", "Fittipaldi"), 1, 12);
racers.SetValue(new Person("Michael", "Schumacher"), 2, 10);
racers.SetValue(new Person("Fernando", "Alonso"), 2, 11);
racers.SetValue(new Person("Jenson", "Button"), 2, 12);

Person[,] racers2 = (Person[,])racers;
Person first = racers2[1, 10];
Person last = racers2[2, 12];

// Copying Arrays
int[] intArray3 = { 1, 2 };
int[] intArray4 = (int[])intArray3.Clone(); // primitive types are copied

Person[] beatles = {
    new("John", "Lennon"),
    new("Paul", "McCartney")
};

Person[] beatlesClone = (Person[])beatles.Clone(); // reference types a reference not copied

// Array Sorting
string[] names = {
"Jesus",
"Apostle Paul",
"Apostle Peter" };

Array.Sort(names);

foreach(var name in names) {
    Console.WriteLine(name);
}

Person[] persons = {
    new Person("Damon", "Hill"),
    new Person("Niki", "Lauda"),
    new("Ayrton", "Senna"),
    new("Graham", "Hill")
};

Array.Sort(persons);

foreach(var person in persons) {
    Console.WriteLine(person);
}

Console.WriteLine();

var persons2 = persons.GetEnumerator();

while(persons2.MoveNext()) {

    var person = (Person)persons2.Current;
    Console.WriteLine(person);
}


HelloCollection helloCollection = new();

foreach(string s in helloCollection) {
    Console.WriteLine(s);
}

MusicTitles titles = new();

Console.WriteLine("\nMusic Titles");
foreach(var title in titles) {

    Console.WriteLine(title);
}

Console.WriteLine("\nMusic Titles - Reverse");
foreach (var title in titles.Reverse())
{

    Console.WriteLine(title);
}

Console.WriteLine("\nMusic Titles - Subset");
foreach (var title in titles.Subset(2, 2))
{

    Console.WriteLine(title);
}


Console.ReadKey();

static Span<int> IntroSpans() {

    int[] arr1 = { 1, 4, 5, 11, 13, 18 };
    Span<int> span1 = new(arr1);
    span1[1] = 11;
    Console.WriteLine($"{arr1[1]} is changed vair {span1[1]}: {arr1[1]}");
    return span1;
}

static Span<int> CreateSlices(Span<int> span1)
{
    Console.WriteLine(nameof(CreateSlices));

    int[] arr2 = { 3, 5, 7, 9, 11, 13, 15 };
    Span<int> span2 = new(arr2);
    Span<int> span3 = new(arr2, start: 3, length: 3);
    Span<int> span4 = span1.Slice(start: 2, length: 4);

    DisplaySpan("content of span3", span3);
    DisplaySpan("content of span4", span4);

    Console.WriteLine();
    return span2;
}

static void DisplaySpan(string title, ReadOnlySpan<int> span) {
    Console.WriteLine(title);

    for(int i = 0; i < span.Length; i++) {
        Console.Write($"{span[i]}.");
    }

    Console.WriteLine();
}

static void ChangeValues(Span<int> span1, Span<int> span2) {
    Console.WriteLine(nameof(ChangeValues));
    Span<int> span4 = span1.Slice(start: 4);
    span4.Clear(); // set all items to zero
    DisplaySpan("content of span 1", span1);

    Span<int> span5 = span2.Slice(start: 3, length: 3);
    span5.Fill(42);
    DisplaySpan("content of span2", span2);

    span5.CopyTo(span1);
    DisplaySpan("content of span1", span1);

    if (!span1.TryCopyTo(span4)) {
        Console.WriteLine("Couldn't copy span1 to span4 because span4 is too small");
        Console.WriteLine($"length of span4: {span4.Length}, length of span1: {span1.Length}");
    }

    Console.WriteLine();
}

static void ReadOnlySpanTest(Span<int> span1)
{
    Console.WriteLine(nameof(ReadOnlySpanTest));
    int[] arr = span1.ToArray();
    ReadOnlySpan<int> readonlySpan1 = new(arr);
    DisplaySpan("readonlySpan1", readonlySpan1);

    ReadOnlySpan<int> readonlySpan2 = span1;
    DisplaySpan("readonlySpan2", readonlySpan2);
    ReadOnlySpan<int> readonlySpan3 = arr;
    DisplaySpan("readOnlySpan3", readonlySpan3);
    Console.WriteLine();
}


// public record Person(string FirstName, string LastName);

public record Person(string FirstName, string LastName) : IComparable<Person> {
    public int CompareTo(Person? other) {
        if (other == null) return 1;
        int result = string.Compare(this.LastName, other.LastName);
        if ( result == 0)
        {
            result = string.Compare(this.FirstName, other.FirstName);
        }
        return result;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}