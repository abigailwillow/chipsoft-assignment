# .NET Opdracht ChipSoft

## Instructies

1. Start de applicatie
2. Navigeer naar <http://localhost:5216/swagger>
3. Ziekenhuis A verstuurt een verwijzing via `[POST] /institutions/{id}/referrals` naar verpleeghuis B. De request body bevat de benodigde informatie en de verwijsbrief.
4. De verwijzing wordt opgehaald via `[GET] /institutions/{id}/referrals`, dat de door deze instelling ontvangen verwijzingen laat zien.
5. Verpleeghuis B vraagt aanvullende medicatiegegevens van het patiëntendossier op via `[GET] /patients/{id}/medications`.

## Design

- De applicatie is voorbereid op schaalbaarheid. Mock-services kunnen middels dependency injection eenvoudig worden vervangen door echte implementaties. Zoals bijvoorbeeld de in-memory mock-database.
- Elke keer dat gegevens worden gelezen of uitgewisseld, wordt dit gelogd om zo een logboek te creëren van wanneer er wat is gebeurd.
- Er wordt gebruikgemaakt van een `Resource`-model om de inkomende gegevens te representeren. Dit voorkomt dat er overbodige informatie moet worden gespecificeerd en maakt het mogelijk om de verwijsbrief mee te sturen.
- Swagger-middleware is geïntegreerd voor een interactieve API-documentatie, wat zowel het testen als het overzicht van de endpoints bevordert.
- De applicatie is ontworpen met separation of concerns als uitgangspunt, waarbij controllers en services strikt gescheiden verantwoordelijkheden hebben.
- Voor de foutafhandeling is vertrouwd op de ingebouwde middleware van ASP.NET Core. Deze is getest en handelt exceptions netjes af en zorgt ervoor dat er in de productieomgeving geen gevoelige stacktraces of log-informatie naar de eindgebruiker lekt
- Data-annotaties worden gebruikt voor modelvalidatie, zodat gegarandeerd is dat alle data die de applicatie verwerkt voldoet aan de verwachte restricties.
