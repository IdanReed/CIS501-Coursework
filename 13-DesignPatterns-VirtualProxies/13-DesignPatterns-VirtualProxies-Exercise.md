# Exercise: Design Patterns: Virtual Proxies

## Tasks

Notice that the document reader downloads the entire textfile and formats all of
it before you can read even the first formatted line.
For a long document, this will be frustrating.

Replace class `AllDoc`  by class `VProxyDoc`, a virtual proxy that builds
formatted lines on demand.
Write class `VProxyDoc`  and change one line in class `Program` (to switch to
use `VProxyDoc` from `AllDoc`).

Now, the app  calls the `VProxyDoc` for lines to display, and the `VProxyDoc` 
calls the `WordIterator` to fetch the words, one by one, from the input textfile.


## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the [course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).
