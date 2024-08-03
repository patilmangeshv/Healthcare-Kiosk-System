## 02-Jun-2021
1. Added CRUD operations for Box, Desk, Group, Location, IPTV, Kiosk, Service, SubService, Users
2. Added BiometricNo parameter in create-coupon api
3. Returns IPTV ID/Kiosk ID after successful login
## 23-May-2021
1. Added ApplicationType enum for GetDeskBoxInfo while login to IPTV
2. Added BoxController, BoxServiceController and DeskController
3. Increased size of DeskCode and BoxNo to 10 character in respective tables
## 18-May-2021
1. Updated UserConfigDTO for call user application in UserConfigDTO and AccountController
2. Added lightuser user type for call user in AccountController
3. Added validation for lightuser in call user application
4. Added GetNextPendingCoupon and MarkCouponFinish methods for getting next pending coupon and update the status of it
## 14-May-2021
1. Added Unique key on MacAddress for tblKiosk and tblIPTV tables.
2. Implmented functionality for coupon generation
3. Added nullable columns using ? in most of the places in Entities.
4. Changed field name from Id to their respective table name Id like for tblUser -> UserId
5. Added all required entities to generate coupon printing
## 10-May-2021
1. Changed ServiceId to DeskId in IPTV entity, DTO and Controller
2. Added login validation for IPTV and Kiosk for only super admin user can login
3. Added Application type and user types
4. Added new field UserLever nin AppUSer(tnlUsers) table
## 08-May-2021
1. Added authentication (AccountController) and JWT token (TokenService)
2. Added IPTV, Kiosk controllers and related entities, DTOs
