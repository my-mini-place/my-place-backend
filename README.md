# My-Place


W projekcie brakuje pliku : appsettings.json (.gitignore)
ktory bazowo wyglada tak:
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
jego aktualna wersja będzie pojawiać się na grupie 



### Docker
1. zainstaluj dockera
2a. Uruchom za pomocą VS2022 na górze w opcjach uruchamiania
2b.  Będąc w głownym katalogu projektu użyj komendy: docker build -t my-place2:2 -f src/Web/Dockerfile . przykladowe budowanie -t to nazwa:wersja
    uruchom: docker run -it --rm  -e "ASPNETCORE_ENVIRONMENT=Development" -p 8080:5000 --name Web  web:dev nascluchuje na porcie 8080
2c. zbuduj i uruchom w apce dockera


   
