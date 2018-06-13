
# Docker WebAPI & Nginx Example
- This example shows you how to create a basic **[.Net Core WebAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1)** hosted in a **[docker](https://www.docker.com/)** container accessed via a seperate **[Nginx](https://www.nginx.com/)** docker container reverse proxy.  There is a third docker container also using nginx to host a client index.html test web page.
- This is all achieved using **[docker-compose](https://docs.docker.com/compose/)** to combine the three docker files as required.

## Building and Running
### Build the docker images
```sh
$ docker-compose build
```

### Run all three docker images
```sh
$ docker-compose up
```

### Check containers
```sh
$ docker ps
```

### To check the logs get the container id from the previous command 'docker ps'
```sh
$ docker logs --details -f -t <container id>
```

### To explore via bash terminal
```sh
$ docker exec -it <container id>  /bin/bash
```

## Test the .net core api using the sample web client
Open chrome using the following command
```sh
$ chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
```
Go to the following in your browser: http://localhost:13000/ and press 'Click Me'.  The host name of the underlying API service should be returned.

## Configuration & How it works
## [Docker - links](https://docs.docker.com/compose/compose-file/#links)
Inside docker-compose.yml we link the nginx proxy service to the API containers using the following:
```
    links:
     - api1:api1
     - api2:api2
     - api3:api3
     - api4:api4
     - api5:api5
```
Note: This is not required unless alias of service names are needed. However, helpful to include.


## [Docker - expose](https://docs.docker.com/compose/compose-file/#expose)
Inside docker-compose.yml each api uses 'expose' to make the service via the exposed port available to the linked services.  Note: this does not publish the port to the host machine.

## [Docker - ports](https://docs.docker.com/compose/compose-file/#ports)
Inside docker-compose.yml each api the 'nginx proxy' and 'gui' services expose their internal port of 80 to the host ports 12000 & 13000 respectivly. 

## [NGINX Load Balancing](http://nginx.org/en/docs/http/load_balancing.html)
Inside nginx.conf we have configred requests to 'round robin' between the API instances by the following configuration:
```
    links:
    upstream api_servers {
       round-robin;
		server api1:11000;
		server api2:11000;
		server api3:11000;
		server api4:11000;
		server api5:11000;
    }
```
Then in the server section we set the following:
```
   proxy_pass         http://api_servers;
```

