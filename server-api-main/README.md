1. running the application
    dotnet watch run

2. Publish ASP.NET Core WebPI

    dotnet publish --configuration Release

3. Move the contents of the bin/Release/{TARGET FRAMEWORK}/publish folder to the IIS site folder on the server, which is the site's Physical path in IIS Manager.

