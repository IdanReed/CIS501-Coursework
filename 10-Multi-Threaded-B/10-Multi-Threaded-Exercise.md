# Exercise: Multi-threaded Execution

## Tasks

About the previous exercise: when a resource, like a file, is used in a sequence
of transactions, both locks and state variables are needed to manage it.
With these, it is impossible for more than one thread to read/write the file at
the same moment in our little "closed" system.

But a public file server is "open" --- other threads can connect to the server 
and cause trouble. 
Let's consider this:

Rebuild the provided VS Solution and start it.
There are two WForms and an RForm.
They are well behaved. (Try 'em.)
But there is also an "Intruder" form that causes trouble by telling the
controller (server) to close its file!   (Try it.)
This messes up everything.

TO DO:

1. study the included class diagram, which proposes a solution.

2. implement it and verify that the intruder becomes harmless. 

In general, when a client (e.g., web browser) connects with a public (web)
server, it transmits its identity (IP address) and receives in return a key
("nonce") that it uses with its identity in subsequent communications,
similar to what we built today.


## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the  [course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).
