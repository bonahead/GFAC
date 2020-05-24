# GFAC
Google Forms Answer Checker (GFAC) is a way to quickly review and check responses downloaded from Google Forms

# The Problem
During the COVID-19 lockdown/quarantine period myself and some friends were organising online quizes using Google Forms as the tool to collect the anwers given by the contestants. One of the main issues was checking the responses and ending up with a ranking in a short time. The Google Forms interface did not give enough tools to check the responses fast enough to create a ranking in a short period. There were alternatives, but they did not solve the complete issue. Contestants had to wait hours to days for the ranking to come online.

# The Solution
One solution was using excel with Macros to gather the responses and check them using the unique responses given and deleting incorrect responses. This did not completely solve the problem, but it was a start. Also some users did not have the skill to quickly scan the answers and use Excel swiftly. That's when I decided to make a stand-alone application to help quizmakers responding to their contestants quickly.

# Google Forms Answer Checker (GFAC)
GFAC is a tool using the downloaded csv-file containing the responses to quickly check the answers in order to make a ranking as soon as possible. The tool uses Calculation Profiles to convert the responses into scores. The profiles can be extracted from the responses, but it is also possible to create profiles before downloading the responses.

Calculation Profile
A Calculation Profile consists of column definitions. In these definitions it is possible to define the type (None (do nothing with the column), Report (Show the column value in the ranking), Score (Use the column value to determine the score)), the scorevalue of the column and a list of correct responses. 

Session 
A Session uses the downloaded responses to check against a Calculation Profile. According to the Column definition the scores are collected and a ranking is generated. Correct Responses can be added according to the Unique responses given by the contestants.

Overall Session
An Overall Session combines Session files to make an overall ranking using a selection of files.

# The Program 
The program is developed using C# class Library. There will be a small and simple windows forms frontend in the near future.

Feel free to review the code, review the goal and contribute to make this a helpful tool.
