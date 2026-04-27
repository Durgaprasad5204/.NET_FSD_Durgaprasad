// Problem -1: User Profile Data Handling using TypeScript Basics
// Problem
// Develop a simple TypeScript module to manage and display user profile information using core TypeScript concepts like variables, data types, type inference, let/const, template literals, and operators.
// Scenario:
// You are building a basic Angular application where user details need to be processed before displaying on the UI. As a developer, you must write TypeScript code to handle user data such as name, age, email, and subscription status.
// The goal is to ensure type safety, readability, and proper usage of modern TypeScript features.

// Requirements:
// 1.	Variable Declaration: 
// o	Declare variables for: 
// 	User Name (string) 
// 	Age (number) 
// 	Email (string) 
// 	IsSubscribed (boolean) 
// 2.	Type Inference: 
// o	Declare at least 2 variables without explicit types and let TypeScript infer them. 
// 3.	let / const Usage: 
// o	Use const for values that should not change. 
// o	Use let where reassignment is required (e.g., updating age). 
// 4.	Template Literals: 
// o	Create a formatted user profile message using backticks (`). 
// Example:
// 	Hello John, you are 25 years old and your email is john@example.com



// 5.	Operators:
// •	Perform operations: 
// o	Increment age by 1 
// o	Check if user is eligible for a premium plan (age > 18 AND subscribed) 
// o	Use comparison and logical operators
// 6.	Output:
// •	Print all results using console.log()

// Technical Constraints
// •	Use only TypeScript (no Angular components required yet) 
// •	Do not use any external libraries 
// •	Follow proper naming conventions (camelCase) 
// •	Ensure strict typing where applicable 
// •	Code should run using ts-node or compiled via tsc
// Expectations
// •	Correct usage of TypeScript data types 
// •	Clear understanding of type inference 
// •	Proper distinction between let and const 
// •	Clean and readable code 
// •	Correct use of template literals and operators 
// •	Logical correctness in conditions
// Learning Outcomes
// After completing this hands-on, learners will be able to:
// •	Understand and apply basic TypeScript data types 
// •	Use type inference effectively 
// •	Differentiate between let and const 
// •	Write dynamic strings using template literals 
// •	Apply operators for real-world conditions 
// •	Build a strong foundation for Angular TypeScript developmenta


const userName : string = "Durga Prasad";
let age : number = 23;
const email: string = "durga@123";
const isSubscribed: boolean = true;

// Type Inference
let country = "India";
let loginCount = 6;

const message = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log(message);

age = age+1

const premiumPlan: boolean = age > 18 && isSubscribed;

const isAdult : boolean = age >= 18;

console.log("---Updated Details---");
console.log(`Updated Age: ${age}`);
console.log(`Country: ${country}`);
console.log(`Login Count: ${loginCount}`);
console.log(`Is Adult: ${isAdult}`);
console.log(`Is Subscribed: ${isSubscribed}`);
console.log(`Eligible for Premium: ${premiumPlan}`);