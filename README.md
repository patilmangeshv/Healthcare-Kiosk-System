# Healthcare Kiosk System
The complete solution for the Hospital Kiosk management system for patients and has the modules: Kiodk machine, Administration Panel, Doctor Panel, Desk User Panel, Android IPTV screen.

This project is to develop/implement the complete solution for the Hospital Kiosk management system for patients and has the following modules:

### Kiosk machine
This is a Web application installed on Windows machine in Kiosk mode, providing UI for patients to select the various hospital services and generate the token for further processing. **Used Angular with Internationalisation (i18n) for English, French and Arabic languages.**
### Administration panel
This is a Web application developed in Angular by fetching data from ASP.NET CORE WebAPI and provides UI for admin to manage the various static data and to generate various performance reports for smooth functioning of Kiosk system.
### Doctor panel
A Windows application developed in VB.NET windows application by connecting to the ASP.NET CORE WebAPI and providing UI for doctors to operate the queue of the patients.
### Desk User panel
Windows application developed in VB.NET windows application by connecting to the ASP.NET CORE WebAPI and gives UI for desk operators to attend the patients come for pathology;
### Android IPTV Screen
A PWA App supported to work on any platform, developed using IONIC 5 with Angular and gives UI for patients to display the status of the patients’ queue based on the operation from Doctor and Desk user.

### Technologies
#### Backend:
ASP.NET Core: A modern, open-source, and cross-platform framework for building web APIs and applications.
VB.NET & C#: Powerful and object-oriented programming languages that excels in enterprise development.
#### Frontend:
Angular: A popular JavaScript framework for building dynamic single-page applications (SPAs) with Internationalisation (i18n).
#### Development Environment:
Visual Studio Code: A comprehensive IDE for building .NET applications with support for ASP.NET Core, VB.NET/C#, and Angular development.
#### Operating System:
Windows: Kiosk machine web applications with Kiosk mode on Windows OS, Doctor and Desk User Panel applications are designed and tested to run on Windows environments.
Android: Android IPTV Screen application is used specifically for Android.
Cross Platform: Administration panel application can be used from any platform by using web browser.

#### Prerequisites
*** Development Tools:***
Visual Studio Code: Download and install the appropriate version for your needs from [https://visualstudio.microsoft.com/](https://code.visualstudio.com/download). Ensure you have the ASP.NET and web development workload selected during installation.
Node.js and npm (Node Package Manager): Download and install the latest version from https://nodejs.org/.
Runtime Libraries:
.NET Runtime (version compatible with your target framework): Download and install from https://dotnet.microsoft.com/download/.

Getting Started

Clone the Repository:

Bash
`git clone https://github.com/patilmangeshv/Healthcare-Kiosk-System.git`

Open in Visual Studio Code:
Open the project folder in Visual Studio Code.

Restore Dependencies:

Backend: Visual Studio code will automatically restore backend dependencies during project loading.
Frontend: In the frontend directory, run:
Bash
`npm install`
Use code with caution.

Run the Application:

Backend: Set the frontend project as the startup project in Visual Studio. Press F5 (or use the "Debug" -> "Start Debugging" menu) to start the backend and frontend development server. The application will typically launch in your default browser (usually http://localhost:5000/).
Production: Refer to ASP.NET Core documentation for publishing and deploying your application to a production environment ([invalid URL removed]).
