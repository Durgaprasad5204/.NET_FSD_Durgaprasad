// Problem -3: Design a Basic Employee Management Module using TypeScript Classes
// Problem
// Learners need to implement object-oriented programming concepts in TypeScript such as constructors, access modifiers, inheritance, method overriding, and getters/setters by building a simple Employee Management system.
// Scenario
// You are developing a small module for an organization where different types of employees exist.
// The system should support:
// •	A base Employee class 
// •	A derived Manager class 
// •	Controlled access to properties 
// •	Customized behavior using method overriding

// Requirements
// 1. Create a Base Class: Employee
// •	Properties: 
// o	id (number) 
// o	name (string) 
// o	salary (number) 
// •	Use access modifiers: 
// o	id → public 
// o	name → protected 
// o	salary → private 
// •	Constructor to initialize all properties

// 2. Implement Getters and Setters
// •	Create: 
// o	getSalary() → return salary 
// o	setSalary(value: number) → update salary with validation (salary > 0)

// 3. Create a Method
// •	displayDetails() → print employee details 

// 4. Create a Derived Class: Manager
// •	Inherit from Employee 
// •	Add property: 
// o	teamSize (number) 
// •	Constructor: 
// o	Call base class constructor using super
// 5. Method Overriding
// •	Override displayDetails() in Manager 
// •	Include: 
// o	Employee details 
// o	Team size
// 6. Object Creation
// •	Create: 
// o	One Employee object 
// o	One Manager object 
// •	Call methods and display output 

// Technical Constraints
// •	Use TypeScript only (no Angular components required yet) 
// •	Use ES6 class syntax 
// •	Must use: 
// o	public, private, protected 
// o	extends, super 
// •	Follow proper naming conventions 
// •	No external libraries



// Expectations
// •	Correct use of: 
// o	Constructors 
// o	Access modifiers 
// o	Inheritance 
// o	Method overriding 
// o	Encapsulation using getters/setters 
// •	Clean and readable code 
// •	Proper console output
// Learning Outcomes
// By completing this hands-on, learners will:
// •	Understand how TypeScript supports OOP 
// •	Learn data hiding using access modifiers 
// •	Implement inheritance and code reuse 
// •	Apply method overriding (polymorphism) 
// •	Use getters and setters for controlled access 
// •	Prepare for Angular service/component class design


class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    // Getter
    public getSalary(): number {
        return this.salary;
    }

    //Setter with validation
    public setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Invalid salary. Must be greater than 0");
        }
    }

    // Method
    public displayDetails(): void {
        console.log("Employee ID: " + this.id);
        console.log("Name: " + this.name);
        console.log("Salary: " + this.salary);
    }
}

// Derived Class: Manager
class Manager extends Employee {
    public teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary); // calling base constructor with super key word
        this.teamSize = teamSize;
    }

    // Method Overriding
    public displayDetails(): void {
        super.displayDetails(); // call base method
        console.log("Team Size: " + this.teamSize);
    }
}

// 6. Object Creation

// Employee object
const emp1 = new Employee(101, "Durga", 30000);
emp1.displayDetails();

console.log("Updated Salary:");
emp1.setSalary(35000);
console.log(emp1.getSalary());

console.log("-------------------");

// Manager object
const mgr1 = new Manager(201, "Prasad", 60000, 5);
mgr1.displayDetails();