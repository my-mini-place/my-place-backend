
Backend aplikacji do zarzadzania osiedlami mieszkaniowymi.




## Docker 
Pamietaj zeby zainstalowac dockera i ustawic docelowy system na linux
###Docker Compose
Uruchom z poziomu visual studio w opcjach uruchamiania, pamietaj zeby ustawic dockerowego connect stringa
### DockerFile 
Mozna wybrać w opcjach urachamiania web run by dockerfile i tez powinno sie uruchomic (bez bazy potencjalnie wiec mozna ją recznie uruchomic wczesniej:  https://hub.docker.com/_/microsoft-mssql-server
### Uruchamianie samego Api recznie np:
  Będąc w głownym katalogu projektu użyj komendy: docker build -t web:dev -f src/Web/Dockerfile . przykladowe budowanie -t to nazwa:wersja
    uruchom: docker run -it --rm  -e "ASPNETCORE_ENVIRONMENT=Development" -p 8080:5000 --name Web  web:dev nascluchuje na porcie 8080



   
