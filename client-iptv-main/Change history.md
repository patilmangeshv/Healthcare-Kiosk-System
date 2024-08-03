## 23-May-2021
1. Changed desk code text box to dropdown list in login
2. Populated desk code dropdown list with data by calling api in login
3. Added validation of mac address and desk code in login
## 20-May-2021
1. Added DeskCode in login screen and removed exit button
2. Added params in http get method in api service
3. Moved UI from app.component to different component
4. Updated UI for realtime coupons and counts
5. Fetched boxes from database
## 11-May-2021
1. Added web.config file as post-deploy file on to the dist folder
## 10-May-2021
1. Added Login form to validate the super admin user and store & validate the mac address
2. Added AuthGard to guard all components
3. Added Interceptor to add authentication token to all outgoing http requests
4. Added Auth service to login the user by connecting to the server api