ANDREW MOBUS
ROUGH_ELEVENS
README - [03-15-2024]

--> To run:
-> open ROUGH_ELEVENS solution and build, or run in debug mode.
-> On RUN, input AUTO for the concise auto solver, or input MANUAL
to play the concise manual game
-> the main .cs files are [HOUSE], which holds most of the Elevens
specific information as well as things like the play loop, and the
[Validator], which has a number of decoupled (abstracted) functions
used by HOUSE
-> the [AGENT] & [DECK] files are mostly as their state on end of
prior project, with extra (unneeded) code & comments cleared away;
they don't need to be reviewed independently of [HOUSE] & [VALIDATOR]

--> The [ROUGH_ELEVENS DEVELOPMENT DOC]
-> this is the main write up (the optional write up) for the project;
it can be read before or after the code & its comments


--> the Documentation Folder:
-> these are not the main documentation (ie, the write up & similar)
and are not intended to be read, but are kept for completeness
-> Documentation of code is embedded, with large blocks in the 
Test Files; these should be read first, and then HOUSE & Validator
-> there is a text file labeled BULKCODE; this has all the seperate
code files consolidated in to one, with the testing code commented
out at the bottom
-> the bulk file is a fallback that can be copied and pasted into
a new C# file & run if everything else doesn't work for whatever
reason

