# Overview
Builder pattern is one of creational design pattern that allows you to break down the complex object creation step by step. This repo is aim to demonstrate the usage of builder design pattern in following scenarios:

## Scenarios
 - Constructing email message to be sent out.
 - Constructing connecting string.

There are 3 branches in this repo.
1. main branch - basic setup without builder pattern.
2. feature/1-with-builder - simple builder pattern.
3. feature/2-staged-approach - guided step-by-step approach of builder pattern.

## Comparison with Fluent API

|No | Builder Pattern | Fluent API | 
|___|_________________|____________|
|1| All about object creation | about configuring object, but not creation|
|2| Object created is in final state (immutable) | Non-immutable |

## Popular use case of builder pattern
- StringBuilder class in .net framework.

## Pros and Cons
|No | Pros | Cons | 
|___|_________________|____________|
| 1 | We can construct objects in step-by-step fashion. | Increase complexity as it introduces additional classes (builders/directors) and more abstract. |
| 2 | More control over how object is created | |
| 3 | Cleaner code, better readability | |

## References:
- https://refactoring.guru/design-patterns/builder 
- https://dfordebugging.wordpress.com/2022/08/30/builder-pattern-in-c/
- https://mitesh1612.github.io/blog/2021/08/11/how-to-design-fluent-api
- https://medium.com/@sawomirkowalski/design-patterns-builder-fluent-interface-and-classic-builder-d16ad3e98f6c 
- https://www.youtube.com/watch?v=1JAdZul-aRQ 