
# Docker WebAPI & Nginx Example

# Build the docker images
```sh
$ docker-compose build
```

# Run all three docker images
```sh
$ docker-compose up
```

# Check containers
```sh
$ docker ps
```

# To check the logs get the container id from the previous command 'docker ps'
```sh
$ docker logs --details -f -t <container id>
```

# To explore via bash terminal
```sh
$ docker exec -it <container id>  /bin/bash
```

# Test the .net core api using the sample web client
- Open chrome using the following command
```sh
$ chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
```
- http://localhost:13000/
- Press 'Click Me'
- Should return: ["value1","value2"]
