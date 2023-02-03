# Dotnet Web API with JWT Token Based Autentication

This is a sample project with a minimal aproach to exemplify token based authentication using Jwt

Most of the implementation are in the Application project in Authentication folder but basicly we have an AuthenticationManager that is responsable for creating the tokens. 
After that the JWT Token is verifyed in a Service injected within the api application. 

# How to Run
Clone then run with Visual Studio + Docker