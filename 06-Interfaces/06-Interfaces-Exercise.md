# Exercise: Delegates

## Tasks

1. Study and demo `06-Interfaces-Naive`.
   Open `naive.classdiagram` and look at the class diagram (double-click on 
   its name).

2. Study and demo `06-Interfaces-Controller`.  
   Add the missing arrows in `controller.classdiagram` so that it matches the 
   code.

3. Study and demo `06-Interfaces-Delegate`.
   Study Diagram Delegate  --- notice `EventHandler`!

4. Alter the code for `06-Interfaces-Exercise`:
   change the definition of delegate `EventHandler` to
   
   ```c#
   public delegate string EventHandler(object sender, EventArgs e)
   ```
    
    change  class `Form1`  so that it no longer needs a handle to a `Hand` 
    object. (Hint:  the  handle  method returns the string to display.)
    

## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the  
[course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).
