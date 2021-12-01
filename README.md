# NetCoreJenkinsDocker
Just For Test 
NetCore 5.0 With Jenkins With Docker

docker build --progress=plain --pull --rm -f "Dockerfile" -t netcorejenkinsdocker:v1 "."

docker run --rm -it  netcorejenkinsdocker:v1

docker run -it -d -p 7010:80 --name netcorejenkinsdockertest netcorejenkinsdocker:v1 
http://localhost:7010/weatherforecast