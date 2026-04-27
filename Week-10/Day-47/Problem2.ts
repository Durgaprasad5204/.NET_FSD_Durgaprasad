// Problem -2: User Notification System using TypeScript Functions
// Problem Statement:
// Create a TypeScript module that generates user notifications using functions. The implementation should demonstrate function parameters (required, optional, and default), return types, and arrow functions with lexical this.
// Scenario:
// You are developing an Angular-based application where users receive different types of notifications (e.g., welcome message, subscription alert, account update).
// As a developer, you need to design reusable TypeScript functions to generate and manage these notifications while ensuring proper typing and clean code practices.
// Requirements:
// 1. Function with Required Parameters
// •	Create a function getWelcomeMessage(name: string): string 
// •	It should return a welcome message for the user
// 2. Optional Parameters
// •	Create a function getUserInfo(name: string, age?: number): string 
// •	If age is provided → include it in the message 
// •	If not → return message without age
// 3. Default Parameters
// •	Create a function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string 
// •	If no value is passed → treat user as not subscribed
// 4. Return Types
// •	All functions must explicitly define return types 
// •	At least one function should return a boolean 
// o	Example: isEligibleForPremium(age: number): boolean 
// 5. Arrow Functions
// •	Rewrite one or more functions using arrow syntax
// 6. Lexical this 
// •	Create an object NotificationService with: 
// o	a property appName 
// o	a method using arrow function that accesses this.appName 
// •	Demonstrate how arrow function preserves this
// 7. Execution
// •	Call all functions and print outputs using console.log()
// Technical Constraints:
// •	Use only TypeScript (no Angular component yet) 
// •	Avoid using any type 
// •	Follow proper naming conventions (camelCase) 
// •	Use ES6+ syntax 
// •	Code should compile without errors using tsc

// Expectations:
// •	Correct implementation of: 
// o	Required, optional, and default parameters 
// o	Explicit return types 
// •	Proper usage of arrow functions 
// •	Clear understanding of lexical this 
// •	Clean, readable, and modular code 
// •	Logical handling of conditions

// Learning Outcomes:
// After completing this hands-on, learners will be able to:
// •	Understand function parameter types in TypeScript 
// •	Use optional and default parameters effectively 
// •	Define and enforce return types 
// •	Write arrow functions confidently 
// •	Understand lexical this behavior 
// •	Build a strong foundation for Angular service methods and business logic



function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}!`;
}

// Optional Parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    } else {
        return `User ${name} has not provided age.`;
    }
}

//Default Parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed? `${name} is subscribed to our service.` : `${name} is not subscribed.`;
}


function isEligibleForPremium(age: number): boolean {
    return age > 18;
}


const getAccountStatus = (name: string, isActive: boolean): string => {
    return isActive? `${name}'s account is active.`: `${name}'s account is inactive.`;
};

// using arrow function
const notificationService = {
    appName: "MyApp",

    // arrow function → preserves 'this'
    sendNotification: (user: string): string => {
        return `Hello ${user}, welcome to ${notificationService.appName}!`;
    }
};



console.log(getWelcomeMessage("Durga Prasad"));
console.log("-----------------------")
console.log(getUserInfo("Durga Prasad", 23));
console.log(getUserInfo("Durga Prasad"));
console.log("-----------------------")


console.log(getSubscriptionStatus("Durga Prasad", true));
console.log(getSubscriptionStatus("Durga Prasad"));

console.log("-----------------------")

console.log(`Eligible for Premium: ${isEligibleForPremium(23)}`);

console.log(getAccountStatus("Durga Prasad", true));

console.log(notificationService.sendNotification("Durga Prasad"));