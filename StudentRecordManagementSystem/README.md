# Student Management System

A console-based application written in C# that manages student records and their academic grades using custom doubly linked lists. 
This system allows users to add, update, delete, and view student information and their associated grades interactively, with 
built-in input validation for a smooth user experience.

## Features

- Add students at the beginning, end, or a specific position in the list
- Search students by ID or name
- Update student details (name, course, year level, GPA)
- Delete student records
- Add and display subject grades per student
- Interactive navigation through student records
- Input validation for student ID, GPA, year level, and grade values

## Data Structures

- `StudentLinkedList`: Manages student records using a doubly linked list
- `GradeLinkedList`: Manages grades per student using a doubly linked list
- `StudentNode` and `GradeNode`: Node classes for linked list traversal
- `Student` and `Grade`: Model classes representing student and grade data

## Utilities

- `InputValidator`: Static helper class for validating user input (Example: student ID, GPA, grade values)

## Execution Instructions

`Adding a Student`
Prompts for:
- Student ID (validated to be unique and positive)
- First Name, Last Name
- Course
- Year Level (1–5)
- GPA (0.0–4.0)

Adds the student to the linked list and confirms success

`Viewing Students`
Displays one student record at a time. Shows personal info and all grades
Navigation options:

- [N] Next
- [P] Previous
- [E] Exit viewing mode

`Searching`
- By ID: returns full student record if found
- By Name: matches full name, first name, or last name (case-insensitive)

`Updating Student Info`
Prompts for student ID
Allows selective updates to:
- First Name
- Last Name
- Course
- Year Level
- GPA

`Deleting a Student`
Prompts for student ID
Removes student from the list if found

`Adding a Grade`
Prompts for:
- Subject ID
- Subject Code
- Grade (1.0–5.0)
- Term
Adds grade to the student’s GradeLinkedList

`Exiting`
Cleanly terminates the program

