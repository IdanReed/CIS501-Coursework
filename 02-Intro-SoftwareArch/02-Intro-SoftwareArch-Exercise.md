# Exercise: Introduction to Software Architecture

## Tasks

Use Visual Studio to make: (1) a console app, and also (2) a Forms app 
for the number game below by modifying the provided solutions
(`02-Intro-SoftwareArch-Console.sln` and `02-Intro-SoftwareArch-GUI.sln`,
respectively). 

### Use case

1. Computer says:  

   `Guess an int, M, in range 0..10:  M = `
   
   (user then types an int and computer verifies that it is legal)

2. Computer says:

   `I guess int, N, in range 0..10-M
   
   (N is a randomly generated int in range 0..(10-M))
   
   `now you type an int, P, such that M + N + P = 10:  P = `
   
   (user then types an int and computer checks if the sum totals 10)

3. Computer says:

   `You win!` or `You lose!`   (based on the sum)

Use random number generator as shown in the provided console app in
`02-Intro-SoftwareArch-Console.sln`.

Do this to convert a string of digits, `s`, to an int:

```c#
  int n = Int32.Parse(s);
``` 

## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the  
[course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).

