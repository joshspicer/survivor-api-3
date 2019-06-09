## Survivor API


## Model

### Player
```
        public long Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Major { get; set; }
        public string Hometown { get; set; }
```

### Tribe
```
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        // Members of the tribe
        public ICollection<Player> players { get; set; }
```


## Powershell Invoke 

Inits database

`Invoke-WebRequest -Uri https://localhost:5001/api/Player -Method GET  -ContentType "application/json" | ConvertFrom-Json`

```
id       : 1                                                                                                    
name     : Josh                                                                                                   
year     : 4th Year
major    : Computer Science
hometown : Whitman

```

`Invoke-WebRequest -Uri https://localhost:5001/api/player -Method POST -Body '{"Name":"Caitlyn"}' -ContentType "application/json"`

```
StatusCode        : 201                                                                                           
StatusDescription : Created                                                                                      
Content           : {"id":2,"name":"Caitlyn","year":null,"major":null,"hometown":null}
RawContent        : HTTP/1.1 201 Created
                    Date: Tue, 04 Jun 2019 01:45:24 GMT
                    Server: Kestrel
                    Transfer-Encoding: chunked
                    Location: https://localhost:5001/api/Player?id=2
                    Content-Type: application/json; charset=utf-8

                    {"id…
Headers           : {[Date, System.String[]], [Server, System.String[]], [Transfer-Encoding, System.String[]],
                    [Location, System.String[]]…}
Images            : {}
InputFields       : {}
Links             : {}
RawContentLength  : 66
RelationLink      : {}

```

`Invoke-WebRequest -Uri https://localhost:5001/api/Player -Method GET  -ContentType "application/json" | ConvertFrom-Json`

```
id       : 1                                                                                                                                                                                                    
name     : Josh                                                                                                                                                                                                 
year     : 4th Year
major    : Computer Science
hometown : Whitman

id       : 2
name     : Caitlyn
year     :
major    :
hometown :

```


`Invoke-WebRequest -Uri http://survivorapi3.azurewebsites.net/api/player/2 -Method PUT -Body '{"Id":2,"Name":"Caitlyn","hometown":"Portland, OR"}' -ContentType "application/json" | ConvertFrom-Json`

```
id       : 1                                                                                                                                                                                                    
name     : Josh                                                                                                                                                                                                 
year     : 4th Year
major    : Computer Science
hometown : Whitman

id       : 2
name     : Caitlyn
year     :
major    :
hometown : Portland, OR


```