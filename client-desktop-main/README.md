1. git checkin

    git add . 
    git commit -m "Styles moved to styles.css"
    git branch -M main
    git push -u origin main

2. Extract local file for english and store it in src/local folder

    ng extract-i18n --output-path src/locale

3. Serving application

    ng serve --configuration=ar -o

4. Build final version with all locale

    ng build --prod --localize