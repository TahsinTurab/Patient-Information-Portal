# Patient-Information-Portal
<b>Front End: <b> ASP.NET Core MVC 6 <br>
<b>Back End:<b> ASP.NET Core WEB API <br>
<b>Database:<b> MS SQL server 2018 <br>

Configure Connection String: <br>
After open the solution on your local machine, change the connection as per your ms sql server from appsetting.json

Update Datebase:<br>
From project manager console run the command: Update-Database

Run SQL query:<br>
Run sql query from sql queries folder to insert data in Diseases, NCDs and Allergies table.

Configure start up project:<br>
configure both API and MVC project as startup project

then run the application<br>


Unit Testing: Xunit<br>
This unit test is done for only the Delete method of API project.

N.B: API for Create, Read, Delete and Update are created in backend project. Hence the given UI is only for Display data and Create; so, MVC project contains only these 2 operations.


