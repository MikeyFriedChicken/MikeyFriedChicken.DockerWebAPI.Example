
# Docker & .Net Core WebAPI using Nginx with Loading Balancing
- This example shows you how to create a basic **[.Net Core WebAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1)** hosted in a **[Docker](https://www.docker.com/)** **[container](https://www.docker.com/what-container)** accessed via a seperate **[NGINX](https://www.nginx.com/)** docker container reverse proxy.  There is a third docker container also using nginx to host a client test web page used to query the API.
- This is all achieved using **[docker-compose](https://docs.docker.com/compose/)** which references the 3 **[Dockerfile's](https://docs.docker.com/engine/reference/builder/)** to build the **[images](https://docs.docker.com/v17.09/engine/userguide/storagedriver/imagesandcontainers/)** and create the containers.

## Building and Running
### Build the docker images
```sh
$ docker-compose build
```

### Run all three docker images
```sh
$ docker-compose up
```
## Diagnosis
### Running Containers
To check the docker containers running type the following:
```sh
$ docker ps
```

### Logs
To check the logs get the container id from the previous command 'docker ps' and type the following:
```sh
$ docker logs --details -f -t <container id>
```

### Terminal
To explore inside the container via a terminal type the following:
```sh
$ docker exec -it <container id>  /bin/bash
```

## Testing
To check it all works and hit the the .net core api use the sample web client as follows:
1. Open chrome using the following command
```sh
$ chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
```
2. Go to the following in your browser:
``` 
http://localhost:13000/ 
```
3. Press 'Click Me'.  
4. The host name of the underlying API service should be returned.

## Configuration & How it works
### [Docker Compose - links](https://docs.docker.com/compose/compose-file/#links)
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


### [Docker Compose - expose](https://docs.docker.com/compose/compose-file/#expose)
Inside docker-compose.yml each api uses 'expose' to make the service via the exposed port (11000) available to the linked services.  Note: this does not publish the port to the host machine.
```
    expose:
      - "11000"
```

### [Docker Compose - ports](https://docs.docker.com/compose/compose-file/#ports)
Inside docker-compose.yml each api the 'nginx proxy' and 'gui' services expose their internal port of 80 to the host ports 12000 & 13000 respectivly. 
```
    ports:
      - "12000:80"
```

### [NGINX Load Balancing](http://nginx.org/en/docs/http/load_balancing.html)
Inside nginx.conf we have configured requests to 'round robin' (default when alternative not specified) between the API instances by the following configuration:
```
    links:
    upstream api_servers {
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

