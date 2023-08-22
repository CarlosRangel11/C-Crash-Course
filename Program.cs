using System;   //using directive is used to call different namespaces for use in current file/method
public class MyFirstClass {
    // main entrance into program, like Java
    // public, accessed from other classes in program
    // static, belongs to itself, no need to create an object to call
    // void, no return value
    public static void Main() {
        Console.WriteLine("Hello, World!");

        Console.WriteLine("This program is just meant for me to test drive a lot of C# fundamentals.");

        ////////////////////////////////////////////////////////////////////////////////////////
        ///Types that are in C++ and C#
        ///

        // 8 bit types (byte)
        bool yn = false;        // technically 1 bit but depends on compiler
        char letter = 'K';

        // 16 bits (2 bytes)
        // signed, unsigned variants
        int num1 = 69;
        short smallNum = 3;

        // 32 bits (4 bytes)
        long largeNum = 2000000000;
        
        //float & double have different precisions in c# mentioned later


        ////////////////////////////////////////////////////////////////////////////////////////
        /// Types that have been introduced in C#
        /// 

        // 8 bits (byte)
        byte verySmallNum = 3;

        // explicit variant of integer types
        // number after Int defines how many bits
        Int32 normalInt = 45;
        Int64 longInt = 4500000000;

        // floats in c# have 7 decimal precision (range = +-3.4 * 10^38)
        float num4 = 2.751F;            //use F at the end

        // doubles have 16 decimal precision (range = +-1.7 * 10^308)
        double num5 = 2.0000000070;

        // 128-bits (16 bytes :o)
        // 28 decimal precision, but less range (+-7.9 * 10^28)
        decimal accurateNum = 2.000000000000000000000000000003M;        //use M at the end

        // chars have 16 bits (2 bytes) to handle unicode standards

        // 16 * lengh
        // strings are sequences of Unicode chars
        string yo = "Hello, World!";
        string test = string.Empty;     //best to initialize them to not use object & not use null

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// basic implementation of objects and OOP in C#
        /// 
        
        // First create an instance of the class using a constructor
        TempConverter converter = new TempConverter();

        Console.Write("Please enter Number to covert from fahrenheit to celcius: ");
        string input = Console.ReadLine();
        float numToConvert = float.Parse(input);

        // now we can access methods in that constructed class instance using '.'
        // structure: 
        // <classInstanceName>.<method/memberName>
        float convertedNum = converter.getCelcius(numToConvert);

        // The '$' operator before a string allows for interpolation, which is another way to 
        // insert variables into strings. 
        Console.WriteLine($"{numToConvert} in celcius is {convertedNum}");

        Console.Write("Please enter Number to covert from celcius to fahrenheit: ");
        input = Console.ReadLine();
        numToConvert = float.Parse(input);

        convertedNum = converter.getFahrenheit(numToConvert);
        Console.WriteLine($"{numToConvert} in fahrenheit is {convertedNum}");


        ReferencesExample myPoint = new ReferencesExample(10);      //initilize x in object to be 10
        myPoint.GetPoint_out(out int x);    //sets x while being initialized in the method
        x = 0;
        myPoint.GetPoint(ref x);            // x in parameter to change x using an obj method. 


        //////////////////////////////////////////////////////////////////////////////////////////
        /// Pointers (yay ;-;)
        /// 

        // Important operators:
        // & :: address-of => returns the memory ADDRESS of a given variable
        // * :: pointer-Dereferencer => returns the VALUE stored at a given address

        // to use pointers and addresses, you need to declare a block using the 'unsafe' keyword (so dramatic O_O)
        unsafe {        
            int randomNumber = 45;

            // "integer pointer 'pointerToNumber' equals the address of 'randomNumber"
            int* pointerToNumber = &randomNumber;   

            // using '*' allows access to the VALUE at the pointer 'pointerToNumber', which actually holds an address
            int value = *pointerToNumber;
        }

        // below, I have created a class that has an unsafe (pointer) method that 
        // uses the power of pointers to swap 2 values using the pointer aliases
        PointerExample p = new PointerExample();
        int a = 10;
        int b = 20;

        Console.WriteLine($"Before:\na: {a}\nb: {b}");
        unsafe { p.Swap(&a, &b); }
        Console.WriteLine($"After:\na: {a}\nb: {b}");

        // using variables containing memory addresses can be very useful in storing different areas of memory
        // particulary in creating data structures such as linked lists or BST's

        //////////////////////////////////////////////////////////////////////////////////////////
        /// The C# Unified System
        /// 

        // C# has a type system that makes the value of every data type an object. 
        // this makes references and values share the same roots through System.Object, allowing
        // for very unique (and somewhat javascripty) value relationships. All types derive from 'object'
        // The benefit of this type-relationship is that you no longer have to wrap classes and types to 
        // allow general functionality in classes and methods. 

        // Boxing is a processes that the compiler uses to convert a value to a reference
        // Unboxing is undoing that process and explicitely casting a reference as a type
        int v = 100;
        Console.WriteLine($"Value of V: {v}");  //WriteLine() accepts objects and references only

        // to unbox the integer 'v', you can cast it with an '(int)' wrapper
        int v2 = (int)v;

        //it is important to note that boxing and unboxing generate different VARIABLES. 
        // In the example below, modifying the original variable does not modify the boxed variable
        int val = 55;
        object box = val;                       // 'object' tyeps are the ultimate base classes for all types
        val = val * 2;                          //
        Console.WriteLine($"val = {val}");      // val = 110
        int val2 = (int)box;                    // unboxing 'box' and placing it in val2
        Console.WriteLine($"val2 = {val2}");    // val2 = 55

        //////////////////////////////////////////////////////////////////////////////////////////
        /// C#'s Memory Management
        /// 

        // Memory in C# is handled by the runtime system and is divided into 3 main areas

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Static: 
        // Variables and methods declared with the 'static' keyword.  
        // Memory for static variables is allocated when the program starts and are cleared when the program ends
        // Important traits of static variables
        // During compilation, static variables have only one copy of memory, regardless of how many objects
        // are created. This results in changes made to a static variable in one object having changes to that
        // static variable in all object instances. 

        // For example:
        /*
        void login() {
            static int counter = 0;     // only one initialization
            readID_password();
            if(verified())
                counter++               //increments per user logged in
        }*/

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // The Stack:
        // Used to store value types, return addresses and variables. 
        // structured as it's name implies (Last-in, First out). 
        // The Stack is fast and intuitive to use for these memory objects because of the nature the datastructure
        // The big issue with the stack is that the size is limited, which can lead to overflow. 



        // The Heap:
        // Used to store dynamic memory, such as objects, arrays, strings, etc. 
        // A heap datastructure is a dynamic tree-like structure based off of an array (usually). 
        // THE heap uses this datastructure to its advantage to allow for unlimited size (up to the virtual mem limits)
        // Downsides to the heap is more complex allocation/deallocation, and slower operation use. 
        // the new() keyword is used to allocate memory on the heap for all non-static class variables and objects. 

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Understanding the grand memory of computers can help a lot when optimizing memory and runtime, 
        // as different areas of memory have different strengths and weaknesses/
        // Starting address ---->  ____________________
        //                        |   Global Funcs     |    size known at compilation time
        //       Static           |____________________|
        //       Memory           |                    |    size known at compilation time
        //                        |   Global/static    |
        //                        |    variables &     |
        //                        |      objects       |
        //                        |____________________|
        //      Heap pointer ---->|        Heap        |    objects/functions/methods created
        //                        |          |         |    using 'new' keyword
        //                        |          |         |
        //                        |          v         |
        //                        |          ^         |
        //                        |          |         |
        //                        |          |         |    All local variables and 
        //    Stack Pointer ----->|________Stack_______|    Instance variables
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////





    }


    //////////////////////////////////////////////////////////////////////////////////////////////
    /// insights into classes, methods and parameters
    /// 

    // passing parameters by reference gives the function or method access to permanently 
    // change the value of a parameter

    // This is a basic public class that has a getter, and 2 reference modifier methods.
    // Encapsulation is the act of bundling these variables and methods in classes to restrict direct access to
    // components and data. 
    public class ReferencesExample {
        protected int x;        // protected values/methods/classes can only be accessed by derived/inherited classes
        private int y = 5;      // private values/methods/classes can only be accessed by their defining class

        // passing parameters by reference gives the function or method access to permanently 
        // change the value of a parameter
        public ReferencesExample(int x) {
            this.x = x;
        }

        // the .NET framework has automatic garbage collection for objects, but you should create
        // a destructor for unmanaged resources such as files, connection services, or other unmanaged resources
        // it's best to create a destructor or an IDisposable to deallocate those


        //this modifies the variable x that is passed through to this method directly. 
        public void GetPoint(ref int x) {
            x = this.x;
        }

        //out is another reference keyword that allows uninitialized params to get passed. 
        public void GetPoint_out(out int x) {
            x = this.x * y;
        }
    };

    // This is a class that Inherits from the ReferencesExample class, which means
    // the InheritedPoint class has access to all public and protected members of ReferencesExample
    // Inheritence is great to promote code reusability, as well as to establish relationships between classes
    public class InheritedPoint : ReferencesExample {
        public InheritedPoint(int x) : base(x) {
            this.x = x;
        }

        public int getX() {
            return this.x;
        }

        // Polymorphism is allowing objects and classes to be treated as objects/classes of a superclass
        // You can either use the 'override' keyword to overload 2 methods in the same class, or 
        // just redefine a method from a base class in a derived class to do something different. 
        public void GetPoint(int x) {
            x = -1;
        }
    };

    // Abstraction is the act of hiding functionality of different classes/functions and only exposing 
    // the way to use those methods/classes/objects, rather than showing how they achieve outputs. 
    // you can either create interfaces or abstract classes to engage in abstraction in C# (and java)
    
    // Interfaces are declarative templates that do no implement anything. They are only public, and 
    // are able to be used by classes inherently. 
    public interface OnlineShoppingSite {
        int GetPrice(object item);
        bool hasMembership(object Shopper);
        // etc. 
    }

    // Abstract classes can contain both declarations and defined, implemented methods. They can be 
    // public, private and protected. Classes can only inherit from one abstract classes, but the abstract class
    // can be totally defined with no abstraction (weird). 
    public abstract class Vehicle {
        private string VIN;
        public int Wheels { get; set; }
        public abstract float OilLevel();
        public string GetVIN() {
            return this.VIN;
        }
        

    //basic class to use in above example that converts values between fahrenheit and celcius
    //Structure: 
    //[attribute] modifier] class <className> : [inheritedClass]
    public class TempConverter {
        //from celcius to fahrenheit
        public float getFahrenheit(float celciusNum) {
            return celciusNum * 9 / 5 + 32;
        }
        //from fahrenheit to celcius
        public float getCelcius(float fahrenheitNum) {
            return (fahrenheitNum - 32) * 5 / 9;
        }
    };

    // basic class that has a method that uses pointers to swap 2 values. 
    public class PointerExample {
        // just to call in the main function
        public PointerExample() { }
        unsafe public void Swap(int *x, int* y) {
            int temp = *x;
            *x = *y;
            *y = temp;
        }
    };
}