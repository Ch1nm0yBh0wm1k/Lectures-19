// See https://aka.ms/new-console-template for more information
//using System.Runtime.InteropServices;

//Console.WriteLine("Hello, World!");

//Person person = new Person();
//person.PrintSomething();
//class
//class Person
//{
//    string name; //field
//    string age;

//    public void PrintSomething()//methid
//    {
//        Console.WriteLine("Hi");
//    }
//}

//constructor

//Person person2 = new Person();
//Console.WriteLine(person2.name);

//Person person3 = new Person("Rafi", 20);
//Console.WriteLine(person3.name);

//class Person
//{
//    public string name; //field
//    public int age;
//    //default constructor
//    public Person() 
//    {
//        name = "abcd";
//        age = 2;
//    }
//    //parameterized constructor
//    public Person(string Name, int Age)
//    {
//        name = Name;
//        age = Age;
//    }

//    public void PrintSomething()//methid
//    {
//        Console.WriteLine("Hi");
//    }
//}

//Access Modifier
//--public, private, protected, internal
//public
//Person person1 = new Person();
//Console.WriteLine(person1.age);
////private
//Console.WriteLine(person1.RetValue());
//protected
//Console.WriteLine(person1.name);
//Car car1 = new Car();
//Console.WriteLine(car1.ReturnProtected());

//class Person
//{
//    public int age= 2;
//    private string pwd = "jhvcsadjch";
//    protected string name = "rahul";
//    public string RetValue()
//    {
//        return pwd;
//    }
//}

//class Car : Person
//{
//    public string ReturnProtected()
//    {
//        return name;
//    }
//}


//static use 

//Person person = new Person();
//Console.WriteLine(person.DoIncrement());//3

//Person person1 = new Person();
//Console.WriteLine(person1.age);//2

//Person person3 = new Person();
//Console.WriteLine(person3.DoIncrementStatic());//11

//Person person4 = new Person();
//Console.WriteLine(person4.DoIncrementStatic());//12

//class Person
//{
//    public int age = 2;

//    public static int age2 = 10;

//    public int DoIncrementStatic()
//    {
//        return ++ age2;
//    }

//    public int DoIncrement()
//    {
//        return ++age;
//    }
//}

//properties

//Person person = new Person();
//Console.WriteLine(person.Age); //2

//Person person1 = new Person();
//person1.Age = 100;
//Console.WriteLine(person1.Age); //100
//class Person
//{
//    private int age = 2;
//    //get used for read purpose, set for write
//    public int Age { get { return age; } set { age = value; } } //property
//}

//polymorphism


//method overloading

//Person person = new Person();
//person.GetSum(1, 2);
//person.GetSum(1.0F, 2.0F);
//person.GetSum(1.0D, 2.0D);


//class Person
//{
//    public void GetSum(int a, int b)
//    {
//        Console.WriteLine("I am Int");
//    }

//    public void GetSum(float a, float b)
//    {
//        Console.WriteLine("I am float");
//    }
//    public void GetSum(double a, double b)
//    {
//        Console.WriteLine("I am Double");
//    }
//}

//method overriding

//Person2 person = new Person2();
//person.GetSum(1, 2);


//class Person
//{
//    virtual public void GetSum(int a, int b)
//    {
//        Console.WriteLine("I am main");
//    }
//}

//class Person2 : Person
//{
//    override public void GetSum(int a, int b)
//    {
//        Console.WriteLine("I am overwritten");
//    }
//}


//abstraction
//Car car = new Car();
//car.SetValue();
//abstract class Person
//{
//    public int GetValue()
//    {
//        return 1;
//    }
//    abstract public int SetValue();

//}
//class Car : Person
//{
//    override public int SetValue()
//    {
//        return 1;
//    }
//}

//interface

interface IPerson
{
    public int RetVal();
}
interface IPerson2
{
    public int RetVal();
}

class Person5 : IPerson, IPerson2
{
    public int RetVal()
    {
        throw new NotImplementedException();
    }
}

class Person : IPerson
{
    public int RetVal()
    {
        return 2;
    }
}

class Car : Person
{

}

