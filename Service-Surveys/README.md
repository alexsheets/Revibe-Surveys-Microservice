==============
Information
==============
This is the surveys application/microservice.
Written in DOTNET core, uses Xunit for testing.

In Surveys.csproj, inside the property group, removing 
<GenerateProgramFile>false</GenerateProgramFile> will render the tests
unable to work.

The connection string to the correct SQL server is found in 'appsettings.json'.
In the future, there should be two connection strings, for the artist database
and contact database.
There are TWO database contexts within this microservice; one for contacts, one
for artists of the week.


==============
Models
==============
- Contact Model:
Implements an Id for identifying the different contact submissions, information of
the user, and a field to represent the platform the submission occurred on.

- Artist of the Week Model:
Implements an Id for identifying different artists of the week as well as different promotional links and information.


==============
Controllers
==============
- Contact Controller:
Routed through /api/contacts/. Calls two readonly items at beginning of class; a 
repository and mapper, which can be changed in the future to Revibe's resource
repos.
Implements two HttpGet methods, one to get all contacts and another to get
a specific contact by its id. 
Implements two HttpPost methods, one for simple contact submission and another
for the sending of emails upon contact submission (will need work).

- Artist of the Week Controller:
Routed through /api/artistoftheweek/. Calls two readonly items at beginning of class; a repository and mapper, which can be changed in the future to Revibe's resource
repos.
Implements two HttpGet methods, one to get all artists of the week and another to get
a specific artist of the week by its id.
The HttpPost method will hopefully allow artists to apply for artist of the week, if
it is implemented.


==============
Contexts/Repos/Dtos
==============
- Contexts:
Adds Db context for contacts/artists of the week. In the future, this file should be edited to properly match the database context of Revibe.
- Repos:
The IContactRepo and IArtistRepo represent interface/methods.
The SqlArtistOfTheWeekRepo and SqlContactRepo hold methods and the contexts necessary.
- Dtos:
The Dtos are necessary as a guide for what the method should perform; ie, 
ContactCreateDto mimicks what is necessary for contact submission.


==============
Profiles
==============
Both profiles are used to create maps between Dtos and their function.
