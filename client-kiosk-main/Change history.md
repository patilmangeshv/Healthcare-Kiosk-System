## 01-Jun-2021
1. Resolved issue of langauge change by adding one more project (client-kiosk-home) ONLY for langauge page
## 23-May-2021
1. Changed sub service code from "DHSE-URG" to "DHSE_URG" as earlier code was wrapping to two lines in coupon printing
## 22-May-2021
1. Fixed the coupon printing and adjusted to print on the client machine printer
## 15-May-2021
1. Fixed bug in payment-desk and emergency menu was not working
2. Removed Exit button from Login form
## 14-May-2021
1. Added index.html, 404.html and web.config files as post-deploy files on to the dist folder
2. Disabled unused menus
3. Generated coupons by calling api service and populated the same in the coupon prinitng

## 10-May-2021
1. Added Login form to validate the super admin user and store & validate the mac address
2. Added AuthGard to guard all components
3. Added Interceptor to add authentication token to all outgoing http requests
4. Added Auth service to login the user by connecting to the server api
5. Cleaned up the unwanted console.log
## 09-May-2021
1. Merged langange selection and main menu as a work around for the issue of lang not changing for temporary purpose. The earlier version of this should be considered when the issue gets resolved.

## 10-May-2021
1. Added authentication page (login) with authorise mode
2. The super admin with specifiying the macaddress of the client added and the same will be processed further for rest of the application process
3. Based on the macaddress, server-api will resolve to the KioskId

