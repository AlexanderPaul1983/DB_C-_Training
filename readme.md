# Einleitung

* Insgesamt sind 50 Punkte erreichbar
* Das Benutzen von Google ist erlaubt

# Aufgaben

0) Mache dich zuerst mit dem Projekt vertraut und prüfe, ob es kompiliert und gestartet werden kann

1) Implementiere das Feature GetFlickFlackQuery (Datei GetFlickFlackQuery.cs):

* Im Request werden die Zahlen Start (int) und End (int) übergeben
* Für Start und End gelten folgende Regeln:
  * Start muss größer als 0 sein
  * End muss kleiner gleich 100 sein
  * Start muss kleiner oder gleich End sein
* Die Response enthält eine Liste Elements (List<string>) 
* Für jede Zahl zwischen Start und End muss ein Element zur Liste hinzugefügt werden. Es gelten folgende Regeln 
  für die Elemente:
  * Die Zahl ist durch 3 teilbar: Füge Flick hinzu
  * Die Zahl ist durch 4 teilbar: Füge Flack hinzu
  * Die Zahl ist durch 3 und 4 teilbar: Füge FlickFlack hinzu
  * Ansonsten füge die Zahl als Text hinzu

a) Erstelle neue UnitTests in der Klasse FlickFlackTests (3 Punkte)
    * ErrorWhenEndGreaterThen100()
    * ErrorWhenStartGreaterEnd()
   Starte die UnitTests um zu prüfen, dass diese fehlschlagen

b) Implementiere die Prüfung der Request-Regeln in der Methode Handle der Klasse GetFlickFlackQueryHandler. 
   Werden die Regeln nicht eingehalten, muss eine ArgumentException geworfen werden. 
   Teste mit den UnitTests Error..., ob die Kontrollen funktionieren.(10 Punkte)

c) Implementiere das Zusammenstellen und Zurückgeben des Response Objekts in der Methode Handle der
   Klasse GetFlickFlackQueryHandler. 
   Teste mit den UnitTests Start1...,  ob das Ergebnis korrekt zusammengestellt wird.(10 Punkte)

d) Füge eine neue Get Route mit dem Pfad "FlickFlack" hinzu und teste sie mit Swagger. (2 Punkte)

1) Füge das neue Feature GetUserQuery im Ordner Features/Users hinzu: 

* Im Request muss eine ID (int) übergeben werden.
* Die Response ist ein Objekt, das die ID und den Namen des Users enthält
* Existiert zur ID kein User in der Datenbank, muss null als Respose zurückgegeben werden

a) Erstelle die Klassen für das GetUserQuery Feature ohne Implementierung (8 Punkte) 
   * GetUserQueryRequest: IRequest<GetUserQueryResponse?>
   * GetUserQueryResponse 
   * GetUserQueryHandler: IRequestHandler<GetUserQueryRequest, GetUserQueryResponse?>

b) Entferne die Kommentarzeichen /* und */ in der Klasse GetUserTests, um die Tests für
   GetUser aktivieren. Führe sie aus, um sicherzustellen, dass sie fehlschlagen (2 Punkte)

c) Implementiere die Handle Methode und den Konstruktor der GetUserQueryHandler Klasse. 
   Teste die Implementierung mit den zwei neuen Unittests (10 Punkte)

d) Füge eine neue Get Route mit dem Pfad "Users/{id}" hinzu und teste sie mit Swagger (5 Punkte)