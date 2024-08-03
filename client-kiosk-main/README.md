1. Create blank app
npm uninstall @schematics/angular

npm install @schematics/angular@9.1.0

ng add ngx-bootstrap

ng add @angular/localize

2. git checkin

    git add . 
    git commit -m "Styles moved to styles.css"
    git branch -M main
    git push -u origin main

3. Extract local file for english and store it in src/local folder

    ng extract-i18n --output-path src/locale

4. Serving application

    ng serve --configuration=ar -o

5. Build final version with all locale

    ng build --prod --localize