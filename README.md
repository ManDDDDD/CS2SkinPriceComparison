# CS2SkinPriceComparison

## Factsheet

### Projektidee

Ziel des Projekts ist eine Konsolenapplikation zu entwickeln, die mittels Web Scraping, basierend auf Selenium, den Preis eines beliebigen CS2 Skins von den zwei grössten deutschen Marktplätzen vergleicht. Bei den Marktplätzen handelt es sich um \*Skinport und \*SkinBaron.

#### Umsetzung

Der Benutzer kann per Konsoleneingabe die Art des Skins, die von einem JSON-File, dass alle Arten enthält, gespeichert werden, auswählen. Anschliessend kann der User per Eingabe den Namen des Skins eingeben.

Diese Eingaben des Benutzers werden in ein Objekt der Skin-Klasse gespeichert.

Um die Preise aus den zwei Marktplätzen zu erhalten, wurde für das Projekt Web Scraping verwendet. Das Web Scraping wurde mit Selenium umgesetzt. Damit Selenium die benötigten Daten erhält, wird das zuvor erstellte Skin-Objekt übergeben.

Anschliessend sucht sich Selenium mittels Links und XPath die Preise heraus und gibt diese zurück.

Da der Marktplatz von SkinBaron den Preis in Euro zurückgibt, wurde der Wechselkurs mit einer API ermittelt. Somit wird der Preis in Franken ermittelt.

Die Preise werden dem User letztendlich präsentiert.

#### Testing

Zum Testen unserer Applikation wurde auf Unit Testing gesetzt. Damit wurden die Methoden konkret getestet.

Bei dem Testing fiel ein bestimmtes Muster auf. Selenium führte oftmals zu Problemen, wo von aber die meisten behoben werden konnten.

Nun ist es so, dass ein bestimmter Fehler sehr unregelmässig Auftritt. Die Ursache des Fehlers ist leider weiterhin ungeklärt. Bei dem Fehler handelt es sich um eine StaleElementReferenceException. Zwar haben wir ein Exceptionhandling mittels try catch implementiert, der Fehler scheint aber bei Selenium selbst zu liegen.

Alle Tests welche unabhängig von Selenium agieren funktionieren einwandfrei.

#### Resultat

Trotz des Fehlers bei Selenium ist unser Programm meist fehlerfrei und kann erfolgreich die Preise von jeweils Skinport, als auch SkinBaron vergleichen. Ein User kann nun wie bereits beschrieben seinen gewählten Skin auf den zwei Plattformen vergleichen.

(#sdfootnote1anc) \*Die Marktplätze stehen in keinem Zusammenhang mit dem Projekt