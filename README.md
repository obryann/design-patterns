# design-patterns
This repo will cover some design patterns, separated by some categories(from "Design Patterns: Elements of Reusable Object-Oriented Software") to make them easier to classify and use.

While getting there, the SOLID Principles are being covered too. With those being:
Single Responsibility: Classes and methods in gereal should only do ONE thing;
Open-Closed: Objects and classes should be open and easy to add stuff, but you should not be able to modify them;
Liskov Substitution: You should always be able to use a base type as a subtype
Interface Segregation: Refers to the ideia of creating interfaces that separates all possible actions in a way that can be useful for multiple classes, without inheriting unnecessary methods.
Dependency Inversion: States that high level parts of a project should depend on abstract definitions, rather than low-level parts

They are divided in 3 bigger categories:
Creational: These will be applied when creating new stuff;
Structural: These will be used when there is the necessity to modify and play with object Inheritance and Composition;
Behavioral: These are mostly used to decouple objects, add flexibility and extendability between classes, and step-up their interactions

Creational:
    Builders;
    Factories;
        * Abstract Factory;
        * Factory Method;
    Prototype;
    Singleton;

Structural:
    Adapter;
    Bridge;
    Composite;
    Decorator;
    Façade;
    Flyweight;
    Proxy;

Behavioral:
    Chain of Responsibility;
    Comand;
    Interpreter;
    Iterator;
    Mediator;
    Memento;
    Null Object;
    Observer;
    State;
    Strategy
    Template Method;
    Visitor