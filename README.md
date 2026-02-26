# .NET Opdracht ChipSoft

## Gebruik
1. Start de applicatie
2. Ga naar <http://localhost:5216/swagger>
3. Ziekenhuis A kan via de`[POST] /institutions/{id}/referrals`-endpoint een verwijzing naar verpleeghuis B sturen. De request body bevat de benodigde informatie en de verwijsbrief.
4. De verwijzing kan worden opgehaald via de `[GET] /institutions/{id}/referrals`-endpoint, dat de door deze instelling ontvangen verwijzingen laat zien.
5. Verpleeghuis B kan vervolgens de medicatielijst uit het patiëntendossier opvragen via de `[GET] /patients/{id}/medications`-endpoint.

## Ontwerp
- De applicatie is gebouwd met Dependency Injection, zodat de mockservices in de toekomst eenvoudig kunnen worden vervangen door echte implementaties.
- De applicatie slaat de gegevens momenteel in-memory op, maar integratie met een database is eenvoudig mogelijk door eerdergenoemde Dependency Injection.
- Het `ReferralResource`-model wordt gebruikt om de inkomende verwijzing te representeren, zodat er geen overbodige informatie hoeft te worden gespecificeerd en de verwijzingsbrief kan worden meegezonden.
- Swagger-middleware wordt gebruikt om interactieve documentatie van de API te bieden, wat het testen vereenvoudigt en een visuele weergave van de beschikbare endpoints mogelijk maakt.
- De services en controllers van de applicatie zijn ontworpen met separation of concerns in gedachten, waarbij elk onderdeel verantwoordelijk is voor één aspect van de functionaliteit van de applicatie.
- Expliciete foutafhandeling was niet nodig, aangezien de ingebouwde foutafhandeling van ASP.NET Core exceptions netjes afhandelt en geen gevoelige log-informatie blootlegt wanneer de applicatie in een production-environment wordt uitgevoerd.
- Data-annotaties worden gebruikt voor modelvalidatie, zodat data die door de applicatie gaat, voldoet aan de verwachte restricties.