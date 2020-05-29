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

# Use Case 1: I have made a Pubquiz using Short Answer Text Controls and want to validate the answers
You have made a Pubquiz using Google Forms as the source to have contestants answer the questions. The forms contain Dropdown lists and short answer texts controls. In Google Forms it is easy to validate if the answer given using a Dropdown list, because it is either right or wrong. Short answer texts is not as easy, because responders can make all kind of typo's or vary numbers in text or vice versa. They can even give the right response in the wrong answer control. Using a Typo-generator many typo's can be validated by Google Form, but you can imagine users think of new ways to make a typo. 
Using GFAC you can validate the answers after you closed the form from responses by doing the following:

1. Download the responses from Google Forms using the three dots in the responses screen and select "Download responses (.csv)". You will get the chance to save a compressed file. Save the file on a convenient location and uncompress it.

2. Start the GFAC GUI application. 

3. Select File -> New -> Response Session. A new window called "Response Session" will be shown. 

4. Press the button "Select Sourcefile". You can now select the csv-file you downloaded and uncompressed in step 1.

5. Select the csv-file and press the button "Open". After this the application will ask you the following question "There seems to be no profile selected. Would you like to make a new profile bases on the sourcefile?"

6. Press the button "Yes". A new window is shown asking you to provide a name and a default Type. Type refers to the columntype. There are three possible choices: 
      - "None": No action will be undertaken for the column.
      - "Report": The column is used in the ranking to specify the contestants.
      - "Score": The column is used to determine the score of the contestant.
      
7. Press the button "Next >".  A new window is shown for every column found in the csv-file. Here you need to spcify the Name of the column (this is copied from the sourcefile at first), the type of the column (as described in step 6) and the Score for a correct response. Also all unique responses are shown in a list. You can select every response you define as correct and copy it to the other list. This lists is used to calculate the final score.

8. Repeat step 7 for every column found in the sourcefile.

9. Press the button "Finish" to complete the profile. You can save the profile on a convenient location.

After the profile is saved the sourcefile is processes and three lists are displayed: 
        - "Final Score": Ranking of all responders.
        - "Responses": All responses given by the contestants
        - "Source Data": All Data from the sourcefile.

A Response Session contains the ranking processed from one google Form. You can also combine multiple Response Session by using GFAC Session. Just add multiple sessions and press the button refresh.

If you want to be prepared in advance you can also define profiles before the Google Forms go live. the screen is a little different but works similar as described in step 6 and 7.
