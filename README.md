# Left to Do
Inlämning: Left To Do, 5 Yhp

Vi ska i denna uppgift skapa en konsolapplikation för att hålla koll på och ordna våra arbetsuppgifter, det vill säga en digital att-göra lista. I denna uppgift ställs högre krav på att du har själv väljer en lämplig kodstruktur och tillämpar det du lärt dig om de objektorienterade principerna. Dessutom måste du utveckla din kod med stöd av enhetstester.

En användare ska vid användning av programmet kunna se vad som är kvar att göra i listan, Markera uppgifter som avklarade, lägga till nya uppgifter i listan samt arkivera avklarade uppgifter.

### Kravspecifikation:
* Lösningen ska bestå av en körbar konsolapplikation skriven i C# (netcoreapp2.2 eller netcoreapp3.0) 
* När man startar programmet ska man mötas av en startmeny som förklarar hur programmet används och låter användaren utföra programmets uppgifter.
* Man ska som användare kunna lista alla dagens uppgifter, alla uppgifter ska då listas om dom inte är arkiverade.
* När uppgifterna listas på detta vis ska de kunna markeras som **utförda**, eller som **kvar att göra** beroende på sin nuvarande status.
* Från startmenyn ska man även kunna...
  * Lägga till en ny uppgift.
  * Arkivera alla uppgifter som för närvarande är utförda.
  * Lista alla arkiverade uppgifter, det behöver inte gå att göra något med uppgifterna när de listas på detta vis.
* Den inlämnade lösningen ska bestå av en "Program.cs" fil, en ".csproj" fil samt en fil för varje extra klass du skapar.
* Ingen information behöver sparas mellan körningar av programmet.

### Ytterkliga önskemål
För VG på uppgiften krävs det att det ska finnas två typer av uppgifter, 2 klasser i programmet, som ärver från en gemensam superklass. Den ena klassen kan exempelvis vara en uppgift med en checklista, eller en uppgift med ett givet datum.

### Enhetstester
Applikationen måste innehålla enhetstester för följande funktionalitet:
 * Test för att lägga till en uppgift i listan
 * Markera en uppgift som avklarad
 * Arkivera alla avklarade uppgifter


### Rapport och inlämning
Inlämningen ska innehålla en rapport som kort beskriver hur du strukturerat din kod genom användandet av de objektorienterade principerna *arv*, *enkapsulation* och *polymorfism*.

När du är färdig med din uppgift så skall du bifoga repporten som ett pdf-dokument, som dessutom innehåller en länk till ditt gitrepo.


### Kom igång
Använd länken till uppgiften från Github Classroom för att komma igång:

[Left to do](https://classroom.github.com/a/PN6wj6vZ)

Du behöver inte lägga till mig som Collaborator om du använder denna länk för att skapa Gitrepot.
