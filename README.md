# MovieHandler

MovieHandler is a project for educational purposes that obtains movie data using a REST service that is available at https://www.themoviedb.org/
It is an object-oriented system built entirely using the .NET Framework using object development and abstraction best practices.

To use it you must register at https://www.themoviedb.org/
After that, you must request an API key for authentication on the site.
There are 2 types of authentication: API Key and Bearer Token and both will be made available to you.

Once you have the keys after downloading the MovieHandler and compiling the project, you must configure the keys inside the MovieHandler.exe.config file like this:

To use API Key authentication:

<add key="ApplicationLevelAuthentication" value="APIKey" />
<add key="APIKey" value="_API_KEY_HERE" />

To use Bearer Token authentication:

<add key="ApplicationLevelAuthentication" value="BearerToken" />
<add key="BearerToken" value="_BEARERTOKEN_HERE" />


When running the project you must inform the themoviedb api URL which is usually:

https://api.themoviedb.org/3/


After that, you can run the MovieHandler requesting movie data by entering its name and if you decide to get more details, inform the MovieID of the movie you want to have this data.

