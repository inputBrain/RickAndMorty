# RickAndMorty

###### This api parse data from [https://rickandmortyapi.com/api](https://rickandmortyapi.com/api) web site

###### All what you need is to run RickAndMorty.Host or write in terminal from RickAndMorty.Host ```dotnet run``` command

## A test task:

1. The api should contain 2 endpoints:

 1.1 POST. "check-person". Request:
``` 
{ 
 "personName": "str", 
 "episodeName": "str"
}
```
> If a person was in an episode, then return ```true``` otherwise ```false```


  1.2 GET. Search person by name. Request:
```
{
 "personName": "str"
}
```


> Response body should inclde only next information:
```
{
 "name": "str",
 "status": "str",
 "species": "str",
 "type": "str",
 "gender": "str",
 "origin": {
   "name": "str",
   "type": "str",
 "dimension": "str"
}
```

2. The api should contain ```DockerFile```
> - :(
